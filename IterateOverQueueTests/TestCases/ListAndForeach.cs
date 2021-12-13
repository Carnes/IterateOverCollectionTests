using System.Collections.Generic;
using System.Linq;

namespace IterateOverQueueTests.TestCases
{
    public class ListAndForeach : ITestCase
    {
        private List<Item> _items = new List<Item>();
        
        public void RunIteration(int taskIteration)
        {
            _items.Add(new Item{IterationsRemaining = taskIteration});
            foreach (var item in _items.ToList())
            {
                item.IterationsRemaining--;
                if (item.IterationsRemaining <= 0)
                    _items.Remove(item);
            }
        }
    }
}