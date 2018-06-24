Phonebook Directory

This project is implemented to perform CRUD operations for Phonebook directory. 

The main focus of this project is on 
1) Web API implementation, 
2) Validations, 
3) Consume Web API in client application using RestSharp, 
4) Unity Container, 
5) Unit tests,  etc. 
I have not focused on the UI part of it. 

This solution contains following projects:
1) Phonebook.Common
2) Phonebook.Database
3) Phonebook.Service
4) Phonebook.Service.Tests
5) Phonebook.TestUI
6) Phonebook.TestUI.Tests

1) Phonebook.Common - This project contains all the models required for this project.

2) Phonebook.Database - This project is the database layer which uses entity framework inside it. I have used entity framework just to call stored procedures.

3) Phonebook.Service - Is is the Web API project. It contains two controllers.
	1) PhonebookController - This controller is used to perform CRUD operations.
	2) TOkenController - This controller is used to generate token for performing secure operations.
	
	In web api I have used token based authentication. Custom authorization filter is created to implement token based authentication.
	
	Every request to the phonebook controller need to pass through the custom authentication to execute that action.
	
	The services are written in such a way that we will get 100% code coverage for all the services.
	
4) Phonebook.Service.Tests - All the unit tests of Phonebook.Service web api is written in this project. I have acheived upto the max code coverage by these tests.

5) Phonebook.TestUI - Is is the MVC application to provide UI for CRUD operations. I have not given more importance to the UI in this project instead focused on code coverage.
	All the actions are written in such a way that we will get maxmium code coverage.
	
	This project contains PhonebookController which is used to perform CRUD operations for phonebook.
	
6) Phonebook.TestUI.Tests - All hte unit tests of Phonebook.TestUI project are written in this project.