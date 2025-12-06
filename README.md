## ITCS 3112 Project Overview
This is an inventory system that helps users manage character's inventory for a game. It can create items and characters and add items to a selected character.

## Build & Run Instructions
The tools used for this project is .NET 10, Visual Studio 2026, and Entity Framework Core 10.
If you download the project you should be able to run it on Visual Studio 2026. This project uses a dll file called StarReverieCore. You need to download the source code from the submission or decompile it in order to view it. 

## Required OOP Features (with File & Line References)
| OOP Feature  | File Name(s) | Line Numbers | Reasoning / Purpose |
| ------------- | ------------- | ------------- | ------------- |
| Inheritance Example  | ArmorModel.cs  | Line 10  | ArmorModel inherits from the Unit abstract class to share common attributes and behavior.  |
| Inheritance Example  | WeaponModel.cs  | Line 10  | WeaponModel inherits from the Unit abstract class to share common attributes and behavior.  |
| Inheritance Example  | ShieldModel.cs  | Line 10  | ShieldModel inherits from the Unit abstract class to share common attributes and behavior.  |
| Inheritance Example  | AmmoModel.cs  | Line 10  | AmmoModel inherits from the Unit abstract class to share common attributes and behavior.  |
| Interface Implementation  | ICreate.cs  | All | Defines a contract for the SaveButton_Click Method. Implemented by multiple classes.  |
| Interface Implementation  | IDetails.cs  | All | Defines a contract for SaveButton_Click, DeleteButton_Click, and ExitButton_Click Method. Implemented by multiple classes.  |
| Interface Implementation  | IText.cs  | All | Defines a contract for SetText Method. Implemented by InventoryControl and ItemControl.  |
| Access Modifiers  | All Model classes  | All | All Model classes and their properties are public   |
| Access Modifiers  | Enum classes  | All | All Enum classes are public   |
| Access Modifiers  | MainWindow.xaml.cs  | All | The class itself it public while all of its methods are private   |
| Access Modifiers  | InputValidator.cs  | All | The class and its properties are public  |
| Access Modifiers  | DisplayItemsWindow.xaml.cs  | Line 26-30 | The Class properties are set to private  |
| Access Modifiers  | DisplayItemsWindow.xaml.cs  | Line 56-123 | These Class methods are set to public  |
| Access Modifiers  | DisplayItemsWindow.xaml.cs  | Line 125-199 | These Class methods are set to private  |
| Enum example  | ItemType.cs  | All | This enum is used throughout the project  |
| Data Structure example  | MainWindow.xaml.cs  | Line 23 | This list contains all of the characters from a database. It uses the Character class model from StarReverieCore |

## Design Patterns (with File & Line References)
| Pattern Name  | Category | File Name(s) | Line Numbers | Reasoning / Purpose |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| Singleton     | Creational     |  InputValidator.cs | All | Allow input validation throughout the project. |
| Strategy     | Behavioral     |  DisplayItemsWindow.xaml.cs | Lines 30-52 and Lines 136-137 | Behaviors are isolated in strategy classes and follows SRP |
