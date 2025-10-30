# Assignment 5: Browser Navigation System - Implementation Notes

**Name:** Colin Jones

## Dual-Stack Pattern Understanding

**How the dual-stack pattern works for browser navigation:**
When a URL is entered, it is set to the current page. If there already is a current page, it is pushed to the back stack and the forward stack is cleared.
If the user wants to go back, this pops the most recent addition to the back stack and makes it the current page, while pushing the previous current page
to the forward stack. If the user wants to go forward, the reverse happens, where the most recent site is popped off the forward stack while the current
site is added to the back stack.

## Challenges and Solutions

**Biggest challenge faced:**
The most difficult part of the assignment was getting the VisitUrl method to start in the first place.

**How you solved it:**
I was only able to implement a stopgap solution for now, effectively setting the homepage to google.

**Most confusing concept:**
The overaching concepts of this assignment were fairly straightforward to me. Having the in class lab helped me understand the material so much more than
I did in past weeks.

## Code Quality

**What you're most proud of in your implementation:**
I'm most proud of the way I managed my time. Breaking this assignment up into more parts helped me pace myself a bit better with this.

**What you would improve if you had more time:**
I still need to improve navigation. For some reason when a url is visited it gets pushed to the back stack an extra time and I'm still not sure how to fix it.

## Testing Approach

**How you tested your implementation:**
I used many Console.WriteLine and stack.Peek() statements to show what was being output at every step of the way.

**Issues you discovered during testing:**
As I said before, it was pushing an item to the backstack one extra time and I couldn't figure out how to fix it.

## Stretch Features

None Implemented

## Time Spent

**Total time:** [6 hours]

**Breakdown:**

- Understanding the assignment: [2 hours] (Time spent working on lab in class)
- Implementing the 6 methods: [2 hours]
- Testing and debugging: [1.5 hours]
- Writing these notes: [0.5 hours]

**Most time-consuming part:** 
The visitUrl method took the vast majority of my time. Trying to get it to add a site when there wasn't already a current page and trying to get the method to not add
the currentpage to the backstack again took me quite a while.
