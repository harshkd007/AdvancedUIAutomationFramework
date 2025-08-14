# .NET 6 Test Automation Framework

## Overview
A robust test automation framework built with .NET 6, SpecFlow, Selenium WebDriver, and Extent Reports. It supports BDD-style testing, data-driven scenarios, and automated HTML reporting.

## Features

- SpecFlow Integration: Write BDD tests using Gherkin syntax.
- Selenium WebDriver Automation: Automate browser actions for web applications.
- Extent Reports: Generate rich HTML test reports in the `Reports` folder.
- Page Object Model (POM): Encapsulate UI interactions in dedicated page classes for maintainable and reusable test code.
- Dependency Injection (DI): Use SpecFlow’s built-in DI container to manage WebDriver and page object li

## Getting Started

### Steps to Create the Framework from Scratch

1. Create a .NET 6 Project
   - Open Visual Studio 2022.
   - Search for "SpecFlow" in the project templates and create a new SpecFlow project.

2. Add Required NuGet Packages
   - Install the following packages:
     - `SpecFlow`
     - `SpecFlow.NUnit`
     - `Selenium.WebDriver`
     - `Selenium.WebDriver.ChromeDriver`
     - - `Selenium.WebDriver.EdgeDriver`
     - `AventStack.ExtentReports`

3. Set Up Folder Structure
   - `Features/` – Place your `.feature` files here.
   - `StepDefinitions/` – Add step definition classes.
   - `Helpers/` – Utility classes (e.g., Extent Report manager, CSV reader, Email helper).
   - `Reports/` – Generated test reports.

4. Configure SpecFlow
   - Add a default `specflow.json` or `app.config` for SpecFlow settings.

5. Implement Extent Report Integration
   - Create a helper to initialize, update, and flush Extent Reports after test runs.

6. Write Feature Files
   - Use Gherkin syntax to describe test scenarios in `.feature` files.

7. Implement Step Definitions
   - Map Gherkin steps to C# methods in the `StepDefinitions` folder.

8. Run and Validate Tests
    - Use Visual Studio Test Explorer or CLI to execute tests and review reports.

## Requirements

- .NET 6 SDK
- Visual Studio 2022
- Chrome/Edge browser (for Selenium tests)

## Author

- Harshavardhan Santosh Kadam
