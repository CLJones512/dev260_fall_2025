1. For each of the List, HashSet, and Dictionary I predicted O(1). The HashSet and Dictionary turned out to be O(1) \n
but the List was the outlier. Having gotten a new computer recently that is quite fast, I had to add in a method to \n
benchmark using 100 million pieces of data. Finally, the List took more than 0ms to sort through, returning a best time of \n
21ms for List.Contains and 23ms for List.Contains(-1). \n\n

2. I was a bit surprised that the list turned out to be the one that took any amount of time to comb through. I felt \n
like since it seemed like it was only doing one operation, all of them would take the same amount of time all the time.\n\n

3. I would probably choose a dictionary given a large enough data set. It seems like it's the easiest to sort through while \n
it's also easy enough to pick out one specific field from the data set.