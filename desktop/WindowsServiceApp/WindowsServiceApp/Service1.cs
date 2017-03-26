using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceApp
{
    public partial class Service1 : ServiceBase
    {

        private Timer timer = null;
        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "Windows Service App Test";
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            this.timer.Interval = 30000; //every 30 secs
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.fireEvent);
            timer.Enabled = true;
            LogWriter.WriteErrorLog("Test window service started");
            EventLog.WriteEntry("WindowsServiceAppTest started.");
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            LogWriter.WriteErrorLog("WindowsServiceAppTest stopped");
        }

        private void fireEvent(object sender, ElapsedEventArgs e)
        {
            //Write code here to do some job depends on your requirement
            LogWriter.WriteErrorLog("Timer ticked and some job has been done successfully");
        }
    }
}
