# AdvancedTail
.NET Windows executable to follow changing text files and allows for advanced filtering and formatting.

### Features at a Glance
* Tail any text-based file
* Advanced Filtering using regular expressions
* Advanced line trimming with regular expressions
* Lightweight to minimize CPU and memory usage
* Demo mode to show how it works
* Simple text search

### System Requirements
* Windows 7 SP1 or higher
* .NET 4.5 (pre-installed with Windows 8)

### Install
1. Download the release EXE from the [/AdvancedTail/Tail/bin/Release Folder](https://github.com/gsirhc/AdvancedTail/tree/master/Tail/bin/Release)
2. Place anywhere on your system and run.

### Features in Detail

#### Tailing
AdvancedTail follows files as efficiently as possible.  It works by saving the last position
it read to in the file so that if changes are detected, it picks up from that point to read
to the end.  This reducing CPU and disk usage.

##### Line Numbers
Line numbers can be displayed if desired.  When filtering, the original line numbers are
maintained.

#### Filtering
AdvanceTail provides a filting engine to remove lines from the displayed text based on regular expressions.
Though regex is a scarely/complex search language, it easily provides all the filtering capabilties
you'd expect.

##### How does filter work?
Lets say you the following log file:

'''
[7:10:01pm] This is a test log line
[7:10:02pm] We want to see this line because it rocks
[7:10:03pm] And we want to see this line because it rules
[7:10:04pm] But not this line
'''

If you want to filter out the lines you don't want see, you could create a filter like this:

''' "to see" '''

AdvancedTail would display:

'''
[7:10:02pm] We want to see this line
[7:10:03pm] And we want to see this line
'''

So regex filters can be simple text.  You can even OR text like '''"rules|rocks"'''.

#### Trimming
AdvancedTail also allows you to trim lines based on regular expressions.  This is useful
if you want to remove common text from the lines to make it easier to see whats going on.
The trimming feature provides to types:

* Trim To: Trims from the beginning of the line to the first character of the match
* Trim From: Trims from the first character of the match to the end.

##### How does trimming work?
Lets say you this log file again:

'''
[7:10:02pm] We want to see this line because it rocks
[7:10:03pm] And we want to see this line because it rules
'''

If you want to only see the "to see" part of the lines you'd create a trim expression like this:

''' trim to: "to see" '''
''' trim from: "this" '''

AdvancedTail would display:

'''
to see 
to see
'''

#### Known Issues and Limitations
* Loading large files (approaching 10K lines or more) can be slow initially if not filtering
   * Future release may implement a "-n" feature similar to Linux tail to allow user to sepcify how much of the file to load.
* Line numbers are embedded in the file display as regular text
   * Future release will display line numbers outside of the text area.
* Cannot type into "File:" path textbox.
   * Future release will allow the user to type in the file path
* Search is difficult to use when file is rapidly changing.
   * May not fix, search is intended to be simple
   * Work around is to stop the tail then search.

Please enter any issues not listed above into the Github project issues.