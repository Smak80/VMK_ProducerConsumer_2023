using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMK_ProducerConsumer_2023
{
    public class Consumer
    {
        private bool _stop;
        private static Random _rnd = new Random();
        public void Start()
        {
            _stop = false;
            var t = new Thread(() =>
            {
                while (!_stop)
                {
                    var vals = CommonData.GetValues();
                    Thread.Sleep(_rnd.Next(1000, 5000));
                    var c = Color.FromArgb(vals[0], vals[1], vals[2]);
                    Console.WriteLine("C: {0}", c.Name);
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}
