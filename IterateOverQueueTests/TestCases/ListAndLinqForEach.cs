using System.Collections.Generic;
using System.Linq;

namespace IterateOverQueueTests.TestCases
{
    public class ListAndLinqForEach : ITestCase
    {
        private List<Item> _items = new List<Item>();
        
        public void RunIteration(int taskIteration)
        {
            _items.Add(new Item{IterationsRemaining = taskIteration});
            _items.ToList().ForEach(item =>
            {
                item.IterationsRemaining--;
                if (item.IterationsRemaining <= 0)
                    _items.Remove(item);
            });
        }
    }
}