# Easy Wheel Replace
A small tool written in c# to automate the process of swapping rim model files for Forza Horizon 5

# How to use:
Download the tool from releases or build yourself.

After opening click on "Select Game Location" and select any file inside the root game folder with the .exe inside. (for people on microsoft store who have file access you need to choose any file other than the main game .exe)

Select your Wanted Wheels from the dropdown menu. These will be the wheels you want to use.

Select your Target Wheels from the second dropdown menu. These will be the wheels which get replaced by the "Wanted Wheels"

Press "Replace Wheels" and wait until the button is enabled again. After this you can launch the game and the wheels will be changed.

The tool will back up the target wheel zip into your documents at `Documents\EasyWheelSwapper\OriginalWheelBackup\` if you need to roll the wheel back to its original


# Requirements
Honestly I have no idea. Its just .NET 7 so whatever that needs I guess.

# Known issues

Minimal checks are done for textures in textures.zip or textures_pri_45.zip. It only uses the first file.

Materials are currently ignored.

# TODO

Add more options like a custom backup location and if the user wants the front or rear car wheel if the car has two.

