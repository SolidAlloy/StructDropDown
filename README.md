# Drop-down with objects of any type in Unity Inspector
Create drop-down lists that can contain objects of any type with one simple attribute (and a tiny helper struct).

## How to use
### Install via Git URL
Project supports Unity Package Manager. To install the project as a Git package, do the following:

1. In Unity, open **Window** -> **Package Manager**.
2. Press the **+** button, choose "**Add package from git URL...**"
3. Enter "https://github.com/SolidAlloy/StructDropDown.git#upm" and press **Add**.

### Add to project Assets
Alternatively, you can add the code directly to the project:

1. Clone the repo or download the latest release.
2. Add the StructDropDown folder to your Unity project.

### Use the DropDown attribute
1. Create a struct or class which will hold the choices of a drop-down list

   ![Struct](/Images/struct.png)
   
2. Add the DropDown attribute to a field and specify the struct to use for the drop-down list.

   ![Attribute](/Images/attribute.png)

3. You should now see a drop-down list with the choices from your struct.

   ![Result](/Images/result.png)

Credits
------------

- Code to handle target objects of serialized properties is taken from [SpacePuppy Unity Framework](https://github.com/lordofduct/spacepuppy-unity-framework-3.0)
- GitHub action to split the upm branch was created by [rfadeev](https://github.com/rfadeev)
