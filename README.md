In this assignment we are are going to begin work on the SecretSanta.Api project.
For this assignment we are only going to handle users. The intent is to learn about setting up the API project, dependency inject, and tests.

# Assignment
- Create a UserController in the API projects
  - Implement endpoints for:
    - Retrieving all users ✔❌
    - Retriving a single user by id ✔❌
    - Creating a user ✔❌
    - Updating a user ✔❌
    - Deleting a user ✔❌
  - The UserController should function. ✔❌
  - Include a `.rest` file for interacting with the controller ([REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)). ✔❌
- The `IUserRepository` interface is provided for you. You will need to provide an implementation of this interface within the SecretSanta.Business project. This implementation can simply store the user within a list, dictionary, array, or similar. ✔❌
- All test projects should be within a test directory ✔❌
- Create a unit test project for the SecretSanta.Business project. ✔❌
  - Unit test all public methods ✔❌
  - Ensure the project is named with a ".Tests" suffix ✔❌
  - Ensure test class is named appropriately for the class being tested: ✔❌
  - Name all tests in the form `<MethodBeingTested>_<ConditionBeingTested>_<ExpectedOutcome>()`. You can add  `<NoWarn>CA1707;INTL0003</NoWarn>` to remove the naming warnings. ✔❌
- Create a Unit Test project for the SecretSanta.Api project. ✔❌
  - Test all controller public methods. It is up to you to determine the best way to provide the controller's dependencies. ✔❌
  - Ensure the project is named with a ".Tests" suffix ✔❌

Extra Credit:
- Use a test double library like [Moq](https://www.nuget.org/packages/Moq) to provide the controller's dependencies.