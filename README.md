## Slackit
Slackit is a plugin developed for Revit (Rhino(TDB)) that enables the software to communicate with team members via Slack. This allows the model to alert users if something goes awry and giving a programmable interface for model management and maintenance. 

##Installation
The plugin can be used as is by copying the dll contents of the SlackitRevit/bin/debug and the contents of the SlackitRevit/Resources folder to C:\ProgramData\Autodesk\Revit\Addins\2015 

##Usage
Run the plugin and enter the token to your Slack site. Select the Slack channel you want the Revit model to post to and save the settings. Sync with central and watch the fun. 

##Current function
Messages are sent to a specified channel (no groups or DMs yet)

Random gifs (via Giphy) are embedded into the messages by keywords search

Messages included so far:
* Synch to Central started
* Synch to Central completed
* Central model was opened
* User closed the file without synching to central

##Future development
Include groups and DMs

Add screen capture and post utility (current one doesn't work yet)

Ability to post messages built into the Revit ribbon

More messaging options 
  * File size
  * Open/sync takes too long
  * Audit type issues (revit warnings & errors, non-standard practices)
