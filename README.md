# AdvancedTail
A lightweight .NET Windows program to follow changing text files and provides advanced filtering and formatting.

* Tail any text-based file in a user-friendly GUI
* Advanced Filtering using regular expressions
* Advanced line trimming using regular expressions to enhance readability
* Line highlighting
* Lightweight/small footprint
* Demo mode to show how it works
* Simple text search
* Saves a file history in the users appdata folder, including filters per file
* Can run multiple instances to tail several logs at once

### System Requirements
* Windows 7 SP1 or higher
* .NET 4.5 or higher

### Install
1. Download the release executable from the [/AdvancedTail/Tail/bin/Release Folder](https://github.com/gsirhc/AdvancedTail/raw/master/Tail/bin/Release/Tail.exe)
2. Place anywhere on your system and run.

### Downloading Source
You are of course welcome to download the source.  AdvancedTail source was written using 
Visual Studio 2015 Community Edition.  With Visual Studio installed, simply open the Tail.sln file.
There are a few Nuget packages to download which Visual Studio should do automatically.

### Features in Detail

![Main Form](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/main3.png)

#### Filtering
AdvancedTail provides a filtering engine to remove lines from the displayed text using regular expressions.
Though regex is a scary/complex search language, it easily provides all the filtering capabilties
you'd expect and the expressions can be simple (see below for an example).

![Filter Form Screenshot](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/filter.png)

##### How does filtering work?
AdvancedTail uses a given regular expression and tests it against each line of the file.  If the line is a match
it will be displayed.  Any line that does not match will be hidden.

Lets say you have the following log file:

```
[7:10:01pm] This is a test log line
[7:10:02pm] We want to see this line because it rocks
[7:10:03pm] But not this line
[7:10:04pm] And we want to see this line because it rules
```

To filter out the lines you don't want to see, create a filter like this:

``` "to see" ```

AdvancedTail will display:

```
[7:10:02pm] We want to see this line because it rocks
[7:10:04pm] And we want to see this line because it rules
```

You can also OR filters like ```rules|rocks``` to display the same lines.

#### Trimming
AdvancedTail also provides a mechanism to trim lines based on regular expressions.  This is useful
if you want to remove common text from the lines to make them easier to read.

##### How does trimming work?

The trimming feature provides two types of trims:
* Trim To: Trims from the beginning of the line to the first character of the match
* Trim From: Trims from the first character of the match to the end.

NOTE: If using "To" and "From" together, trims the "To" first, then applies the "From" to the remaining text.

Lets say you this log file:

```
[7:10:02pm] We like this line because it rocks and rolls
[7:10:04pm] And we like this line because it rules and rolls
```

To trim off the common parts of the lines:

``` 
trim to: "it"
trim from: "and rolls"
```

AdvancedTail will display:

```
it rocks
it rules
```

Or you can be more specific with the "To":  ```trim to: "it rules|it rocks"```

#### Line Highlighting
AdvanvedTail provides separate regular expressions to define how lines are
highlighted in the display.  You can define up to 5 color
expressions red, yellow, green, blue and gray.  Additionally, highlighting can be toggled on and off
in real time.

The Filter Configuration form also contains 3 predefined highlighting
setups for use with traditional log files that output log levels such
as debug, trace, error, etc:

* **Starts with Log Level**: Use this if each line starts with the level text.  Note that the expressions are case insensitive:

``` 
INFO   [9/1/15] This is an information line 
DEBUG  [9/1/15] This is a debug line 
```

* **Contains Log Level**: Use this if each line contains the log level but it is not at the start of the line:

``` 
[9/1/15] INFO This is an information line 
[9/1/15] DEBUG This is a debug line 
```

Note, these expressions can provide a false-positive because it searches the entire string.

* **None**: Turns off highlighting by clearing the color expressions.

#### File History
AdvancedTail saves a history of all files you have tailed.  This includes
saving the filters/trim expressions per file.  These settings are stored
in your users appdata folders ("%appdata%") allowing for multiple user
settings on servers or other shared systems.

#### 3rd Party Mentions
* [ScintillaNET](https://github.com/jacobslusser/ScintillaNET) to display the log.  This is the same control used by [Notepad++](https://notepad-plus-plus.org/).
* [Fody](https://github.com/Fody/Fody) used to embed DLLs in the EXE to make AdvancedTail a single executable file with no dependencies.
* [Silk Icons](http://www.famfamfam.com/) icons for the toolbar.

#### Known Issues and Limitations
* Cannot type into "File:" path textbox.
   * Work around is to use the "Open File..." menu item or button
   * Future release will allow the user to type in the file path
* Search is difficult to use when a file is rapidly changing.
   * May not fix, search is intended to be simple
   * Work around is to stop the tail then search.

Please enter any issues not listed above into the projects [GitHub issues section](https://github.com/gsirhc/AdvancedTail/issues).

### License
The code and executable are licensed under the [MIT License (MIT)](https://github.com/gsirhc/AdvancedTail/blob/master/LICENSE.txt)
