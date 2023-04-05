using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using NDI.SLIKDA.Interop;
using System.Windows.Forms;


namespace Pilkngton.ProjectPaint.PaintSupport
{
    public class OpcServer: ErrorReporter
    {
        public SLIKServer Server;


        /// <summary>
        /// Constructor: initialises the base class error reporting.
        /// takes the reference to the external control
        /// </summary>
        /// <param name="server">external SLIKDA control reference</param>
        public OpcServer(int baseErrorNum,ErrorEventHandler handler,SLIKServer server):
            base(baseErrorNum, handler)//next available +4
        {
            Server = server;
        }

        /// <summary>
        /// OPC severs and their interfaces are advertised in the registry.This method is used to modify the registration dependant on the action:
        ///     0 to register, 1 to unregister, 2 to re-register
        /// Re-registration is achieved by unregistering then registering and is done when the interface (tags) have changed
        /// </summary>
        /// <param name="action"></param>
        public void ModifyRegistration(int action)
        {
            Server.ProgID = "PaintApp.OPCServer.1";
            Server.AppName = "PaintApp";
            Server.Description = "Pilkington Paint Curtain Inspection System OPC Server";
            Server.VendorName = "Pilkington Plc";
            switch (action)
            {
                case 0:
                    Server.RegisterServer();
                    break;
                case 1:
                    Server.UnregisterServer();
                    break;
                case 2:
                    Server.UnregisterServer();
                    Server.RegisterServer();
                    break;
            }
        }
        /// <summary>
        /// configure (create the tags) and start the OPC server
        /// </summary>
        public void Start()
        {
            try
            {
                // NOTE: SLIKTags collection uses 1-based indices
                Server.SLIKTags.Add("Blips.All CountLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Blips.Small CountLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                   (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Blips.Medium CountLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Blips.Large CountLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Blips.XLarge CountLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Blips.All CountLast8Hour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Blips.All CountLast24Hour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.All SecondsLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                   (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.Small SecondsLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.Medium SecondsLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.Large SecondsLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.XLarge SecondsLastHour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                    (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.All SecondsLast8Hour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                   (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.SLIKTags.Add("Streams.All SecondsLast24Hour INT", (int)AccessPermissionsEnum.sdaReadAccess, 0,
                   (short)QualityStatusEnum.sdaGood, DefaultValues.Add_InitialTimestamp, DefaultValues.Add_AccessPaths);
                Server.StartServer();
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 1, except, " ERROR: OpcServer.Start:  problem starting opc server " + (char)13);
            }
        }
        /// <summary>
        /// stop the OPC server
        /// </summary>
        public void Stop()
        {
            try
            {
                //Server.RequestDisconnect("paint inspection system shutting down");

                Server.Dispose();
            }
            catch (Exception except)
            {
                 OnError(BaseERRNUM + 2, except, " ERROR: OpcServer.Stop:  problem stopping opc server " + (char)13);
            }
        }
        /// <summary>
        /// writes the supplied integer value to the tag name supplied
        /// </summary>
        /// <param name="tag">tag to write to</param>
        /// <param name="val">value to write</param>
        public void WriteIntValToTag(string tagstr, int val)
        {
            try
            {
                ISLIKTag tag = Server.SLIKTags[tagstr];
                tag.SetVQT(val, (short)QualityStatusEnum.sdaGood, DefaultValues.SetVQT_Timestamp);
            }
            catch (Exception except)
            {
                OnError(BaseERRNUM + 3, except, " ERROR: OpcServer.WriteIntValToTag:  problem writing to opc server tag " + tagstr + (char)13);
            }
        }
        /// <summary>
        /// writes to the BlipsTotal tag
        /// </summary>
        /// <param name="val">value to write</param>
        public void WriteBlipsTotalToTag(int allLasthour, int smallLasthour, int mediumLasthour, int largeLasthour, int xlargeLasthour, int last8hour, int last24hour)
        {
            WriteIntValToTag("Blips.All CountLastHour INT", allLasthour);
            WriteIntValToTag("Blips.Small CountLastHour INT", smallLasthour);
            WriteIntValToTag("Blips.Medium CountLastHour INT", mediumLasthour);
            WriteIntValToTag("Blips.Large CountLastHour INT", largeLasthour);
            WriteIntValToTag("Blips.XLarge CountLastHour INT", xlargeLasthour);
            WriteIntValToTag("Blips.All CountLast8Hour INT", last8hour);
            WriteIntValToTag("Blips.All CountLast24Hour INT", last24hour);
        }
        /// <summary>
        /// writes to the StreamsTotal tag
        /// </summary>
        /// <param name="val">value to write</param>
        public void WriteStreamsTotalToTag(int allLasthour, int smallLasthour, int mediumLasthour, int largeLasthour, int xlargeLasthour, int last8hour, int last24hour)
        {
            WriteIntValToTag("Streams.All SecondsLastHour INT", allLasthour);
            WriteIntValToTag("Streams.Small SecondsLastHour INT", smallLasthour);
            WriteIntValToTag("Streams.Medium SecondsLastHour INT", mediumLasthour);
            WriteIntValToTag("Streams.Large SecondsLastHour INT", largeLasthour);
            WriteIntValToTag("Streams.XLarge SecondsLastHour INT", xlargeLasthour);
            WriteIntValToTag("Streams.All SecondsLast8Hour INT", last8hour);
            WriteIntValToTag("Streams.All SecondsLast24Hour INT", last24hour);
        }
    }
}
