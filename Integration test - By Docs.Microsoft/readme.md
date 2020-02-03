# Integration Test

Integration tests evaluate an app's components on a broader level than unit tests. Unit tests are used to test isolated software components, such as individual class methods. Integration tests confirm that two or more app components work together to produce an expected result, possibly including every component required to fully process a request.

These broader tests are used to test the app's infrastructure and whole framework, often including the following components:

Database
File system
Network appliances
Request-response pipeline



In contrast to unit tests, integration tests:

Use the actual components that the app uses in production.
Require more code and data processing.
Take longer to run.


Test app prerequisites
The test project must:

Reference the Microsoft.AspNetCore.Mvc.Testing package.
Specify the Web SDK in the project file (<Project Sdk="Microsoft.NET.Sdk.Web">).
These prerequisites can be seen in the sample app. Inspect the tests/RazorPagesProject.Tests/RazorPagesProject.Tests.csproj file. The sample app uses the xUnit test framework and the AngleSharp parser library, so the sample app also references:


