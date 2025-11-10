# Reorder Point System (RPS) - Capstone Project

## Overview

Reorder Point System (RPS) is a Windows-based inventory management application designed to streamline tracking, analytics, and reordering for businesses. Built using C#, WinForms, and an SQLite database, the system enables users to manage stock levels, create automated reorder requests, and filter by item name and category. The project aims to enhance inventory accuracy and efficiency through mild automation while maintaining a simple, locally deployed executable system.

## Installation steps

1.  Clone the repository
2.  Open `ReorderPointSystem.sln` in Visual Studio.
3.  Build the project, NuGet packages will install/restore automatically
4.  Run the application, the database will be automatically generated if it doesn't already exist.

## Testing

**Testing will be done through the implementation of xUnit. If using Visual Studio, the tool bar should have a “Test” option. After clicking it the first option should be to run all tests, click run all tests and wait for them to complete.**

1.  Right click the solution file for your project, then under the “add” option, select “New Project”
2.  In the search bar, look for “xUnit Test Project” 8.0 LTS and name it [YourProjectName].Test
3.  Navigate to “tools” > “NuGet packet manager” > “manage NuGet package for solution” > “Browse” > Search for and install “Microsoft.NET.Test.Sdk” version 17.8.0 by Microsoft, “xunit” version 2.5.3 by jnewkirk_bradwilson, and “xunit.runner.visualstudio” version 2.5.3 by jnewkirk_bradwilson. If not already installed.
4.  Right click on “dependencies” under your testing project, select “Add project reference”. Toggle the check box for your main project and click “ok”
5.  Double click on the main file for your test project, it should be named [YourProjectName].Test. Within the <TargetFramework> tags, change the text to read “net8.0-windows” if it doesn’t already. Make sure to save the file

## Usage

**The following steps were created with the use of Visual Studio Community in mind**

1.  Click on the **Build** tab.
2.  Select **Publish Selection**.
3.  In the **Publish** tab, click **Add a publish profile**.
4.  Choose the **Folder** option.
5.  In the **Specific Target** tab, select the **Folder** option again.
6.  Go to the **Location** tab and click **Browse** to choose a storage location for the published files.
7.  Once a location is selected, click **Finish** to return to the **Publish** tab.
8.  In the **Settings** section, click **Show all settings**.
9.  Review the **Profile Settings** window and confirm the following:

    - **Configuration:** Release | Any CPU
    - **Target Framework:** net8.0-windows
    - **Deployment Mode:** Self-contained
    - **Target Runtime:** winx64 or winx86
    - **Target Location:** [expected storage location]

10. Open the dropdown for **File publish options** and check both boxes:


    -   Produce single file

    -   Enable ready to run compilation


11. Click **Save**.

12. Back in the **Publish** tab, click **Publish** in the upper-right corner.

13. Wait until the green **Publish succeeded** alert appears.

14. Navigate to the chosen storage location (published folder).

15. Locate the **ReorderPointSystem** application file (`.exe`).

16. Double-click the `.exe` file to open the application UI window.
