using System.ComponentModel;
using System.Threading;

namespace CustomDVDScreenSaver
{
    class AbortableBackgroundWorker : BackgroundWorker
    {
        private Thread workerThread;

        public void Abort()
        {
            if (this.workerThread == null)
            {
                return;
            }

            this.workerThread.Abort();
            this.workerThread = null;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            this.workerThread = Thread.CurrentThread;

            try
            {
            base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
                Thread.ResetAbort();
            }
        }
    }
}
