using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Pilkngton.ProjectPaint.PaintApp
{
	
	/// <summary>
	/// this class is the error reporter which uses a queue so that error log entries can be added from multiple threads 
	/// </summary>
	public class EventLogThread : ErrorReporter
	{
		private Queue mySyncdQ; //a Synchronized queue means that it can by access by different threads as it employs locking for all operations except foreach type enumerations
		private bool runThreadProc = true;
		private bool hasEntries = false;
		/// <summary> used to signal the thread that there is an error msg in the queue </summary>
		public AutoResetEvent ELResetEvent;
		private EventLog ev;
		private Thread ELWriteThread;
		private static bool MessageBoxShowing = false;


		/// <summary>
        /// Constructor: initialises the base class error reporting.
        /// creates the class, call StartThreadProc next to run the thread. 
		/// </summary>
        public EventLogThread(int baseErrorNum, ErrorEventHandler handler) :
            base(baseErrorNum,handler)
		{
			try
			{
				mySyncdQ = Queue.Synchronized(new Queue()); //create the queue
				ELResetEvent = new AutoResetEvent(false);
				ev = new System.Diagnostics.EventLog("Application", System.Environment.MachineName, "PaintApp");
			}
			catch(Exception except)
			{
				reportError((BaseERRNUM + 101).ToString() + " EventLogThread constuctor failed to create either the Queue the Event or the EventLog " + (char)13 + except.ToString());
			}
		}
		
		/// <summary>
		/// adds a message to the queue then sets the event so that the thread will wake up and process the message 
		/// </summary>
		/// <param name="logText"></param>
		public void WriteToLog(string logText)
		{
			hasEntries = true;	//set flag so that main app can inform user there have been errors
			try
			{
				mySyncdQ.Enqueue(logText); //put the message into the queue
			}
			catch(Exception except)
			{
				reportError((BaseERRNUM + 102).ToString() + " EventLogThread:WriteToLog failed to put a message onto the queue " + (char)13 + except.ToString());
			}
			this.Signal();
		}
		
		/// <summary>
		/// creates and starts the thread 
		/// </summary>
		public void StartThreadProc()
		{
			try
			{
				ELWriteThread = new Thread(new ThreadStart(this.ELWriteThreadProc));
				ELWriteThread.Start();
			}
			catch(Exception except)
			{
				reportError((BaseERRNUM + 103).ToString() + " EventLogThread:StartThreadProc failed to create or start the thread " + (char)13 + except.ToString());
			}
		}
		
		/// <summary>
		/// resets the run flag and sets the event so the thread will wake up and know it's time to quit 
		/// </summary>
		/// <param name="timeoutmS"></param>
		/// <returns></returns>
		public bool StopThreadProc(int timeoutmS)
		{
			bool retval = false;
			runThreadProc = false;
			this.Signal();
			try
			{
				retval = ELWriteThread.Join(timeoutmS);
			}
			catch(Exception except)
			{
				reportError((BaseERRNUM + 104).ToString() + " EventLogThread:StopThreadProc call to thread join failed " + (char)13 + except.ToString());
				retval = false;
			}
			return retval;
		}
		
		/// <summary>
		/// sets the event 
		/// </summary>
		public void Signal()
		{
			try
			{
				ELResetEvent.Set();
			}
			catch(Exception except)
			{
				reportError((BaseERRNUM + 105).ToString() + " EventLogThread:Signal failed to Set the Event " + (char)13 + except.ToString());
			}
		}
		
		/// <summary>
		/// gets each message in turn off the queue and writes it to the event log 
		/// </summary>
		public void EmptyLog()
		{
			string logMsg = "sorry the message is not available as the read from the message queue failed";

			while(mySyncdQ.Count>0)
			{
				try
				{
					logMsg = mySyncdQ.Dequeue().ToString();
					ev.WriteEntry(logMsg,System.Diagnostics.EventLogEntryType.Information);
				}
				catch(Exception except)
				{
					reportError((BaseERRNUM + 106).ToString() + " failed to write the following error message to the event log" + logMsg);
				}
			}
		}
		/// <summary>
		/// only allow one message box at a time as it's pointles to keep stacking them up consuming resources
		/// </summary>
		/// <param name="ErrorMsg"></param>
		private void reportError(string ErrorMsg)
		{ 
			if(!MessageBoxShowing)
			{
				MessageBoxShowing = true;
				MessageBox.Show(ErrorMsg);
				MessageBoxShowing = false;
			}
		}
		
		/// <summary>
		/// waits till signalled then empties the queue one at a time writing each entry to the event log 
		/// </summary>
		public void ELWriteThreadProc()
		{
			while(runThreadProc)
			{
				try
				{
					ELResetEvent.WaitOne(); //only stop looping if there is nothing to do then wait until were signalled
				}
				catch(Exception except)
				{
					reportError((BaseERRNUM + 107).ToString() + " EventLogThread:ELWriteThreadProc failed to Wait on the Event " + (char)13 + except.ToString());
				}
				EmptyLog();
			}
		}

		
		/// <summary>
		/// set to true if any messages sent since the program began 
		/// </summary>
		public bool HasEntries
		{
			get
			{
				return hasEntries;
			}
		}
	}

}
