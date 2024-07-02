Setup Instructions :
To run this project locally, follow these steps:

1. Clone the repository
2. 
git clone https://github.com/prasantabiswalgit/GameAPI.git
3. Navigate to the project directory
4. 
cd GameAPI
5. Restore necessary packages
6. 
dotnet restore
7. Set up the database
8. 
Ensure your database connection string is correctly configured in appsettings.json. Run Entity Framework Core migrations to create the database schema and seed initial data (if applicable):

dotnet ef database update
10. Run the API

dotnet run
11. Access the API

Navigate to http://localhost:5001/swagger/index.html to view and interact with the API using Swagger UI.

API Endpoints
Games
GET /api/games?page={pageNumber}&pageSize={pageSize} - Retrieves a list of games with pagination.

GET /api/games/{id} - Retrieves a specific game by ID.

POST /api/games - Creates a new game.

PUT /api/games/{id} - Updates an existing game.

DELETE /api/games/{id} - Deletes a game by ID.

POST /api/games/bulk - Bulk inserts multiple games.

Usage Guidelines :

Use Swagger UI (/swagger/index.html) for comprehensive API documentation and testing.

Handle errors gracefully and provide meaningful error messages to API consumers.

Maintain consistency in API response formats and status codes.

