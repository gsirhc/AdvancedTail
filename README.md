# AdvancedTail
A lightweight .NET Windows program to follow changing text files and provides advanced filtering and formatting.

### Features at a Glance
* Tail any text-based file in a user-friendly GUI
* Advanced Filtering using regular expressions
* Advanced line trimming using regular expressions to enhance readability
* Lightweight/small footprint
* Demo mode to show how it works
* Simple text search

### System Requirements
* Windows 7 SP1 or higher
* .NET 4.5 or higher

### Install
1. Download the release executable from the [/AdvancedTail/Tail/bin/Release Folder](https://github.com/gsirhc/AdvancedTail/tree/master/Tail/bin/Release)
2. Place anywhere on your system and run.

### Features in Detail

![Main Form](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/main.png)

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

#### Known Issues and Limitations
* Large files (approaching 10K lines or more) can be slow to load initially if not filtering.
   * This only applies to opening the file, refreshing and enabling/disabling a filter or trim.
   * After the load, tail is not impacted by the file size.
   * Future release may allow users to sepcify how much of the file to load backward from the end (similar to "-n" in Linux's tail).
* Line numbers are embedded in the file display as regular text
   * Future release will display line numbers outside of the text area.
* Cannot type into "File:" path textbox.
   * Work around is to use the "Open File..." menu item or button
   * Future release will allow the user to type in the file path
* Search is difficult to use when a file is rapidly changing.
   * May not fix, search is intended to be simple
   * Work around is to stop the tail then search.

Please enter any issues not listed above into the projects [GitHub issues section](https://github.com/gsirhc/AdvancedTail/issues).