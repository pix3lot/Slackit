## Slackit
Slackit is a plugin developed for Revit that enables the software to communicate with team members via Slack. This allows the model to alert users if something goes awry and giving a programmable interface for model management and maintenance. 

## Installation
For easy installation download the zip file for your Revit version. Unzip the contents into the appropriate Revit addin location:
`C:\ProgramData\Autodesk\Revit\Addins\[YEAR]`

## Usage
Run the plugin and enter the token to your Slack site. Select the Slack channel you want the Revit model to post to and save the settings. Sync with central and watch the fun. 

## Current function
Messages are sent to a specified channel (no groups or DMs yet)

Random gifs (via Giphy) are embedded into the messages by keywords search.
GIF can be large, small, or turned off

Messages included so far:
* Synch to Central started
* Synch to Central completed
* Central model was opened
* User closed the file without synching to central
* File Size is > 300MB
* Pinned Element Tracking

Screenshot button sends full screenshot to project channel

## Future development

Misc
  * Include groups and DMs
  * Post messages to/from Revit ribbon
  * Attach to database to track project file health long term
  * OAuth instead of token

More messaging options 
  * Open/sync takes too long
  * Audit type issues (revit warnings & errors, non-standard practices)
  * Imported DWG files
