# Dye and Durham OA - Name Sorter

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
The `IName` interface implementers, such as `NameLastFirsts`, only handles storage, comparison, and output format of a name. 

The `INameSorter` interface implementers, such as `NameSorterDefault`, only handles tasks necessary for sorting Name instances. 

The `INameFactory` interface implementers, such as `NameLastFirstsFactory`, only handles generating `IName` instances. 

`NameSerializer` and `NameDeserializer` only handles serializing and deserializing names respectively.

The `Program` driver code only handles input and output from the files and console. The processing of the data is delegated to the other classes. 
### Open–closed principle
Each of the concrete classes - `NameLastFirsts`, `NameLastFirstsFactory`, and `NameSorterDefault` - are designed to handle one specific scenario. Due to the interface limiting what methods are known to the callers, adding functionality by modifying them is not feasible. Instead, new classes that implement their respective interfaces are the intended way of doing things. 

`NameSerializer` and `NameDeserializer` have private constructors rather than being static classes in order to allow inheritance. 
### Liskov substitution principle
All concrete classes that implement an interface perform the implementation in a way that aligns with the intent of the interface. Meaning no class will get unexpected results from casting the concrete objects as their more abstract interfaces. 
### Interface segregation principle
`IName` has exactly one member: a property for displaying and storing a string which represents the full name of the individual. `IName` also inherits `IComparable`, which `Name` uses for when it is being sorted. All implementers of `IName` use all parts of the interface. 

`INameFactory` has two methods. One for producing a name with a default constructor, and another for a string constructor. While this program does not use the default constructor version, it is appropriate for factory instances to be able to produce it.

`INameSorter` has four methods for manipulating what items are to be sorted, and another method for outputting the result. The interface assumes that an `ICollection` storage solution is used within the concrete sorter, which is why the four manipulation methods mirror the ones in the `ICollection` interface. Output is necessary for showing the result.
### Dependency inversion principle
With one exception, all concrete classes refer to interfaces rather than other concrete classes. No interface references a concrete class as they only reference each other. 
The exception mentioned is the factory pattern's concrete factory. However that is a low level class referencing another low level class, thus it does not violate DIP. 

A few examples: `INameFactory` produces `IName` objects, `INameSorter` takes `IName` and `ICollection<IName>` as opposed to `List<IName>`.

## Extension Guideline

For adding new ways to order names, such as ignoring prefix and suffix titles when sorting, add a class that implements `IName` and add its corresponding factory. 

For adding new ways to sort, such as ensuring the first ten names are sorted among themselves separately from the rest, add a class that implements `INameSorter`. 

For more non-standard ways of deserializing input or serializing for output, extend `NameDeserializer` and `NameSerializer` respectively.

## Build Pipeline
AppVeyor is set up and running (using `nuget restore` command for making visual studio work). It automatically builds the program and runs the unit tests. 

## Folder Guide
`DyeAndDurhamOANameSorter` is the main program's source code.
`DyeAndDurhamOANameSorterTests` are the unit tests.

# API quick reference
## IName
Interface for representing a name, including comparison between names. 

### Interfaces
`IComparable`
- For comparison between names.

### Property
`FullName`: String
- Set and return the full name being represented.

## INameFactory
Interface for name factories.

### Methods
`ProduceName()`
- Produces a name.
- *Returns:* IName object.

`ProduceName(string fullName)`
- Produces a name initialized with the passed string.
- *Parameters*: fullName serialized in string form, delimited by space.
- *Returns*: IName object instanciated with the string constructor.

## INameSorter
Interface for name sorters.

### Methods

`Add(IName name)`
- Insert an IName object into the NameSorter.
- *Parameters*: IName object to be sorted.

`Remove(IName name)`
- Removes specified IName object. Note that it must be the same object rather than the same contents.
- *Parameters*: IName object to be removed

`Clear()`
- Empties the NameSorter of all INames. 

`Replace(ICollection<IName> names)`
- Replaces the current collection of names with the given set.
- *Parameters*: an object that implements ICollection, and stores INames.

`GetResult()`
- Returns the sorted list of names.
- *Returns*: ICollection of sorted names.

## NameLastFirsts
Concrete IName. Orders names based on last name, then all first names.

### Interfaces
`IName`

### Fields
`fullName`: string
- Stores the full name.
- *Access modifier*: private

`firstNames`: List<string>
- Stores first names sequentially.
- *Access modifier*: private

`lastName`: string
- Stores the last name.
- *Access modifier*: private

### Property
`FullName`: String
- Implements IName. 
- *set*: calls this.SetFullName(value)

### Constructors
`Name()`
- Initializes with an empty fullName, empty list for firstNames, and empty lastName. 

`Name(string fullName)`
- Initializes by calling this.SetFullName(fullName).
- *Parameters*: string representing the full name.

### Methods: 
`SetFullName(string newFullName)`
- If the input is null, then set fullName to empty, empty firstNames list, and set lastName to empty. 
- Otherwise set fullName to newFullName, and split newFullName using space as delimiter while removing empty entries. The last entry goes in lastName, while the rest are made into a list and stored in firstNames.
- *Parameters*: string representing the full name.

