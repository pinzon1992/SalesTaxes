# Code Assessment
The selected exercise to solve was: Problem two - **Sales Taxes**

**Example 1:**

INPUT 1
1 Book at 12.49
1 Book at 12.49
1 Music CD at 14.99
1 Chocolate bar at 0.85

OUTPUT 1
Book: 24.98 (2 @ 12.49)
Music CD: 16.49
Chocolate bar: 0.85
Sales Taxes: 1.50
Total: 42.32


# Solution

To solve the exercise proposed C# .NET 6 has been used, below are explained some of requirements to run the console application and implemented solution.

## Requirements

To run the console app on any OS(windows, linux, mac) is necesary have installed .NET 6 sdk, available in https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Architecture

The input format for the information to be processed, are a txt and json files.

**TXT file:** Contains the differents input scenarios

**JSON file:** Contains product types with product names associated, for make the rules to apply different taxes on the products.

To solve the proposed exercise DDD has been used, after analizing the input format, we can observe that three Domain entities exists: Product, ProductTypes and Tax, these entities are part of Domain Layer,  to work with this entities Repository Pattern also has been used on the Infrastucture Layer, to work with business logic an Application Layer has been used.
Dependecy injection and some data structures as been used to solve the proposed code assessment.
Finally, Tests with xUnit also has been used to check the correct execution of the application with different escenarios.

## Metodology

To solve the proposed exercise, the next steps were used:
- Reading txt file with input data
- Mapping data extracted from txt into model entities Product,
- Create Tax Repository with rules for taxes
- Work with mapped products to applied correct taxes
- Generate receipt with input scenarios
- Execute test to check the correct execution of the different scenarios.

# Instructions

To execute the console app .NET 6 SDK should be installed first.
The code has the following estructure:
-SalesTaxes.Application
-SalesTaxes.Domain
-SalesTaxes.Infraestructure
-SalesTaxes.Main
    
The console app needs to be executed from terminal, we need to be located in the directory where **SalesTaxes.Main.csproj** reside, once we are located in this directory, we could execute the following command:
**dotnet run input_file.txt product_types.json**
the argument "input_file.txt" is a reference for text file containing the data that are going to be processed, **product_types.json** is a reference for json file that contains the product names associated to a type of product; in this arguments we can pass a full path of file, or if the file exists at the same directory we can pass only the name with the file extension.

If you want to add custom products, you need add product in the input file and the product_types.json
