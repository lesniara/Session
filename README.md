# Session
Library to keep an ad-hoc global session dictionary object.

Simple way to pass a global value within Xamarin forms screens, or other .netstandard2+ applications. 
Store primitive data types and objects; not intended to store very large objects.

```C#
using Lesniarasoft.Client;

// example set
Session.TrySet<string>("username", "john");

// example get
var sessionValue;
Session.TryGet<string>("username", out sessionValue);

// access the backing object
var firstStringKey = Session.Bag.Keys.First();
```
