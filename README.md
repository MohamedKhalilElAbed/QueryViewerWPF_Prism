# QueryViewerWPF_Prism
Visual studio 2019, .NetCore 3.1, WPF.
ui automated tests using Katalan studio.
Before Launching  (2 Steps):
  1 - Edit requestConfigFile.json configuration file : it should contain query sql db queries or storedProcedure with their respective connectionstring. Value of "ColumnNames" should be null.
      C:\Users\Khalil\source\repos\QueryViewerWPF_Prism\Client.Application\bin\Release\netcoreapp3.1\A_Configs\requestConfigFile.json
      example :
      {
        "Description": "FirstQuery",
        "ConnectionString": "Data Source=(localdb)\\v11.0;Initial Catalog=TestDynamic;Integrated Security=True",
        "IsScript": true,
        "ColumnNames":null,
        "Script": "SELECT Name, nb FROM Users"
		  }
      or 
      {
        "Description": "ThirdQuery",
        "ConnectionString": "Data Source=(localdb)\\v11.0;Initial Catalog=SecondTestDynamic;Integrated Security=True",
        "IsScript": false,
        "ColumnNames": null,
        "Script": "computeInterestingProducts"
		  }
 2 - Set the value of configFile (requestConfigFile.json) to the json config file path in file :
      C:\Users\Khalil\source\repos\QueryViewerWPF_Prism\Client.Application\bin\Release\netcoreapp3.1\Client.Application.dll.config 
 
 To Launch the application :
 - Double click on Client.Application.exe file
     C:\Users\Khalil\source\repos\QueryViewerWPF_Prism\Client.Application\bin\Release\netcoreapp3.1\Client.Application.exe

For ui tests  (prerequesite for Katalan : Enable development features for Windows and install and launch WinAppDriver.exe):
 1- Install and open Katalon Studio.
 2- Menu > Open >Folder 
    C:\Users\Khalil\source\repos\QueryViewerWPF_Prism\QueryViewerTest
 3- Select a test in the list.
 4- Set the appFile parameter of the step "1-Start Application with Title" to the path of Client.Application.exe
  (default value is  C:\Users\Khalil\source\repos\QueryViewerWPF_Prism\Client.Application\bin\Release\netcoreapp3.1\Client.Application.exe)
 5- Set the keybord language of windows to Eng ( Querty)
 5- Run the test.
 

 
 

