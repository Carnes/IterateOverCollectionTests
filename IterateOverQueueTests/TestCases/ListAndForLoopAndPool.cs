using System.Collections.Generic;

namespace IterateOverQueueTests.TestCases
{
    public class ListAndForLoopAndPool: ITestCase
    {
        private List<Item> _items = new List<Item>();
        private Stack<Item> _itemPool = new Stack<Item>();
        
        public void RunIteration(int taskIteration)
        {
            var newItem = GetNewItem();
            newItem.IterationsRemaining = taskIteration;
            _items.Add(newItem);
            for (var i = _items.Count-1; i >= 0; i--)
            {
                _items[i].IterationsRemaining--;
                if (_items[i].IterationsRemaining <= 0)
                    RecycleItem(_items[i]);
            }
        }

        private void RecycleItem(Item item)
        {
            _itemPool.Push(item);
            _items.Remove(item);
        }

        private Item GetNewItem()
        {
            if (_itemPool.Count == 0)
                return new Item();
            return _itemPool.Pop();
        }
    }
}