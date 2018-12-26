# KyberCatalog

A sample MVC project using EF and Asp.Net Core 2.1.

## Some applied rules in the Project

1. Attribute name from Kyber entity is unique;
2. Is only possible to search data by 'name' and 'color' through the filter in index page;
3. The solution has a validation before entity registration. If you try to register a new data with an existent name, you'll be informed;
4. The same as item 3 occurs when you try to edit an entity and put an existent name.

## Documentation

- Some Entity Framework I've used to manage migration and database:

 - Creating Migration:
 
 ![Migration](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/EF_Console_Commands/EF_Core_Migrations.png)
 
 > The red arrow above indicates a workaround I've made in order to let the Entity Framework visualize the project and execute the console commands.
 
 - Creating Database:
 
 ![Create Database](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/EF_Console_Commands/EF_Core_Update_Database.png)
 
 - Remove Migration:
 
 ![Remove Migration](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/EF_Console_Commands/EF_Core_Remove_Migration.png)
  
 - Drop Database:
 
 ![Drop Database](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/EF_Console_Commands/EF_Core_Drop_Datbase.png)
 
## Mockup Screens

- Here are some mockup screens I've made before starting this mini project. These mockups helped me to think about the view structures and also the solution architecture before spitting code.

- Special thanks to :link:[Balsamiq][1] Company and its tool. It's simply amazing!

- Index Page:

![Index Page](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/Mockups/01_Homepage.png)

[1]: https://balsamiq.com/ "Company Website"

- Registration Page:

![Registration Page](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/Mockups/02_Registration.png)

- Edition Page:

![Edition Page](https://github.com/nmaia/KyberCatalog/blob/master/Docs/Images/Mockups/03_Edition.png)
