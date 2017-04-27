using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task2Logic
{
    public class Clock
    {
        #region Fields 
        private TimeSpan time;
        public event EventHandler<EventArgs> TimeIsOver;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor with no params
        /// </summary>
        public Clock()
        {
            time = new TimeSpan();
            TimeIsOver = delegate { };
        }
        #endregion

        #region Public Methods

        public virtual void OnTimeIsOver(object sender, EventArgs e)
        {
            TimeIsOver(sender, e);
        }
        /// <summary>
        /// set seconds
        /// </summary>
        /// <param name="seconds"></param>
        public void SetSeconds(int seconds)
        {
            time = TimeSpan.FromSeconds(seconds);
        }
        /// <summary>
        /// start to measure time
        /// 
        /// /// </summary>
        public void Start()
        {
            Thread thread = new Thread(BeginTicks);
            thread.Start();
        }

        /// <summary>
        /// begin iteration
        /// </summary>
        public void BeginTicks()
        {
            double timeRemaining = time.TotalSeconds;

            while (timeRemaining > 0)
            {
                timeRemaining--;
                Thread.Sleep(1000);
               
            }
            OnTimeIsOver(this, EventArgs.Empty);
        }
        #endregion
    }
}
