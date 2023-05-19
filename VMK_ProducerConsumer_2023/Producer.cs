using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMK_ProducerConsumer_2023
{
    public class Producer
    {
        public enum Type
        {
            Red, Green, Blue
        }

        private Type _type;
        private bool _stop;
        private static Random _rnd = new Random();
        public Producer(Type t)
        {
            _type = t;
        }

        public void Start()
        {
            _stop = false;
            var t = new Thread(() =>
            {
                while (!_stop)
                {
                    Thread.Sleep(_rnd.Next(2000, 6001));
                    var value = _rnd.Next(256);
                    CommonData.PutValue(_type, value);
                    Console.WriteLine("P_{0}: {1:X}", _type, value);
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
