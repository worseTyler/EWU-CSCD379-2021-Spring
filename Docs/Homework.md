# Homework

## Schedule
- Homework assignments will be assigned on Tuesday each week. These will show up as a new branch on the main IntelliTect repository. The README.ms file at the root of the repository will contain all of the details for the assignment.
- A pull request should be opened by 11:59pm the following Sunday.
- Code review of another student's pull request due the following Monday by 11:59pm.
- Any final corrections to your assignment due by 11:59pm the following Tuesday.

Please note:
* You do not need to have a pull request open to code review someone else's assignment.
* If a pull request is opened early, you do not need to wait until Monday to review it.
* All pull requests and comments are public. Please keep in mind that all code and comments are visible to the world.
* Code review do not need to only contain comments about issues; they can also be used to provide positive feedback.
* Though we encourage lots of collaboration, you are ultimently responsible for all of the code that you submit. We want you to learn from each other, not simply copy each other ([plagiarism](https://research.ewu.edu/c.php?g=53477&p=5600400); passing off someone else's work as your own, is not acceptable).

## Grading ##
Each assignment is a total of 60 points. Assignment *may* contain up to 10 points of extra credit (not guarenteed; and will be specified in the assignment).

### Main Assignment (40 points + potentially 10 points extra credit)
- Fundamentals: 10 points
  - All code compiles
  - Run without exceptions
  - All tests pass
- Assignment: 30 points
  - All assignment requirements completed
  - Code is appropriately unit tested
- Extra credit: 10 points (not guaranteed for all assignments)
  - These points given out at the instructor's discretion. These may not be given out if the assignment is not completed to a satisfactory level.

### Code Review (20 points)
- Review submitted on time (see [Late Work](#Late-Work))
- Accuracy of code review (does your review line up with the instructor's review)
- All ❌s on code review report must have comments on the relevant portion of code explaining why.

## Late Work

Our policy is to not accept work turned in after the due date. If there are extenuating circumstances, either talk to one of the instructors or send an email to EWU-Instructors@IntelliTect.com as early as possible. Exceptions may be made at the instructors discretion on a case-by-case basis.

If you have questions/comments/concerns about your grade please contact the instructors.

## Pairing ##
Students are ***HIGHLY*** encouraged to [pair program](https://en.wikipedia.org/wiki/Pair_programming) on assignments. Collaboration is different from copying someone else' work. When collaborating with another student should do the following:
* Only **one** of you should submit the pull request
* In the description explicitly **[mention](https://blog.github.com/2011-03-23-mention-somebody-they-re-notified/)** (just @ their GitHub name) with a comment indicating you collaborated on the assignment.
* If you pair with someone on the assignment the expectation is that you have both reviewed your own pull request. Neither of you need to perform any additional [code reviews](#Code-Review).


## Creating an Assignment Branch

Before starting an assignment ensure that [your fork is in-sync](https://help.github.com/articles/syncing-a-fork/) with the IntelliTect repository. Then, create a new branch for the assignment. Each assignment *must* be based on the given assignment branch. Keep your PRs as small as possible and focused on the assignment. The goal of the assignment is **not** to keep a running version of the project.

#### GitKraken
1. On the left panel in the REMOTE section. Right click on the intellitect remote and select Fetch intellitect.
2. Locate the desired assignment branch and select Create branch here. 
3. Give your branch a name. I suggest mirroring the name of the original assignment branch (Assignment1, Assignment2, etc). This creates a branch on your _local_ repository, that is _based_ on the original assignment branch.
4. When you have completed the work, push your changes. The first time you do this it may prompt you to specify a _remote_ branch name. Again, use the same name for the branch to avoid confusion. You now have a copy of the branch on your _fork_. 
5. When ready create a pull request back to the _original assignment branch_ (not to the main branch). The assignment does not need to be fully complete to start a pull request. As you push future changes to your branch, the pull request to automatically update with those changes.
  
#### Command Line
1. Ensure you are in the root of the repository.
2. Fetch the commits from the IntelliTect repository. `git fetch intellitect`
3. Create a new local branch from the remote branch `git checkout -b Assignment3 intellitect/Assignment3`
4. Unset the upstream branch so it no longer points at the original in the intellitect remote `git branch --unset-upstream`
5. When you have completed the work, push the your changes setting the upstream branch to one in your fork. `git push --set-upstream origin Assignment3`
6. When ready create a pull request back to the _original assignment branch_ (not to the main branch). The assignment does not need to be fully complete to start a pull request. As you push future changes to your branch, the pull request to automatically update with those changes.

## Submitting a pull request

Do not open a pull request until you are ready to have someone else [review it](#code-review). If you just want to post something to get feedback submit it as [draft pull request](https://github.blog/2019-02-14-introducing-draft-pull-requests/).

1. Open your repository on GitHub
2. Click the New pull request button
3. Set the source and target repository and branch. Pay attention to the direction of the arrow icon.
4. Click Create pull request.
5. Ensure the title includes "Assignment `<number>`"
6. If you [paired](#Pairing), ensure the other person's name is included in the description. Enter any reasonable description. Please note: the title and description can be updated over time.

## Code Review

All students are expected to perform a [code review](https://help.github.com/articles/about-pull-request-reviews/) of _someone else's PR_ (this is not needed if you are [pairing](#Pairing)). Ensure that you are marked as a reviewer on the PR (GitHub should do this automatically after you submit a review or comment). You can submit a review using the Comment status (it is not necessary to mark it as Approve or Request Changes). Make sure you submit the review. **Failing to submit the review, may result in the review not being counted.** 

Before starting a review, **immediately submit** a comment on the PR saying "I will review this", so other people do not start reviewing the same PR. 

No code review should be empty. There **must be at least one comment**. Include the assignment requirements in a list with the appropriate ✔❌ selected. For all requirements that are not met include a comment indicating why. Be aware that part of your grade is dependent on doing good code reviews.
[Code Review Guidelines](https://intellitect.com/code-reviews/)

If your assignment fails to get a Code Review, please post in the chat requesting one.

If you [pair](#Pairing) with someone on the assignment the expectation is that you have both reviewed your own pull request. Neither of you need to perform any additional Code Reviews.