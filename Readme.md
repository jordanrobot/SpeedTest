SpeedTest
===

* This project aims to create an easy method to perform benchmarking and A/B testing code samples.
* It has specifically been developed for use with Autodesk Inventor, but there is no real restriction against using it as a general code micro-benchmarking tool.
* The goal is to provide users with the option of using as a compiled .dll library file or a single coallated VB.Net file.  The user can include these in their projects to use the benchmarking class objects.
* The coallated VB.net file can also be used as a template file.  The user can add their own tests and run the file in inventor.

SpeedTest Class
---

This is an outline of the tool's primary class (this may change as the tool is developed more)...

* SpeedTest
  * New (String) : Creates a new SpeedTest object.
  * AddTest (message, Subroutine) : adds a test into the testing queue.
  * RunTests : runs the tests
  * ShowResultsInDialog : shows the users a dialog with the execution times.
  * GetResults : returns a string with the execution times.

How to Use
---

* Please refer to the HowToUse.vb file for an example of how to utilize this library.
* Add a reference to the SpeedTests.dll or use the SpeedTest template.iLogicVB file as the template for your speed tests.

Builds
---

* You can find the iLogicVb (template file here)[/builds/SpeedTest Template.iLogicVb].  Download and modify the code in main and the called functions TestOne and TestTwo.  You can add new tests, delete them, etc.
* A new .dll build will be placed in the /builds/ folder at some point.
