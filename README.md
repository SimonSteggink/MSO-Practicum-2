This is a submission for lab exercise 2 for Software Engineering at Utrecht University
by Koen Pol and Simon Steggink (Group 60).

# Requirements

.NET 10

# Running the application

Option A: Visual Studio (or similar)
1. Open "Programming Learning App.sln".
2. Set "Programming Learning App" as the startup project.
3. Press F5 (or Ctrl+F5).

Option B: Command line (from the folder with Programming Learning App.sln)
1. Build the solution: dotnet build
2. Go to the output folder: cd "Programming Learning App/bin/Debug/net10.0"
3. Start the app: dotnet "Programming Learning App.dll"

# Using the application

1. At the start, choose a program: `1` Basic, `2` Advanced, `3` Expert, `4` Random, or type the path to your own program file. A relative path is resolved from the folder the app was started in (with Option B, that's `bin/Debug/net10.0`), so a full path such as `C:\path\to\program.txt` is the easiest choice.
2. Then choose: `1` to execute the program, or `2` to calculate metrics (number of commands, maximum nesting, number of repeats).

# Running the unit tests

From the folder that contains `Programming Learning App.sln`:

    dotnet test

All 8 tests should pass.
