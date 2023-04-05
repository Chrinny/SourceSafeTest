using System;
using System.Collections.Generic;
using System.Text;

namespace Pilkngton.ProjectPaint.PaintApp
{
    /// <summary>
    /// Error Reporting functionality. Inherit from this class to add standardised error reporting
    /// The mechanism used is subscribing to an event rather than packaging and re-throwing the exception
    /// as I have seen articals that suggest that the latter can seriously affect performance.
    /// </summary>
    public class ErrorReporter
    {
        public int BaseERRNUM = 0;
        public delegate void ErrorEventHandler(int ERRNUM, string message);
        public event ErrorEventHandler Error;
        /// <summary>
        /// Constructor wires up the error repoting. By inheriting from this class and providing an event handler
        /// and error number, try catching exception and calling OnError, you have standardised error reporting.
        /// </summary>
        /// <param name="baseErrorNum"></param>
        /// <param name="handler">Error handler provided by the instantiating object</param>
        public ErrorReporter(int baseErrorNum,ErrorEventHandler handler)
        {
            BaseERRNUM=baseErrorNum;
            Error += new ErrorEventHandler(handler);
        }

        /// <summary>
        /// Formats the error and raises the event is raised that the instantiating object subscribed to
        /// by supplying a handler in the constructor
        /// 
        /// </summary>
        /// <param name="ERRNUM"> a number that identifies the error</param>
        /// <param name="e">an exception to report if one has be generated</param>
        /// <param name="str">a message giving informtaion to the user</param>
        /// <returns></returns>
        protected virtual bool OnError(int ERRNUM, Exception e, string str)
        {
            string exceptstr;
            if (e != null)
                exceptstr = e.ToString();
            else
                exceptstr = "";

            if (Error != null)
            {
                Error(ERRNUM, " " + this.GetType().Name + " " + str + (char)13 + exceptstr);
            }
            return true;
        } 
    }
}
