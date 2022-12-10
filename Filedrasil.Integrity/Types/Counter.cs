using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filedrasil.Integrity.Types
{
    public partial class Counter<T> where T : unmanaged
    {
        private readonly List<ElementInfo<T>> Dictionary = new();
        public void Add(T value)
        {
            if (Dictionary.Find(x => x.Value.Equals(value)) is ElementInfo<T> match)
            {
                match.Counter++;
            }
            else Dictionary.Add(new(value));
        }

        public void Clear() => Dictionary.Clear();

        public T[] GetVoted()
        {
            // Get highest count
            int highestCount = 0;
            foreach(ElementInfo<T> element in Dictionary)
            {
                highestCount = element.Counter > highestCount ? element.Counter : highestCount;
            }

            // Return elements with highest count
            List<T> result = new();
            foreach(ElementInfo<T> element in Dictionary)
            {
                if (element.Counter == highestCount)
                    result.Add(element.Value);
            }

            return result.ToArray();
        }
    }
}
