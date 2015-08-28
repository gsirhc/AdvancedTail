# AdvancedTail
.NET Windows executable to follow changing text files and allows for advanced filtering and formatting.

### Features at a Glance
* Tail any text-based file
   * Passively follows the file updating in realtime
   * Show/hide line numbers
   * Can run multiple instances to tail many files
* Advanced Filtering using regular expressions
   * Filters lines in realtime
   * Regular expressions allow for OR and AND filtering
   * Automatically saves the filters by file
* Advanced line trimming with regular expressions
   * Trims line to a match or from a match to reduce the line size
* Lightweight to minimize CPU and memory usage
   * Uses .net file watcher to detect changes
   * Maintains a file pointer to the last read position to reduce read times
* Demo mode to show how it works
* Simple search capability to find text in the file

### System Requirements
* Windows 7 or higher
* .NET 4.5 (pre-installed with Windows 8)

### Install
1. Download the release EXE from the [Github Release Folder](https://github.com/gsirhc/AdvancedTail/tree/master/Tail/bin/Release)
2. Place anywhere on your system and run.