============================================================
             WebApiwithSwagger - Placement Submission
============================================================

Project Name  : WebApiwithSwagger
Developed By  : SAUMY RAJ
Superset ID   : 6363348
College       : KIIT University
Technology    : ASP.NET Core Web API (.NET 8 or .NET 9)
Tool Used     : Visual Studio 2022
Database      : Not Used (In-Memory Storage Only)
Documentation : Swagger (Swashbuckle.AspNetCore)

------------------------------------------------------------
📌 Project Objective
------------------------------------------------------------
This project demonstrates the creation and usage of a simple
Web API using ASP.NET Core with full integration of Swagger 
UI for testing. It satisfies the MNC placement requirements 
to show:

- Swagger setup and configuration
- Use of HTTP verbs (GET, POST, PUT, DELETE)
- Use of routing attributes
- In-memory CRUD operations (no database)
- Clean and RESTful API design

------------------------------------------------------------
🛠️ Features Implemented
------------------------------------------------------------
✔ Swagger UI configuration using AddSwaggerGen & UseSwaggerUI
✔ Custom Swagger metadata (Title, Contact, License)
✔ API controller named "EmpController"
✔ Route: api/Emp
✔ CRUD operations using in-memory List<string>
✔ ProducesResponseType for better Swagger documentation
✔ Swagger UI enabled at: https://localhost:[port]/swagger
: Postman Also Used for Verification
------------------------------------------------------------
📁 Project Structure
------------------------------------------------------------
WebApiwithSwagger/
│
├── Controllers/
│   └── EmpController.cs   # Contains all CRUD endpoints
│
├── Program.cs             # Swagger and routing configured
├── appsettings.json
├── WebApiwithSwagger.csproj
├── README.txt             # This file
└── Screenshot.png         # Swagger UI screenshot proof

------------------------------------------------------------
🔍 How to Run
------------------------------------------------------------
1. Open the solution in Visual Studio 2022
2. Build the project (Ctrl + Shift + B)
3. Run the project (F5)
4. Browser will open to default endpoint
5. Change the URL to: https://localhost:[port]/swagger
6. Use Swagger UI and Postman to test GET, POST, PUT, DELETE

