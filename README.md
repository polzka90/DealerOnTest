# DealerOnTest

## Requirements

 1. Git to clone the project
 2. Visual Studio to restore and build
 3. Postman

## Brief Explanation

FunctionApp: is the API to access to the backend, 
			 i use a Azure Function the get it ready to deploy to azure

Application: is where i put the bussiness rules and logics, using UseCase for each context

Infrastructure: is where generally i put Acl, Repository, Services, etc

UnitTesting: a little example of using unit testing with Xunit

## Step by Step

 1. Restore and build the solution
 2. Use the Postman Colletion in side the repository "DealerOn.postman_collection.json"
	to call the backend using the inputs of the PDF