`CompareTo(obj)`
- String comparison using Last names first. If they are equal, then string comparison on each first name. Empty first name go to the bottom.
- *Parameters*: IName object.

## NameLastFirstsFactory
Concrete INameFactory. Produces concrete NameLastFirsts objects.

### Methods
`ProduceName()`
- Implements interface. Produces NameLastFirsts object.

`ProduceName(string fullName)`
- Implements interface. Produces NameLastFirsts object.

## NameSorterDefault
Concrete INameSorter. Uses the default List.Sort() to sort.

### Interfaces
`INameSorter`

### Fields
`names`: List<IName>
- Stores INames to be sorted using a list.

### Constructors
`NameSorterDefault()`
- Initializes with an empty list.

`NameSorterDefault(ICollection<IName> names)`
- Initializes list using ICollection. 
- *Parameters*: ICollection containing INames.

### Methods
`Add(IName name)`
- Implements interface.

`Remove(IName name)`
- Implements interface.

`Replace(ICollection<IName> names)`
- Implements interface.

`GetResult()`
- Implements interface. Default list sorting happens during this call.

`Clear()`
- Implements interface.

## NameSerializer
- Utility functions for performing IName to string serialization. 

### Constructor
`NameSerializer()`
- Does not allow instanciation. 
- *Access modifier*: private

### Static functions
`INameToString(IName? name)`
- Returns the IName in string form using its FullName property. Returns the empty string if IName is null.
- *Parameters*: IName object to be serialized. Nullable.
- *Returns*: String representing the IName.

`INameICollectionToStringBlock(string delimiter, ICollection<IName> names)`
- Returns all of the INames in a single string, delimited by the delimiter. 
- *Parameters*: string delimiter for separating the names. ICollection containing the INames to be serialized.
- *Returns*: string block containing all INames in a string.

## NameDeserializer
Utility functions for performing string to IName deserialization. 

### Constructor
`NameDeserializer()`
- Does not allow instanciation. 
- *Access modifier*: private

### Static functions
`SingleStringNameToIName(string fullName, INameFactory nameProducer)`
- Function that produces a name from a string given a factory.
- *Parameters*: string of a single name. Factory instance of the needed concrete name.
- *Returns*: result of the factory cast as IName.

`BlockStringNameToIName(string fullNameBlock, string delimiter, INameFactory nameProducer, ICollection<IName> nameCollection)`
- Function that parses a string of names delimited by a character, produces INames from the factory, and inserts the result into the ICollection. White space names are ignored.
- *Parameters*: string of names delimited by the specified character. string that delimits the names in the previous parameter. Factory instance of the needed concrete name. ICollection instance for storing the INames. 
- *Returns*: ICollection instance filled with INames.


## Program
Driver code. Handle the input parameter, and other system I/O matters.

`Main(string[] args)`
- Console app.
- *Parameters*: args[0] is the file path to the unsorted list of names.

# Closing remark

A few words on some design decisions I made.

## Interface vs abstract classes
This solution did not use any abstract classes. There is a reason for this.

At a high level, the difference between an interface and an abstract class is that an interface defines ways of interacting with classes that implement it, while an abstract class provides common members that its children inherit for reducing code duplication. Abstract classes can mimic the functionality of an interface by declaring all of its members as abstract. 

With this in mind, the only concrete classes that I have which might share implementations with all other variants is the `IName` implementers. Specifically the `NameLastFirsts`'s `get()` accessor on the `FullName` property. But because the `set()` assessor varies depending on the storage solution, making `IName` an abstract class does not end up reducing duplicate code by much.

For this reason, my solution does not use abstract classes.
## Creation pattern for IName on NameDeserialize
There were three good options for generating `IName` instances within the `NameDeserialize` class without violating DIP: prototype pattern, factory method pattern, dependency injection, and abstract factory pattern. 

Giving `IName` a clone method would allow production of `IName` objects as long as a prototype is passed to NameDeserialize. However `NameLastFirsts` would need to be a deep copy clone due to the use of strings and a list, which removes the resource advantage of this pattern. In addition, in order to adhere to OCP this method is best done by extending the `IName` interface with INamePrototype. Combine the two conditions, and it ends up being closer to a factory method rather than prototype. 

Factory method pattern lacks a good candidate for implementing it into. Producing `IName` is not sufficiently related to representing names, thus putting it there would violate SRP. 

Dependency injection works. Pass a lambda function that produces a concrete `IName` instance into `NameDeserialize`, and it will work. The problem is that it is more difficult to handle error checking since the client needs to write the lamdba function, and the readability and writability are hindered. 

Abstract factory pattern introduces a concrete class that depends on a concrete class that implements `IName`. It also forces an additional class to be created when adding more Name types, as each `IName` implementation needs their corresponding factory.

I ended up going with the abstract factory pattern. The final contenders were the prototype pattern and the abstract factory, with the tie breaker being the abstract factory more closely resembling its intended form. This makes it easier for future maintainers to recognize the pattern, which improves readability. 
