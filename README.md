# IterateOverCollectionTests
Used for testing different methods of iterating over a collection that has items periodically added and removed

![image](https://user-images.githubusercontent.com/1475235/145747331-28541db1-10c2-478f-a3c9-bd8efcf0d3ba.png)

Summary:  Using a List and for loop is fastest.  Adding an object pool will slightly slow it down but drastically save on memory allocations and garbage collections.

![image](https://user-images.githubusercontent.com/1475235/145747482-b6cba51c-e554-4f3a-8b95-b0be7f49e08e.png)

![image](https://user-images.githubusercontent.com/1475235/145747530-15d6d71d-040d-4815-8bd2-659ef775dd87.png)

Looking at the dotTrace graph the List and for loop looks really good because it's less than 5% of the GC but that's only because the foreach loop is so bad.  When running dotTrace for just the ListAndForLoop with and without object pooling it shows 100% of GCs and memory allocations going to without a pool.  183 GCs vs 0 in a ~10 second period.  Object pooling look very worth doing for short duration classes like projectiles, ai tasks, naviation tasks, and so on.
