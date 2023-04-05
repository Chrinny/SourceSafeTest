using System;

namespace Pilkngton.ProjectPaint.PaintApp
{
	/// <summary>
	/// The Alarm class is used to generate and clear alarm conditions based on the error code embedded in the standard error messages
	/// The src mask is a sub bit mask so the the same alarm condition can be registered for multiple gauges (thickness, water)
	/// an the alarm condition is only cleared when all alarming gauges have recovered.
	/// The alarmable conditions (Error numbers) are held in an array along with an Error code that clears them once the alarm state has recovered
	/// The alarm state is stored as an integer but has only 2 values 0 or 1 (off or on)
	/// From the Alarm list a status word is generated to be passed to the PLC and alarm conditions set and clear there appropriate staus bit
	/// The status is passed to the PLC or on request or if the status changes
	/// </summary>
	public class Alarm : ErrorReporter
	{
//									   alarm	clearby		srcMask	State	statusBit-1 
        uint[,] AlarmList = new uint[,]{{10011,	10018,		0,		0,		0},	//ctlThick unable to talk to socket, TCPControlBase succesful connection
										{10146,	10147,		0,		0,		1}};//frmMain EnablePlcAutoID the system will ignore plc plate IDs the user can select the product, the system will use plc plate IDs
		/// <summary> base error number to identify erros from this class</summary>
		private int lclStatus = 0; //b0 = : b1 = : b2 = DB fault: b3 = : b4 = : b5 = : b6 = S&K fault: b7 = : b8 = : b9 = : b10 =  
		/// <summary>
		/// whether we are currently in an Alarmed state
		/// </summary>
		public bool Alarmed = false;
		/// <summary>
        /// Constructor: initialises the base class error reporting.
		/// Doesn't do much else other than create the alarm list array
		/// </summary>		
		public Alarm(int baseErrorNum,ErrorEventHandler handler):
            base(baseErrorNum, handler)//next available +1
		{
			Alarmed = false;
		}

		//if the ErrorCode is in the alarm list then set the alarm, if it is in the clear list then clear all entries
		//if the state of all alarms is clear there is no alarm otherwise there is.
		//I can use srcMask as a bit store for the 7 gauges for multiple occurances of the same error e.g disconnection

		/// <summary>
		/// if the ErrorCode is in the alarm list then set the alarm, if it is in the clear list then clear all entries
		/// if the state of all alarms is clear there is no alarm otherwise there is.
		/// I use srcMask as a bit store for the 7 gauges for multiple occurances of the same error e.g disconnection
		/// </summary>
		/// <param name="newStatus">Reference: -1 if status unchanged value if status has changed </param>
		/// <param name="ErrorCode">the code to be checked against the alarm list</param>
		/// <param name="SrcId">optional bitmask used if the error message pertains to a specific gauge</param>
		/// <returns>true if any alarm set and false if not</returns>
		public bool CheckList(out bool AlarmChanged, ref int newStatus,uint ErrorCode,int SrcId) 

        {
			bool retval = false;
			uint Mask = 0x01;
			int prevStatus = Status;
			if(SrcId != -1)
				Mask = Mask<<((byte)SrcId); // create the bit mask from the ID if it exists

			for(int i=0;i<=AlarmList.GetUpperBound(0);i++) //loop through the alarm list and compare to incoming code
			{
				if(ErrorCode == AlarmList[i,0]) //is it an alarm code if so set the alarm state
				{
					AlarmList[i,3] = 1;
					if(SrcId != -1) 
						AlarmList[i,2] |= Mask; //set the bit field corresponding to the ID
					Status|= (1 << ((byte)AlarmList[i,4])); //update the appropriate status field
				}
				else if(ErrorCode == AlarmList[i,1])//is a clear code if so clear the alarm state
				{
					if(SrcId != -1) //is there a valid ID?
					{
						AlarmList[i,2] &= ~Mask; //and the ones compliment of the mask to clear the flag
						if(AlarmList[i,2] == 0)
							AlarmList[i,3] = 0; //only clear the flag when all occurances are clear 
					}
					else
					{
						AlarmList[i,3] = 0;
					}
					Status &= ~(1 << ((byte)AlarmList[i,4])); //update the appropriate status field
				}

				if(AlarmList[i,3] == 1)//if any alarms are set return true
					retval = true;
			}
			if(Status != prevStatus) //if the status has changed then return the new value
				newStatus = Status; 
			else
				newStatus = -1;		//if not flag for the same
			if(Alarmed != retval)
				AlarmChanged = true;
			else
				AlarmChanged = false;
			Alarmed = retval;
			return retval;
		}
		/// <summary>
		/// Check all the alarm list to see if an alarm condition exists
		/// </summary>
		/// <returns>true if any alarm set and false if not</returns>
		public bool CheckList()
		{
			bool retval = false;
			for(int i=0;i<=AlarmList.GetUpperBound(0);i++)
			{
				if(AlarmList[i,3] == 1)//if any alarms are set return true
					retval = true;				
			}
			return retval;
		}
		/// <summary>
		/// claera all alarm conditions
		/// </summary>
		public void ClearAll()
		{
			for(int i=0;i<=AlarmList.GetUpperBound(0);i++)
			{
				AlarmList[i,2] = 0;
				AlarmList[i,3] = 0;
			}
		}
		/// <summary>
		/// Property: The Status word sent to the PLC
		/// </summary>
		public int Status
		{
			get
			{
				return lclStatus;
			}
			set
			{
				lclStatus = value;
			}
		}
	}
}
