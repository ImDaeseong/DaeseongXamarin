using System;
using ScreenLock.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(CTimer))]
namespace ScreenLock.iOS
{
    public class CTimer : System.Timers.Timer, ITimer
    {
        public new event EventHandler Elapsed;

        private bool bDisposed;
        
        public CTimer()
        {
            base.Elapsed += baseElapsed;
        }

        public CTimer(double interval) : base(interval)
        {
            base.Elapsed += baseElapsed;
        }

        public TimeSpan IntervalTime
        {
            get { return new TimeSpan(0, 0, 0, 0, (int)Interval); }
            set { Interval = value.TotalMilliseconds; }
        }

        public void Reset()
        {
            Stop();
            Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (bDisposed)
                return;

            base.Elapsed -= baseElapsed;
            bDisposed = true;

            base.Dispose(disposing);
        }

        private void baseElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Elapsed?.Invoke(this, new EventArgs());
        }
    }
}
