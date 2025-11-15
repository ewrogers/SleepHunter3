# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.1.1] - 11-15-2025

### Changed

- Fix saving/loading of comparison operators
- Fix arrow keys in `Send Keystrokes`

## [3.1.0] - 10-26-2025

This is the first release of the **Revived Edition**.
It is a complete re-write of the SleepHunter macro engine, with many new features and improvements.
This allows a much more extensible and powerful system that can be used to create new macros.

It keeps the original user interface with some quality of life improvements, additional validation, context menus,
and tons of optimizations for performance/memory usage.

It has been updated to support the latest Dark Ages Client version (7.41).
Both original SleepHunter macro files (`*.sh3`) and the new SleepHunter extended macro files (`*.sh3x`) are supported.

## Added

- `Switch to Chat History` (Shift+F) command
- `Switch to Modifiers` (Shift+G) command
- `Switch to World Skill/Spell` (H) command
- `If Chat Input Open` conditional command
- `While Chat Input Open` conditional loop
- `If Minimized Mode` (/) conditional command
- `If Inventory Expanded` conditional command
- `If Map Name` conditional command
- `While Map Name` conditional loop
- `If HP %` conditional command
- `While HP %` conditional loop
- `If MP Value` conditional command
- `While MP Value` conditional loop
- `If MP %` conditional command
- `While MP %` conditional loop
- `Define Label` command
- `Goto Label` command
- `Left Double Click` command
- `Right Double Click` command
- `Left Mouse Button Down` command
- `Left Mouse Button Up` command
- `Right Mouse Button Down` command
- `Right Mouse Button Up` command
- `Move Move Offset` command
- `Drag Mouse` command
- `Drag Mouse Offset` command
- `Step` debug mode toggle in `Macro` window
- Macro validation with error highlighting
- Highlight on paused line in `Macro` window
- Map name in `Status` window
- Command tool tip in tree view
- Right-click context menu with keyboard shortcuts for Macro window
- New `.sh3x` JSON file format
- Optional `Author` field when saving macros
- Legacy loader support for existing `.sh3x` files (saving will convert to new format)
- `Options` menu is now visible
- Dependency injection for much, much cleaner code
- Brand new macro command engine

### Changed

- Support for Dark Ages Client 7.41
- Default window size is larger for modern displays
- Show humanized health/mana values in status (ex: 8.1k or 1.24m)
- Auto-resize the macro command list view column
- Intelligent "auto-add" for closing commands (end if/while/loop)
- Refactored every single UI form for optimizations
- Optimize some graphics allocations
- Removed the long-defunct `Chat` window menu
- Removed the Debug / Logic Skeleton views
- Increased font size
- Updated to .NET Framework 4.8 (from 3.5)
- Re-wrote Win32 window interop
- Re-wrote Win32 process interop
- Re-wrote Win32 keyboard interop
- Re-wrote Win32 mouse interop

## [3.0.0] - 11-29-2005

Previous release of SleepHunter many years ago.