# Restaurant Order project with DDD pattern exampleand Angular SPA

Simple project to use DDD pattern at the backend and Angular as the frontend application.

 Features used:
  - Angular 9
  - Serilog for logging errors
  - EF Core for ORM
  - Swagger for api docs
  - SQL Server database

## Installation .Net Core Api

Install .Net Core version 3.1 on your computer

Download or clone the project 

*Note: Make sure that you have the SQL Server Instance installed on your local machine, or change the "appsettings.json" file on the "Infra" and "Api" projects to point to your SQL Server host.*

Open the project on VS Code or Visual Studio 2019

Use Nuget Package Manager Console

```bash
dotnet restore
dotnet run or press F5 on the Restaurant.Api project
```

Open the browser on http://localhost:5000

*Note: If the project don't run with bash "dotnet run", check if the path of the Package Manager Console 
is pointing to the Restaurant.Api project. 
And check also if the Restaurant.Api project is the default startup project
If you are using VS Code remember to install the C# extension.*

## Installation Angular Project

Install Node.js latest stable version on your computer

Open the 'Node.js command prompt' console and run the following commands

```bash
npm install -g @angular/cli@9.1.11
```

Download or clone the project 

*Note: Make sure that you have the Angular CLI version listed above installed or the project will not run.*

Open the project folder on VS Code

Use VS code terminal or open 'Node.js command prompt', make sure you are at the 'restaurant-angular' folder and run the following commands

```bash
npm install
ng serve
```

Open the browser on http://localhost:4200/

*Note: If the project don't run with bash "ng serve", check if the path of the command prompt is pointing to the 'restaurant-angular' folder listed above. And if the Angular CLI is installed using the command ng --version.*

## Usage

Run .Net Core Api project
 - When you run the project the database will be automatically created with EF Core migrations.   
 - Open swagger with url http://localhost:5000/swagger/index.html
Run the Angular project
 - Open the browser on http://localhost:4200/ and have fun!

## Rules for Order meals

1. You must enter time of meal as “morning” or “night” followed by ","
2. You must enter a comma delimited list of dish types with at least one selection (Dishes ids are listed on the website)
3. The output print is ordered as following: Entrée, Side, Drink, Dessert
4. There is no dessert for morning meals
5. Input is not case sensitive
6. If invalid selection is encountered, valid selections will be displayed up to the error, then "error" will be printed
7. In the morning, you can order multiple cups of Coffee
8. At night, you can have multiple orders of Potatoes
9. Except for the above rules, you can only order 1 of each dish type

<b>Input example:</b> morning, 1, 2, 3 
<b>Ouput example:</b>  eggs, toast, coffee

## Contributing

Pull requests are welcome. 
Feel free to use and send me improvements.

## Licensed
[MIT](https://choosealicense.com/licenses/mit/)
