Setup Instructions
To run this project locally, follow these steps:
1.	Clone the repository:
bash
Copy code
git clone https://github.com/prasantabiswalgit/GameAPI.git
2.	Navigate to the project directory:
bash
Copy code
cd GameApi
3.	Restore necessary packages:
bash
Copy code
dotnet restore
4.	Set up the database:Ensure your database connection string is correctly configured in appsettings.json.
Run Entity Framework Core migrations to create the database schema and seed initial data (if applicable):
bash Copy code dotnet ef database update
5.	Run the API:bash Copy code dotnet run
6.	Access the API:
Navigate to http://localhost:5001/swagger/index.html to view and interact with the API using Swagger UI.
7API Endpoints Games
8•	GET /api/games?page={pageNumber}&pageSize={pageSize} - Retrieves a list of games with pagination.
9•	GET /api/games/{id} - Retrieves a specific game by ID.
10•	POST /api/games - Creates a new game.
11•	PUT /api/games/{id} - Updates an existing game.
12•	DELETE /api/games/{id} - Deletes a game by ID.
13•	POST /api/games/bulk - Bulk inserts multiple games.
14Usage Guidelines
15•	Use Swagger UI (/swagger/index.html) for comprehensive API documentation and testing.
16•	Handle errors gracefully and provide meaningful error messages to API consumers.
17•	Maintain consistency in API response formats and status codes.
