# DyeAndDurhamOA

## Purpose
This command line tool sorts a list of names by last name, then first and given names. 

## Usage
DyeAndDurhamOANameSorter.exe .\unsorted.txt

Note that the input file should have a pattern similar to the following:
```
Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Leo Gardner
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter
```
The sorted result will be outputted to a file called `sorted-names-list.txt`, and also printed to the console. 

## Design Decisions for Demonstrating SOLID
### Single-responsibility principle
The `Name` class only handles comparison and output format of a name. 
The `NameSorter` class only handles sorting Name instances. 
The driver code only handles program input and passing it to the helper function for converting string into a List<IName>. 
### Open–closed principle
`Name` implements the `IName` interface. Not quite the same thing, but there weren't many ways to add in class based inheritance. 
### Liskov substitution principle
`NameSorter` only uses the `IName` interface when calling methods from `Name`. 
### Interface segregation principle
`IName` has exactly one member: a property for displaying and storing a string which represents the full name of the individual. `IName` also inherits `IComparable`, which `Name` uses for when it is being sorted.
### Dependency inversion principle
`NameSorter` is designed to sort `Name` objects, but I made it sort on objects that implement the `IName` interface instead in order to decouple them. 

## Build Pipeline
AppVeyor is set up and running (using `nuget restore` command for making visual studrio work was quite obscure), though I am not sure how to show that visually. It automatically builds and runs the unit tests. 

## Folder Guide
`DyeAndDurhamOANameSorter` is the main program's source code.
`DyeAndDurhamOANameSorterTests` are the unit tests.

## API quick reference
### Name
Primary responsibility: Enabling comparison between names. 
Property: FullName
Constructors: `Name()`, `Name(string FullName)`
Methods (interface): `CompareTo(obj)`

`Name(string FullName)` initializes the name with the string. Otherwise use the property to change the name.

### NameSorter
Primary responsibility: Sorting Name objects.
Constructors: `NameSorter()`, `NameSorter(List<IName> names)`
Methods: `Add(IName name)`, `Replace(List<IName> names)`, `GetSortedString(string delimiter)`, `Clear()`

`NameSorter(List<IName> names)` and `Replace(List<IName> names)` initialize and replace the entire list respectively. 
`GetSortedString(string delimiter)` calls sort on the list (correct sorting order handled by `Name` class) and outputs all the names separated by the delimiter.

### Program
Primary responsibility: driver code. Handle the input parameter, and other system I/O matters.
Functions: `HelperStringToINameList(string stringBlockNames, string delimiter)`

`HelperStringToINameList(string stringBlockNames, string delimiter)` takes a large string, splits it into chunks, then inserts them into a `List<IName>` which is then returned.

## Closing remark
I had considered turning the `Program` class's helper function into a proper class, but doing so would require a way for another class to produce `Name` instances. This is possible to achieve while adhering to SOLID, using the Factory pattern, but I found that it reduced the readability of the code by too much. 
