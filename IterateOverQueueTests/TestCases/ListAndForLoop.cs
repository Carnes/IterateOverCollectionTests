using System.Collections.Generic;
using System.Linq;

namespace IterateOverQueueTests.TestCases
{
    public class ListAndForLoop : ITestCase
    {
        private List<Item> _items = new List<Item>();
        
        public void RunIteration(int taskIteration)
        {
            _items.Add(new Item{IterationsRemaining = taskIteration});
            for (var i = _items.Count-1; i >= 0; i--)
            {
                _items[i].IterationsRemaining--;
                if (_items[i].IterationsRemaining <= 0)
                    _items.RemoveAt(i);
            }
        }
    }
}