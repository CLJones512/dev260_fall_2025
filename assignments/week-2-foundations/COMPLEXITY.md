|Structure | Operation | Big-O (Avg) One-sentence rationale |
|----------|-----------|------------------------------------|
|Array     | Access By Index | O(1) - Regardless of how big the array is, you're only accessing one element|
|Array     | Search (unsorted) | O(n) - As the number of indicies grows, so does the amount of time it takes to sort through|
|List<T>   | Add at end | O(1) - It's still only carrying out one operation regardless of how long the list is|
|List <T>  | Insert at index | O(1) - Same as before, it's only carrying out one operation on the specified index|
|Stack <T> | Push / Pop / Peek | O(1) - These operations are only carried out on the first value in the stack, so it doesn't matter how long the stack is |
|Queue <T> | Enqueue / Dequeue / Peek | O(1) - Same as before, you are only carrying out these operations out on one value in the front and back of the queue|
|Dictionary <K,V> | Add / Lookup / Remove | O(1) - Again, only one operation is being carried out |
|HashSet | Add / Contains / Remove | O(1) - One operation is being carried out |