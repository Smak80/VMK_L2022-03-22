using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMK_L2022_03_22
{
    public class Fibo : IEnumerable<int>
    {
        //private FiboEnumerator fe = new FiboEnumerator();
        private int a, b = 1;

        public IEnumerator<int> GetEnumerator() // => fe;
        {
            a = 0;
            b = 1;
            while (true)
            {
                if (a > 100) yield break;
                b += a;
                a = b - a;
                yield return a;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FiboEnumerator : IEnumerator<int>
    {
        private int a = 0, b = 1;
        public int Current => a;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Reset();
        }

        public bool MoveNext()
        {
            b += a;
            a = b - a;
            return a <= 100;
        }

        public void Reset()
        {
            a = 0;
            b = 1;
        }
    }
}
