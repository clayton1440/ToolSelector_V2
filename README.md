ToolSelector V2
Designed for use at BAE Systems Inc (fka Ball Aerospace & Technologies)

ToolSelector allows users to efficiently manage their tooling, and easily add selected tools to a Shop Order operation. 
Users can link any number of Shared tool databases (residing on a network share, or otherwise selectable via File Explorer) to select from, as well as their own private database. 
Tools may be edited, and Calibration Dates can be added so that a warning displays if a user tries to select an expired tool. 
After individual tools are selected, users can export the selected tools to a CSV text file, which can then be uploaded to Velocity.

ToolSelector SL (Super-Light) is an extremely lightweight application that only loads one tool database at a time.
When opened without arguments, ToolSelector SL loads the tools from the User's private database.
When another database is double-clicked in explorer or TSSL is launced with the filepath as the first argument, only those tools are loaded.

ToolSelector exports a CSV file that Velocity (Delmia Operations Portal) can parse and apply to the operation. An example CSV export is below:
substituteflag|testid|notes|toolid|locationbuildingid|locationroomid
||Fluke 179 DMM|P147774||

ToolSelector_Setup is simply a packager that creates the .msi installer, as well as a setup.exe installer (that I have not tested).
The installer sets and modifies various keys in the Windows Registry, primarily for File Explorer context-menu entries. 
There are also registry entries for enabling URL Protocol, which allows ToolSelector_SL to be launched using the URL "ToolSelector:{FilePath}". A value is also added to MS Office 16.0 Trusted Protocols key to prevent the untrusted url warning.
The installer also creates shortcuts in the user's start menu, and optionally the desktop.

Build Instructions
- Build ToolSelector.Data (release profile) first
- Copy the folders "x86" and "x64" from "\ToolSelector.Data\bin\Release\" to the output directories of both ToolSelector and ToolSelector_SL, both debug and release.
- Build ToolSelector and ToolSelector_SL
- Modify ToolSelector_Setup properties by right clicking the project, click properties.
- Ensure Release configuration is selected, then build ToolSelector_Setup.

- ToolSelector relies on SQLite, an open-source, public domain SQL database engine. 
- ToolSelector_Setup requires the "Microsoft Visual Studio Installer Projects 2022" extension. You can exclude ToolSelector_Setup if you want to build an installer yourself.

Installation Instructions if ToolSelector Version 1 is installed:
- Before uninstalling ToolSelector v1, create a csv export that contains all tools in each database you want backed up. Each database should be exported separately. After each backup, rename the exported file or change the file name in the Options tab.
- Uninstall ToolSelector v1
- Install ToolSelector v2.1.4 or greater.
- In the Tool Management tab, click the 'Import File' button in the 'User Tools' group. In the open file dialog, switch the file extension filter in the lower-right to *.csv, then open the user's tool backup.
- In the 'Shared Tools' group, click the green Add button, then navigate to the desired location for the new shared tool file. Set the file name appropriately (extension must remain ".tsd", then click 'Save'. Repeat this step for each shared tool file to restore.
- In the list of shared tool filepaths, select the newly added database, then click 'Import File'. In the open file dialog, switch the file extension filter in the lower-right to *.csv, then open the related tool backup. Repeat this step foe each shared tool file to restore.
- Edit each tool database as required by clicking the appropriate 'Manual Edit' button.
