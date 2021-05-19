# Session
Library to keep an ad-hoc global session dictionary object.

Simple way to pass a global value within Xamarin forms screens, or other .netstandard2+ applications. 
Store primitive data ttpes and objects. Not intended to store very large objects.

```C#
using Lesniarasoft.Client;

// example set
Session.TrySet<string>("username", "john");
```

```C#
// example get
var sessionValue;
Session.TryGet<string>("username", out sessionValue);
```
