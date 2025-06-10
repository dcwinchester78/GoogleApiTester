# Birthday Checker App – Development Plan (No Data Layer)

## Overview
This is a Blazor Server app built with ASP.NET Core 9 that allows users to enter and view birthdays. It detects birthdays occurring today and operates entirely in memory — no database or persistent storage is used.

---

## Development Phases and Steps

### 🧱 Phase 1: Environment Setup

#### ✅ Step 1: Install .NET 9 SDK on Linux  
Follow the official steps to install .NET 9 on your Linux distribution.

**For Ubuntu/Debian:**
```bash
wget https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel 9.0
```

Add it to your path:
```bash
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$HOME/.dotnet:$HOME/.dotnet/tools
```

Verify the installation:
```bash
dotnet --version
```

---

### 🧱 Phase 2: Project Creation

#### ✅ Step 2: Create Blazor Server App  
```bash
dotnet new blazorserver -n BirthdayChecker
cd BirthdayChecker
```

#### ✅ Step 3: Clean Up Template  
- Remove example pages (`Counter.razor`, `FetchData.razor`)  
- Update navigation links to point to your pages

---

### 🧠 Phase 3: Define Application State

#### ✅ Step 4: Create Birthday Model  
- Define a simple `Birthday` class with `Name` and `DateOfBirth` properties  
- Create an in-memory `List<Birthday>` to store birthday entries during runtime

#### ✅ Step 5: Create a Scoped AppState Service (optional)  
- Encapsulate the list and related logic in a singleton or scoped service  
- Inject this service into components that access or modify birthdays

---

### 🖥️ Phase 4: Build Core UI Components

#### ✅ Step 6: AddBirthday.razor  
- Form with inputs for name and birthdate  
- Adds new entries to the in-memory list

#### ✅ Step 7: BirthdayList.razor  
- Display all birthdays currently in memory  
- Show name and formatted date

#### ✅ Step 8: TodayBirthday.razor  
- Filter and display birthdays matching today’s month and day

#### ✅ Step 9: Update Navigation  
- Add links to each component in `NavMenu.razor`

---

### 🧪 Phase 5: Testing and Validation

#### ✅ Step 10: Manual UI Testing  
- Add test birthdays  
- Reload and verify entries disappear (no persistence)  
- Check that today’s birthday logic works correctly

#### ✅ Step 11: Add Form Validation  
- Validate required fields  
- Ensure valid date input

---

### 🎨 Phase 6: UI Polish

#### ✅ Step 12: Improve Layout  
- Apply Bootstrap or your preferred CSS framework  
- Use cards, tables, or alerts for better visual structure

#### ✅ Step 13: Add Icons or Emojis  
- Add 🎂 emoji or other birthday indicators for a friendly touch

---

### 🚀 Phase 7: (Optional) Runtime Enhancements

#### ✅ Step 14: Add Extra Features  
- Show upcoming birthdays within the next 7 days  
- Export the birthday list to JSON  
- Use browser localStorage via JS interop to persist data across sessions  
- Add a timer or auto-refresh feature to update birthday checks in real time

---

## Notes

- This app is session-based only — data will be lost on page reload or app restart.  
- For persistence, consider integrating a database, file storage, or browser storage in future iterations.
