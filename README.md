# Assignment 9 & 10

## Overview

In this assignment we are going to build "complete" the SecretSanta project. As discussed in class on Thursday, you have two weeks to complete the assignment which is worth "double the points".

## Assignment

- Configure all data to be stored in an SqLite Database using the Entity Framework.
  - Hint: Add a Gift object to the SecretSanta.Data project
  - Hint: Update `Group` and `Assignment` to persist as a many-to-many relationship
- Provide UI functionality for a complete Secret Santa functionality 
  including
  - The ability for a user to add a list of gifts
  - Displaying who a user's secret santa is for in each group.
  - Viewing all gifts requested by your secret santa
- Remove the MockData class and replace it with sample data that gets deployed into the database following a migration when the command "DeploySampleData" is specified on the command line.
- Allow for the connection string (db path) for the SqLite database to be provided using `Microsoft.Extensions.Coniguration`:
  - Default to main.db in the same directory as the SecretSanta.Data assembly.
  - Allow for an environment variable called to override the defaiult connection string
  - Allow a connection string passed on the command line to take precidence over the environment variable.
- Add some minimal rudimentary logging using `Microsoft.Extensions.Logging`:
- Configure the Entity Framework to log to a dblog.log file (located in the SecretSanta.Data assembly directory) with the category name "Database".
- GitHub Action CI/CD Build
  - Ensure all tests (unit test, end to end tests, etc.) are running in your GitHub Action build and include a URL to the build in your executing GitHub action in your pull request.
  - Ensure website is deployed by your GitHub Action and proivde URL to the deployed site in your pull request.

## Extra Credit
