SpeedTest
===

* This project aims to create an easy method to perform benchmarking and A/B testing code samples.
* It has specifically been developed for use with Autodesk Inventor, but there is no real restriction against using it as a general code micro-benchmarking tool.
* The goal is to provide users with the option of using as a compiled .dll library file or a single coallated VB.Net file.  The user can include these in their projects to use the benchmarking class objects.
* The coallated VB.net file can also be used as a template file.  The user can add their own tests and run the file in inventor.

Basic Structure
---

This is an outline of the tool's primary class (this may change as the tool is developed more)...

* SpeedTest
  * New (String)
  * NewTimer(message, testMethod)
  * RunTests
  * ShowResultsInDialog
  * Results : String

non-user facing classes
* Timer
  * New: void
  * New(Message As String): void
  * Message: String
  * Results(): String  

TODO:

* Pass testing methods into the SpeedTest via delegates/similar