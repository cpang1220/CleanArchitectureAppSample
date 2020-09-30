This project has the following functions:

- Challenge 1: Retrieve the species name for the "Currently Enrolled" page view listing all external students that are already enrolled, in order to display the name instead of the id referring to the species of student.

- Challenge 2: Implementation of the "Enroll new Jedi" form. When pressing the Enroll button, a student record is saved to the students memory database.

- Challenge 3: Added the option of selecting a planet of origin in the "Enroll new Jedi" form. When pressing the Enroll button, the planet of origin for the student record is saved to the students memory database.

## Requirements
The project mainly requires:
1. ASP.NET Core Runtime version 3.1
2. MediatR version version 8.0.1
3. xUnit.net testing framework version 2.4

## Usage
API path which returns all enrolled external students  (HTTP GET method)
```
http://jediacademyapi/api/individuals
```
API path which add a student record to the students memory database for enrollment (HTTP POST method)
```
http://jediacademyapi/api/individuals
```
API path which returns all the planets of origin data for the student record  (HTTP GET method)
```
http://starwarsapi/api/data/planets
```
API path which returns all the species of origin data for the student record  (HTTP GET method)
```
http://starwarsapi/api/data/species
```

## Additional functions
The following functions are added to the project for the purpose of application improvement:
- Validation messages are added in the "Enroll new Jedi" form. DataAnnotations attributes are added in the JediEnrollmentViewModel. When the user submits the form without entering all the inputs, then ASP.NET MVC uses a data-attribute of Html5 for the validation and a validation message will be injected in the form when the validation error occurs.
- An alert pop-up message (JavaScript) will be displayed showing the "Student added successfully" message after the user submits the "Enroll new Jedi" form. The logic behind is configured using the TempData attribute in ASP.NET MVC framework. TempData is used to store the pop-up message value, which is retained during redirection back to the Index action.
- In the "Currently Enrolled" page view listing all external students that are already enrolled, the "Planet" column is added to the currently enrolled students list, showing the name of planet of origin for the student record. Similar to Challenge 1, the planet name is retrieved in order to display the name instead of the id referring to the planet of student.
- Docker containers are added to both the back-end(API) and front-end(web application) projects. The solution is dockerized so that it is runnable using a dockerCompose as startup project. The docker-compose.yml and dockerfile script is added to the solution which includes the necessary logic to build and run the project containers and automates the startup process.
- Unit tests are added for the project
- Added CircleCI automation tools for automation build and test in GitHub
- Added swagger yml files for API specification documentation


## Unit Testing
- A unit test project is added for the purpose of unit tests in the back-end(API) projects.
- The unit test project is a xUnit.net project, mainly using
1. xUnit.net testing framework version 2.4
2. Moq mocking framework for .NET version version 4.14.5
- The following test functions are implemented to unit test the back-end(API) projects:
Mock the mediator object to unit test 
1. API which returns enrolled external students. (Returns HTTP 200 OK result)
2. API which returns 404 not found result in get enrolled external students. (Returns HTTP 404 not found result)
3. API which successfully add a student record for enrollment. (Returns HTTP 200 OK result)
4. API which return error result when adding a student record for enrollment. (Returns HTTP 500 error result)
5. API which return data of the planets of origin data for the student record. (Returns HTTP 200 OK result)
6. API which return data of the species of origin data for the student record. (Returns HTTP 200 OK result)
