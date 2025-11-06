# Assignment 6: Game Matchmaking System - Implementation Notes

**Name:** [Your Name]

## Multi-Queue Pattern Understanding

**How the multi-queue pattern works for game matchmaking:**
Casual queues are the least complicated. The queue is built, then the first two players are matched, regardless of skill level.
Ranked queues have a little bit of logic, there is a method that checks to see if the players are relatively evenly matched, then starts a game if they are.
Quick Play queues are the most complicated. If there is below a certain number of players in the queue, it runs as if it was a casual match. If there is above a certain number of players, then the ranked match logic is implemented.

## Challenges and Solutions

**Biggest challenge faced:**
Quite possibly the biggest challenge I faced was one that I didn't need to face in the first place. When I was working on the method to show estimated wait times, I didn't read through the directions properly and thought that I actually needed to come up with an exact estimate of wait time instead of just saying "short wait", "no wait", and "long wait."

**How you solved it:**
To start out I created a helper method to calculate the average match time based on past matches. I struggled a bit with converting the DateTime type to int so I could build an average method, but after only a few minutes of this I reread the instructions and found that I didn't need to find exact wait times.

**Most confusing concept:**
I actually found this pretty straightforward. While it wasn't something that we did with this assignment, I'm still not completely solid on implementing more complex queue structures, like deques, circular queues, and priority queues.

## Code Quality

**What you're most proud of in your implementation:**
Everything worked the first time! I didn't need to go back and refactor anything in order to get the program to work the first time.

**What you would improve if you had more time:**
If I had more time, I would really buckle down and try to create a formula for finding the average match time and applying that towards queue wait times.

## Testing Approach

**How you tested your implementation:**
I tested the application piece by piece. I tried creating ranked matches with players of widely diferring skill levels, then I tried creating ranked matches with players of similar skill levels.

**Test scenarios you used:**
I tried to create a ranked match between ProGamer and Newbie, which didn't work. I then tried to create a ranked match between Average and my created player, coolguygamer

**Issues you discovered during testing:**
The only major issue I found was that I forgot some data in a few of the print statements.

## Game Mode Understanding

**Casual Mode matching strategy:**
This was pretty simple. First two into the queue are the first two matched to a game.

**Ranked Mode matching strategy:**
The program takes the first player in the queue then tries to find a player within two skill levels of them to match with.

**QuickPlay Mode matching strategy:**
If the queue is smaller, I use the casual strategy, and if it's bigger I use the ranked strategy.

## Real-World Applications

**How this relates to actual game matchmaking:**
As a certified casual gamer I don't really play ranked that often, but from what I understand you are assigned a rank, then these games pair you with players of a similar rank. Beat players of that rank and your rank goes up, matching you with harder players.

**What you learned about game industry patterns:**
This shows the complexity of how game developers implement matchmaking patterns. This assignment made use of a very simple check, but in reality systems are much, much more complicated than this.

## Stretch Features

None

## Time Spent

**Total time:** [6 hours]

**Breakdown:**

- Understanding the assignment and queue concepts: [2 hours]
- Implementing the 6 core methods: [2 hours]
- Testing different game modes and scenarios: [1.25 hours]
- Debugging and fixing issues: [0.25 hours]
- Writing these notes: [0.5 hours]

**Most time-consuming part:** The longest time was spent working through the logic. There were a lot of cases where I needed to implement some fairly complex logic trees, so I drew them out first before implementing them.

## Key Learning Outcomes

**Queue concepts learned:**
I learned about all sorts of operations using basic queues, and I learned a real-world application for queues.

**Algorithm design insights:**
I found that game development companies put a lot more work into their matchmaking algorithms than I had initially thought.

**Software engineering practices:**
I didn't really pick up too much about error handling from this, but I did work on making my code more readable in this assignment.
