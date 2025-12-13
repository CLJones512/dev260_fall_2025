# Project Design & Rationale

**Instructions:** Replace prompts with your content. Be specific and concise. If something doesn't apply, write "N/A" and explain briefly.

---

## Data Model & Entities

**Core entities:**  
_List your main entities with key fields, identifiers, and relationships (1–2 lines each)._

**Your Answer:**

**Entity A:**

- Name: Juror
- Key fields: FullName, DateSummoned
- Identifiers:
- Relationships:

**Entity B (if applicable):**

- Name:
- Key fields:
- Identifiers:
- Relationships:

**Identifiers (keys) and why they're chosen:**  
_Explain your choice of keys (e.g., string Id, composite key, case-insensitive, etc.)._

**Your Answer:**
I chose an integer ID. This is because there's no issues with case differences, plus ints are just generally easier to work with. The downside of this though is that it would make scaling fairly difficult.

---

## Data Structures — Choices & Justification

_List only the meaningful data structures you chose. For each, state the purpose, the role it plays in your app, why it fits, and alternatives considered._

### Structure #1

**Chosen Data Structure:**  
_Name the data structure (e.g., Dictionary<string, Customer>)._

**Your Answer:**
Dictionary<int, Juror>

**Purpose / Role in App:**  
_What user action or feature does it power?_

**Your Answer:**
It powers most of the main functions

**Why it fits:**  
_Explain access patterns, typical size, performance/Big-O, memory, simplicity._

**Your Answer:**
Most Dictionary operations have a Big-O complexity of O(1), plus there's the benefit of easy lookup.

**Alternatives considered:**  
_List alternatives (e.g., List<T>, SortedDictionary, custom tree) and why you didn't choose them._

**Your Answer:**
List<Juror>, I didn't choose this because looking up a particular juror could be difficult

---

### Structure #2

**Chosen Data Structure:**  
_Name the data structure._

**Your Answer:**
Stack<Juror>

**Purpose / Role in App:**  
_What user action or feature does it power?_

**Your Answer:**

**Why it fits:**  
_Explain access patterns, typical size, performance/Big-O, memory, simplicity._

**Your Answer:**
Stacks make the most sense for an undo function since you're only ever accessing the top of the stack, leading to O(1) complexity.

**Alternatives considered:**  
_List alternatives and why you didn't choose them._

**Your Answer:**
None were considered.

---

### Structure #3

**Chosen Data Structure:**  
_Name the data structure._

**Your Answer:**
Queue<Juror>

**Purpose / Role in App:**  
_What user action or feature does it power?_

**Your Answer:**
This powers the Juror queue for selections for a case.

**Why it fits:**  
_Explain access patterns, typical size, performance/Big-O, memory, simplicity._

**Your Answer:**
I picked this since It would output the first jurors inputted, meaning that jurors that have been in the queue the longest will get the first cases.

**Alternatives considered:**  
_List alternatives and why you didn't choose them._

**Your Answer:**
None were considered.

---

### Additional Structures (if applicable)

_Add more sections if you used additional structures like Queue for workflows, Stack for undo, HashSet for uniqueness, Graph for relationships, BST/SortedDictionary for ordered views, etc._

**Your Answer:**

---

## Comparers & String Handling

**Comparer choices:**  
_Explain what comparers you used and why (e.g., StringComparer.OrdinalIgnoreCase for keys)._

**Your Answer:**
I used ints for keys so no comparers were needed.

**For keys:**

**For display sorting (if different):**

**Normalization rules:**  
_Describe how you normalize strings (trim whitespace, collapse duplicates, canonicalize casing)._

**Your Answer:**
On the Program.cs I trimmed whitespace and split the string so that additional input would be unhandled.

**Bad key examples avoided:**  
_List examples of bad key choices and why you avoided them (e.g., non-unique names, culture-varying text, trailing spaces, substrings that can change)._

---

## Performance Considerations

**Expected data scale:**  
_Describe the expected size of your data (e.g., 100 items, 10,000 items)._

**Your Answer:**
This could probably top out at 1,000 items. I can't imagine more people in a county, even a big one, being called for jury duty at any given time. Also, using ints for the keys makes it difficult to scale much past that.

**Performance bottlenecks identified:**  
_List any potential performance issues and how you addressed them._

**Your Answer:**

**Big-O analysis of core operations:**  
_Provide time complexity for your main operations (Add, Search, List, Update, Delete)._

**Your Answer:**

- Add: O(1)
- Search: O(1)
- List: O(n)
- Update: O(1)
- Delete: O(1)

---

## Design Tradeoffs & Decisions

**Key design decisions:**  
_Explain major design choices and why you made them._

**Your Answer:**
I chose to use a console app as it was the most simple app to use.

**Tradeoffs made:**  
_Describe any tradeoffs between simplicity vs performance, memory vs speed, etc._

**Your Answer:**
For a lot of this, I chose the simplicity of using fewer data structures, even though there were some operations running at O(1) time complexity.

**What you would do differently with more time:**  
_Reflect on what you might change or improve._

**Your Answer:**
I would've done more to handle the addition of date formats.
