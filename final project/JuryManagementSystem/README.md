# Project Title

> One-sentence summary of what this app does and who it's for.

---

## What I Built (Overview)

**Problem this solves:**  
_Explain the real-world task your app supports and why it's useful (2–4 sentences)._

**Your Answer:**
I built a system to handle prospective jurors being summonsed for jury duty. It's useful because it can take a large pool of potential jurors and narrow it down to a jury of

**Core features:**  
_List the main features your application provides (Add, Search, List, Update, Delete, etc.)_

**Your Answer:**
There are full CRUD Operations (Create, Read, Update, Delete) on this, plus a method to print the full list of jurors and a method that adds the jurors to a queue, then outputs the first 12 into a jury.

-
-
-
-

## How to Run

**Requirements:**  
_List required .NET version, OS requirements, and any dependencies._

**Your Answer:**
This uses .NET version 9.0 and was built on Windows 11.

```bash
git clone <your-repo-url>
cd <your-folder>
dotnet build
```

**Run:**  
_Provide the command to run your application._

**Your Answer:**

```bash
dotnet run
```

**Sample data (if applicable):**  
_Describe where sample data lives and how to load it (e.g., JSON file path, CSV import)._

**Your Answer:**
The sample data is hardcoded into the application.
---

## Using the App (Quick Start)

**Typical workflow:**  
_Describe the typical user workflow in 2–4 steps._

**Your Answer:**

1. The user opens the app
2. The first step is to print the list to make sure the hardcoded list shows up
3. Afterwards, there's a full main menu that covers every operation in the code
4.

**Input tips:**  
_Explain case sensitivity, required fields, and how common errors are handled gracefully._

**Your Answer:**
Input is not case sensitive, and most fields handle exceptions by using try catch blocks and sending an error statement to the console.

---

## Data Structures (Brief Summary)

> Full rationale goes in **DESIGN.md**. Here, list only what you used and the feature it powers.

**Data structures used:**  
_List each data structure and briefly explain what feature it powers._

**Your Answer:**

- `Dictionary<...>` → Powers the main functions of this assignment
- `Queue<...>` → Powers the juror summons queue
- `Stack<...>` → Powers the undo function for deleting
- _(Add others: Queue, Stack, SortedDictionary, custom BST/Graph, etc.)_

---

## Manual Testing Summary

> No unit tests required. Show how you verified correctness with 3–5 test scenarios.

**Test scenarios:**  
_Describe each test scenario with steps and expected results._

**Your Answer:**

**Scenario 1: [Initial Test]**

- Steps: Once I implemented the dictionary, I tested using a basic list method to make sure I implemented it correctly
- Expected result: A list of my first four sample entries
- Actual result: My first four sample entries

**Scenario 2: [Test Search]**

- Steps: Built a search method to pull a record by ID, tested it with IDs that were in range and out of range.
- Expected result: ID that is in range pulls the right value, out of range throws an exception
- Actual result: Same as expected.

**Scenario 3: [Test Adding]**

- Steps: Added new juror to the dictionary by simply invoking a test method
- Expected result: Juror is added successfully
- Actual result: Juror was added sucessfully

**Scenario 4: [Name] (optional)**

- Steps:
- Expected result:
- Actual result:

**Scenario 5: [Name] (optional)**

- Steps:
- Expected result:
- Actual result:

---

## Known Limitations

**Limitations and edge cases:**  
_Describe any edge cases not handled, performance caveats, or known issues._

**Your Answer:**
I found an unhandled exception that I wasn't able to fix while testing the search method. Inputting an int outside of the range of juror keys will throw an unhandled NullReferenceException. Also, there's no functionality for dates as of yet. This was a feature that I was thinking about adding but could not implement in time.
-
-

## Comparers & String Handling

**Keys comparer:**  
_Describe what string comparer you used (e.g., StringComparer.OrdinalIgnoreCase) and why._

**Your Answer:**
I used ints for my keys so I didn't have to use any string comparers

**Normalization:**  
_Explain how you normalize strings (trim whitespace, consistent casing, duplicate checks)._

**Your Answer:**
I used string toLower methods plus a string split to remove any excess user input

---

## Credits & AI Disclosure

**Resources:**  
_List any articles, documentation, or code snippets you referenced or adapted._

**Your Answer:**
Geeks for Geeks was absolutely huge for me in so many ways.

-
- **AI usage (if any):**  
   _Describe what you asked AI tools, what code they influenced, and how you verified correctness._

  **Your Answer:**

  ***

## Challenges and Solutions

**Biggest challenge faced:**  
_Describe the most difficult part of the project - was it choosing the right data structures, implementing search functionality, handling edge cases, designing the user interface, or understanding a specific algorithm?_

**Your Answer:**
Handling edge cases definitely took me some time.

**How you solved it:**  
_Explain your solution approach and what helped you figure it out - research, consulting documentation, debugging with breakpoints, testing with simple examples, refactoring your design, etc._

**Your Answer:**
I spent a fair amount of time working to fix as many edge cases as I could.

**Most confusing concept:**  
_What was hardest to understand about data structures, algorithm complexity, key comparers, normalization, or organizing your code architecture?_

**Your Answer:**
I still wasn't completely solid on the idea of Dictionaries, this is one of the reasons I used them so prominently in this assignment, but doing more operations with them really helped me cement the concept.

## Code Quality

**What you're most proud of in your implementation:**  
_Highlight the best aspect of your code - maybe your data structure choices, clean architecture, efficient algorithms, intuitive user interface, thorough error handling, or elegant solution to a complex problem._

**Your Answer:**
I feel proud that I was able to take a structure I had little idea on implementing and build a functional application out of it.

**What you would improve if you had more time:**  
_Identify areas for potential improvement - perhaps adding more features, optimizing performance, improving error handling, adding data persistence, refactoring for better maintainability, or enhancing the user experience._

**Your Answer:**
First off, I'd spend more time smoothing out edge cases. Still too many unhandled exceptions for my liking.
Secondly, I'd add functionality for dates. My goal with those was to create a method that would take in a user input month or day, then enqueue every juror who's summon date matched the day or month.

## Real-World Applications

**How this relates to real-world systems:**  
_Describe how your implementation connects to actual software systems - e.g., inventory management, customer databases, e-commerce platforms, social networks, task managers, or other applications in the industry._

**Your Answer:**
This could be similar to how county courthouses select jurors for jury duty.

**What you learned about data structures and algorithms:**  
_What insights did you gain about choosing appropriate data structures, performance tradeoffs, Big-O complexity in practice, the importance of good key design, or how data structures enable specific features?_

**Your Answer:**

## Submission Checklist

- [ X ] Public GitHub repository link submitted
- [ X ] README.md completed (this file)
- [ X ] DESIGN.md completed
- [ X ] Source code included and builds successfully
- [ ] (Optional) Slide deck or 5–10 minute demo video link (unlisted)

**Demo Video Link (optional):**
