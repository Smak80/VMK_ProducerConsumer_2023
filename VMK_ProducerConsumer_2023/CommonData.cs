using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMK_ProducerConsumer_2023
{
    public static class CommonData
    {
        private static Queue<int>[] _pData = new Queue<int>[3];

        static CommonData()
        {
            for (int i = 0; i < _pData.Length; i++)
            {
                _pData[i] = new Queue<int>();
            }
        }

        //private static void ResetArray()
        //{
        //    for (int i = 0; i < _pData.Length; i++) { _pData[i] = -1; }
        //}

        public static void PutValue(Producer.Type t, int value)
        {
            lock (_pData)
            {
                while (_pData[(int)t].Count > 4)
                {
                    Monitor.Wait(_pData);
                }
                _pData[(int)t].Enqueue(value);
                Monitor.PulseAll(_pData);
            }
        }

        public static int[] GetValues()
        {
            int[] values = new int[_pData.Length];
            lock (_pData)
            {
                for (int i = 0; i < _pData.Length; i++)
                {
                    while (_pData[i].Count == 0)
                    {
                        Monitor.Wait(_pData);
                    }
                }

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = _pData[i].Dequeue();
                }
                Monitor.PulseAll(_pData);
            }
            return values;
        }
    }
}
