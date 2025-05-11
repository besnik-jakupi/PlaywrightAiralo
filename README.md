# Playwright eSIM Purchase Tests

This project contains automated UI tests using C# and Playwright for verifying the eSIM purchase flow on a web application. It is structured for ease of use and follows best practices for organizing test classes and resources.

🛠 Requirements
Before running the tests, ensure you have the following installed:

- .NET SDK - version 6.0 or later recommended
  👉 [Download .NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio (or any C#-compatible IDE)
  👉 [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- Playwright dependencies (automatically installed via the .NET CLI)
  👉 Run `dotnet add package Microsoft.Playwright` to install
- Node.js (required for Playwright browser binaries)
  👉 [Download Node.js](https://nodejs.org/)

📁 Project Structure
The project structure is as follows:

- Features / CreateUser.feature
- StepDefinitions / StepDefinitions.cs
- Pages / BasePage.cs - MainPage.cs

▶️ How to Run the Tests
1. Navigate to `esim-purchase-tests`
2. Run command: `dotnet restore` to restore dependencies
3. Run command: `dotnet test` to execute the tests