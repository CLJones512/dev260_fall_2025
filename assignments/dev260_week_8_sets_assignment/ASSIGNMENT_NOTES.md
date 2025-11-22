# Assignment 8: Spell Checker & Vocabulary Explorer - Implementation Notes

**Name:** Colin Jones

## HashSet Pattern Understanding

**How HashSet<T> operations work for spell checking:**
HashSets are perfect for this because spell checking databases focus on individual, unique words, and HashSets require unique data, filtering out any non-unique data.

## Challenges and Solutions

**Biggest challenge faced:**
File I/O was a bit of a challenge, especially as I haven't worked with it in a while

**How you solved it:**
I started by doing things piece by piece. I started with operations that I knew how to write, then moved onto the ones I was a bit more hesitant on. Reading the documentation on the ReadAllText() and ReadAllLines methods helped me figure out how to implement them as well.

**Most confusing concept:**
It took me a little while to understand the difference between a HashSet and a Dictionary or a List, and why I'd use one over the other, but this assignment helped me realize a situation where a HashSet is better.

## Code Quality

**What you're most proud of in your implementation:**
On this project I'm actually most proud of my methodology for implementing things. I gave myself enough time to work in short spurts, taking a break when I was starting to bash my head against the wall.

**What you would improve if you had more time:**
I would've liked to spend a bit of time trying to implement some of the stretch features.

## Testing Approach

**How you tested your implementation:**
I tested with a properly spelled word along with a misspelled word.

**Test scenarios you used:**
I made sure that words with punctuation attached, words with mixed case, and whitespace were handled correctly.

**Issues you discovered during testing:**
I found out that on one of my functions I hadn't properly implemented normalization, so I fixed that.

## HashSet vs List Understanding

**When to use HashSet:**
I would use a HashSet when I want a unique set of data, especially if it's a much bigger dataset.

**When to use List:**
I would use a list if I want to allow repititions, or if I want to handle a smaller set of data.

**Performance benefits observed:**
Being able to automatically handle uniqueness is a huge plus. If I had kept all the data in a list instead, I would've had to do a lot more coding to strip out duplicates from my list.

## Real-World Applications

**How this relates to actual spell checkers:**
Real life spell checkers use very similar methods to my implementation. They have a built-in dictionary containing properly spelled words, and every word that's typed out is automatically checked against the built-in dictionary. Programs like MS Word and Google Docs also have methods to handle adding new words to the dictionary.

**What you learned about text processing:**
This helped me realize that normalizing strings isn't too terribly difficult. It's been a complaint that I've had for a while when sites don't normalize certain user inputs, leading to confusion over case, whitespace, and punctuation.

## Stretch Features

None implemented

## Time Spent

**Total time:** 6 hours

**Breakdown:**
- Understanding HashSet concepts and assignment requirements: 2 hours
- Implementing the 6 core methods: 2 hours
- Testing different text files and scenarios: 1/2 hour
- Debugging and fixing issues: 1 hour
- Writing these notes: 1/2 hour

**Most time-consuming part:**
Implementing the File I/O methods took me the longest, just because I was completely out of practice with it.

## Key Learning Outcomes

**HashSet concepts learned:**
I learned that you can access data within a HashSet with O(1) efficiency and that HashSets can automatically handle unique data.

**Text processing insights:**
I learned that it's fairly easy to strip extra data from strings, and that tokenizing a string in C# is as simple as implementing a string.Split() operation.

**Software engineering practices:**
I learned a fair amount about handling edge cases gracefully.