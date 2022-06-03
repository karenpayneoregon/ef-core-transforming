# About

Two forum questions

**Forum question 1**: [String not converting to datetime](https://stackoverflow.com/questions/72474717/string-not-converting-to-datetime/72488079#72488079)

**My suggestion**

*Have you considered asking the DBA to change the format for the column in the database?*

```sql
declare @date datetime = '05-31-2022 11:00:00'
select FORMAT(@date,'MM/dd/yyyy hh:mm:s tt')
```

**Otherwise**

```csharp
var value = "31/5/2022 11:00:00 a. m.";
DateTimeFormatInfo formatInfo = new () { AMDesignator = "a. m.", PMDesignator = "p. m." };
var dateTime = DateTime.ParseExact(value, "dd/M/yyyy hh:mm:ss tt", formatInfo);
Console.WriteLine(value);
Console.WriteLine(dateTime);
```

***Other recommendation from another person***

There is no built-in functionality for your "a. m. or p. m.", but you can try doing something like this because it is really specific format you have("AM" or "PM" in the end are supported by .NET platform):

```csharp
string testStr = "31/5/2022 11:00:00 a. m.".Replace("a. m.","AM").Replace("p. m.", "PM");
string formatToParse = "d/M/yyyy h:mm:ss tt";
var res = DateTime.ParseExact(testStr , formatToParse, CultureInfo.InvariantCulture);
```




# What is learned here

To first understand what methods and other classes are available for string to date conversions then work through the problem.

The solution is simple (going back to knowind what is available), set `AMDesignator` and `PMDesignator` to match the incoming string to represent a date. What seems logical is not handle this in code if possible and ask the person generating the SQL to use `FORMAT(@date,'MM/dd/yyyy hh:mm:s tt')`

In the end a database solution is always better when possible.


**Forum question 2**

How to zip my Visual Studio solution

```xml
<Project Sdk="Microsoft.NET.Sdk" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">

   <Target Name="ZipOutputPath" AfterTargets="Build">
      <Message Text="Creating .zip for $(SolutionDir)" Importance="High" />
      <ZipDirectory
         SourceDirectory="$(SolutionDir)"
         DestinationFile="C:\OED\Zipped\output.zip"
            Overwrite ="true"/>
   </Target>

   <Target Name="CreateDirectories">
      <MakeDir Directories="C:\OED\Zipped"/>
   </Target>
</Project>
```
