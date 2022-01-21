# Library API Service

## Environment 

- .NET version: 3.0

## Data:  
Example of a library model JSON object:
```
{
    id: 5,
    name: "Library name",
    location: "2838 Violet Ct, Columbus, IN 47201, USA"
}  
```

Example of a book model JSON object:
```
{
    id: 3,
    name: "The Norton Anthology of English Literature",
    category: "Anthology",
    libraryId: 5
}  
```

## Best Practices Requirements

Point changes to improve the API in terms of OO, SOLID and best practices in Software Engineer.

## Functionality Requirements

The following API needs to be implemented:

- `POST` request to `api/libraries/{libraryId}/books`:
    - Add the book to the given libraryId. 
    - The HTTP response code should be 201 on success.
    - For the body of the request, please use the JSON example of the book model given above.
    - If a library with {libraryId} does not exist, return 404.

- `GET` request to `api/libraries/{libraryId}/books`:
    - Return the entire list of books for the library with given libraryId.
    - The HTTP response code should be 200.
    - If a library with {libraryId} does not exist, return 404.
 
- `DELETE` request to `api/libraries/{libraryId}` :
    - Delete the library with libraryId. 
    - The HTTP response code should be 204 on success.
    - If a library with {libraryId} does not exist, return 404.
 

- NOTE: You need to add support for Dependency Injection for internal services (LibrariesService and BooksService) in the project Startup.cs file.

## Example requests and responses with headers

**Request 1:**

`POST` request to `api/libraries/5/books`

```
{
    id: 3,
    name: "The Norton Anthology of English Literature",
    category: "Anthology",
    libraryId: 5
}
```
The response code will be 201 and this book is added to the library with id 5.

**Request 2:**

`GET` request to `api/libraries/5/books`

The response code is 200, and when converted to JSON, the response body (assuming that the below objects are all objects in the collection) is as follows:

```
[{
    id: 3,
    name: "The Norton Anthology of English Literature",
    category: "Anthology",
    libraryId: 5
} {
    id: 10,
    name: "Inception",
    category: "Thriller",
    libraryId: 5
}]
```

**Request 3:**

`DELETE` request to `api/libraries/10`

Assuming that the library with id 10 exists, then the response code is 204 and there are no particular requirements for the response body. This causes the library with id 10 to be removed from the collection. When a library with id 10 doesn't exist, then the response code is 404 and there are no particular requirements for the response body.

## Project Specifications

**Read Only Files**
- LibraryService.Tests/IntegrationTests.cs

**Commands**
- install: 
```
dotnet build
```
- test: 
```
rm -rf reports && dotnet build && dotnet test --logger xunit --results-directory ./reports/
```
