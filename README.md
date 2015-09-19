# AdvancedTail
A lightweight .NET Windows program to follow changing text files with advanced filtering and formatting.

* Tail text-based files or Windows Event Logs in a user-friendly GUI
* Advanced filtering using regular expressions
* Advanced line trimming using regular expressions to enhance readability
* Line highlighting
* Lightweight/small footprint
* Simple text search
* Can run multiple instances to tail several logs at once
* Demo mode to show how it works

### System Requirements
* Windows 7 SP1 or higher
* .NET 4.6 or higher

### Install
1. Download the release executable from the [/AdvancedTail/Tail/bin/Release](https://github.com/gsirhc/AdvancedTail/raw/master/Tail/bin/Release/Tail.exe) Folder
2. Place anywhere on your system and run.

### Downloading Source
You are of course welcome to download the source.  AdvancedTail source was written using 
Visual Studio 2015 Community Edition.  With Visual Studio installed, simply open the Tail.sln file.
There are a few Nuget packages to download which Visual Studio should do automatically.

### Features in Detail

![Main Form](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/main4.png)

#### Filtering
AdvancedTail provides a filtering engine to remove lines from the displayed text using regular expressions.
Though regex is a scary/complex search language, it easily provides all the filtering capabilties
you'd expect and the expressions can be simple (see below for an example).

![Filter Configuration Form](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/filter3.png)

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

``` to see ```

AdvancedTail will display:

```
[7:10:02pm] We want to see this line because it rocks
[7:10:04pm] And we want to see this line because it rules
```

You can also OR filters like ```rules|rocks``` to display the same lines.

##### Predefined Filters
Predefined filters are available in the Filter Configuration form.  There you can find many options
for filtering, trimming and highlighting tailed files.  Simple click the Configuration to populate
the applicable fields, adjust as needed and click Ok.

![Predefined Configuration](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/predefined.png)

You can also save configurations to apply to other files by clicking the Save button.  Your saved
configuration will be displayed in the "Saved Filters" group.

![User Saved Filters](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/userDefined.png)

#### Trimming
AdvancedTail also provides a mechanism to trim lines based on regular expressions.  This is useful
if you want to remove common text from the lines to make them easier to read.

##### How does trimming work?

The trimming feature provides 3 types of trims:
* Trim To: Trims from the beginning of the line to the first character of the match
* Trim From: Trims from the first character of the match to the end on the line.
* Trim Middle: Trims from the start of the first regex group to the end of the last regex group.  Note that the regular expression must yield at least 2 groups on a match.  

NOTE: If using more then 1 trim type, the order of operations starts with the To, then applies the From, followed by the Middle trim.

###### Trim To/Trim From

Lets say you this log file:

```
[7:10:02pm] We like this line because it rocks and rolls
[7:10:04pm] And we like this line because it rules and rolls
```

To trim off the common parts of the lines:

``` 
trim to: it
trim from: and rolls
```

AdvancedTail will display:

```
it rocks
it rules
```

Or you can be more specific with the "To":  ```trim to: "it rules|it rocks"```

###### Trim Middle

Now lets say you want to remove the "We like this line because " portion of the lines but keep the time:

```
[7:10:02pm] We like this line because it rocks and rolls
[7:10:04pm] And we like this line because it rules and rolls
```

Here you'd use Trim Middle (note the case-insensitive modifier ```(?i)``` to capture 'We' and 'we' and the space after because):

``` 
trim middle: (?i)(We like this line because )
```

AdvancedTail will display:

```
[7:10:02pm] it rocks and rolls
[7:10:04pm] And it rules and rolls
```

NOTE: Even though Trim Middle requires regex grouping, you can trim specific text by simply wrapping the text in parenthesis:

``` 
trim middle: (any text here)
```

#### Line Highlighting
AdvanvedTail provides separate regular expressions to define how lines are
highlighted in the display.  You can define up to 6 color expressions red, yellow, green, blue, gray and subtle (grayed text).  
The highlighting works by testing each color regular expressions on a given line.  The first match determines the color the line is displayed in.
Additionally, highlighting can be toggled on and off in real time.

![Highlight Configuration](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/highlight.png)

#### Windows Event Logs
AdvancedTail allows you to tail the most commonly used Windows Event Logs by converting them to
text and displaying the logs like a file.  This allows you to apply filters, trimming and
highlighting.  The logs will update in real time as events are added.

![Windows Logs Menu](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/windowslogs.png)

Since AdvancedTail formats the event logs, predefined filter configurations are provided to
help you filter, trim and highlight the events.

![Windows Logs Filter Configurations](https://raw.githubusercontent.com/gsirhc/AdvancedTail/master/screenshots/windowslogconfig.png)

#### 3rd Party Mentions
* [ScintillaNET](https://github.com/jacobslusser/ScintillaNET) to display the log.  This is the same control used by [Notepad++](https://notepad-plus-plus.org/).
* [Fody](https://github.com/Fody/Fody) used to embed DLLs in the EXE to make AdvancedTail a single executable file with no dependencies.
* [Silk Icons](http://www.famfamfam.com/) for the toolbar.

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
