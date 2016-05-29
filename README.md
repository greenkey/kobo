### Kobo

This repository is just a test.

The API documentation can be obtained using the XML Documentation Features (cfr. https://msdn.microsoft.com/en-us/library/b2s063f7.aspx).

The solution contains two projects: kobo and kobo.Tests.

The project Kobo contains one .cs file containing two classes:
- ISBNUtils, the actual code
- MainClass, with the Main method, used to test the ProductID_2_ISBN10 from command line.

The project kobo.Tests contains the UnitTest.

## ISBNUtils

The class has only one public method to convert a 12-digit ProductID to a ISBN-10 number.
