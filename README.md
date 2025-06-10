# Birthday Checker App – Development Plan (No Data Layer)

## Overview
This is a Blazor Server app built with ASP.NET Core 9 that allows users to enter and view birthdays. It detects birthdays occurring today and operates entirely in memory — no database or persistent storage is used.

---

## Development Phases and Steps

### 🧱 Phase 1: Environment Setup

#### - [x] Step 1: Install .NET 9 SDK

Installing the .NET 9 SDK is the first step. There are multiple ways to install the SDK depending on your operating system and preferences. It is highly recommended to consult the official Microsoft .NET download page for the most current and comprehensive guidance:
- **Official .NET 9 Download Page:** [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- **General .NET Installation Guide:** [https://learn.microsoft.com/dotnet/core/install/](https://learn.microsoft.com/dotnet/core/install/)

Below are brief instructions for common operating systems:

##### For Linux

You can install the .NET SDK using a package manager or by using the `dotnet-install` scripts.

**Using a Package Manager (Recommended for many distributions):**

Package managers (like `apt` for Ubuntu/Debian, `dnf` for Fedora, `zypper` for openSUSE) are often the easiest way to install and manage .NET.
- Find instructions for your specific Linux distribution here: [https://learn.microsoft.com/dotnet/core/install/linux](https://learn.microsoft.com/dotnet/core/install/linux)

**Using the `dotnet-install.sh` script:**

This script is useful for CI/CD automation, non-admin installs, or installing specific versions not yet available in package managers.

**1. Install Dependencies (Crucial Prerequisite):**
   Before running the script, you **must** install OS-specific dependencies. Failure to do so might lead to runtime issues.
   - Find the list of dependencies for your distribution: [https://learn.microsoft.com/dotnet/core/install/linux-scripted-manual#dependencies](https://learn.microsoft.com/dotnet/core/install/linux-scripted-manual#dependencies) (or check your distribution's page via the main Linux install guide).
   - For example, on Debian/Ubuntu, you might need packages like `libc6`, `libgcc1`, `libgssapi-krb5-2`, `libicu[version]`, `libssl3`, `libstdc++6`, `zlib1g`. Always refer to the official documentation for the exact list for your OS version.

**2. Download and run the script:**
   ```bash
   # Download the script
   wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
   # Or using curl:
   # curl -L https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh

   # Make the script executable
   chmod +x dotnet-install.sh

   # Run the script to install .NET 9 SDK
   # The --channel 9.0 parameter specifically targets .NET 9 (a Standard Term Support release).
   # The script's default without --channel might install an LTS version (e.g., .NET 8).
   ./dotnet-install.sh --channel 9.0
   ```

**3. Configure environment variables:**
   Add the .NET tools to your PATH. Add these lines to your shell profile (e.g., `~/.bashrc`, `~/.zshrc`):
   ```bash
   export DOTNET_ROOT=$HOME/.dotnet
   export PATH=$PATH:$HOME/.dotnet:$HOME/.dotnet/tools
   ```
   Then, source your profile (e.g., `source ~/.bashrc`) or open a new terminal.

##### For Windows

You can install the .NET 9 SDK using the official installers or the Windows Package Manager (`winget`).
- **Download installers:** [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0) (select the appropriate Windows installer x64, x86, or Arm64).
- **Using winget:**
  ```powershell
  winget install Microsoft.DotNet.SDK.9
  ```
  For more on winget: [https://learn.microsoft.com/dotnet/core/install/windows#install-with-windows-package-manager-winget](https://learn.microsoft.com/dotnet/core/install/windows#install-with-windows-package-manager-winget)

##### For macOS

Download the appropriate installer for your Mac's architecture (x64 or Arm64) from the official .NET 9 download page.
- **Download installers:** [https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)

---

**Verify the installation:**
After installation, open a new terminal or command prompt and run:
```bash
dotnet --version
```
This should display the installed .NET 9 SDK version.

**Visual Studio Compatibility:**
If you plan to use Visual Studio, ensure you have a compatible version. Check the .NET 9 download page ([https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)) for details on supported Visual Studio 2022 versions.

---

### 🧱 Phase 2: Project Creation

#### - [x] Step 2: Create Blazor Server App
```bash
dotnet new blazorserver -n BirthdayChecker
cd BirthdayChecker
```

#### - [x] Step 3: Clean Up Template
- Remove example pages (`Counter.razor`, `FetchData.razor`)  
- Update navigation links to point to your pages

---

### 🧠 Phase 3: Define Application State

#### - [x] Step 4: Create Birthday Model
- Define a simple `Birthday` class with `Name` and `DateOfBirth` properties  
- Create an in-memory `List<Birthday>` to store birthday entries during runtime

#### - [x] Step 5: Create a Scoped AppState Service (optional)
- Encapsulate the list and related logic in a singleton or scoped service  
- Inject this service into components that access or modify birthdays

---

### 🖥️ Phase 4: Build Core UI Components

#### - [x] Step 6: AddBirthday.razor
- Form with inputs for name and birthdate  
- Adds new entries to the in-memory list

#### - [x] Step 7: BirthdayList.razor
- Display all birthdays currently in memory  
- Show name and formatted date

#### - [x] Step 8: TodayBirthday.razor
- Filter and display birthdays matching today’s month and day

#### - [x] Step 9: Update Navigation
- Add links to each component in `NavMenu.razor`

---

### 🧪 Phase 5: Testing and Validation

#### - [x] Step 10: Manual UI Testing
- Add test birthdays  
- Reload and verify entries disappear (no persistence)  
- Check that today’s birthday logic works correctly

#### - [x] Step 11: Add Form Validation
- Validate required fields  
- Ensure valid date input

---

### 🎨 Phase 6: UI Polish

#### - [x] Step 12: Improve Layout
- Apply Bootstrap or your preferred CSS framework  
- Use cards, tables, or alerts for better visual structure

#### - [x] Step 13: Add Icons or Emojis
- Add 🎂 emoji or other birthday indicators for a friendly touch

---

### 🚀 Phase 7: (Optional) Runtime Enhancements

#### - [x] Step 14: Add Extra Features
- Show upcoming birthdays within the next 7 days  
- Export the birthday list to JSON  
- Use browser localStorage via JS interop to persist data across sessions  
- Add a timer or auto-refresh feature to update birthday checks in real time

---

## Notes

- This app is session-based only — data will be lost on page reload or app restart.  
- For persistence, consider integrating a database, file storage, or browser storage in future iterations.
