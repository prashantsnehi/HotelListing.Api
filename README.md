# HotelListingApi

A sample ASP.NET Core Web API project for managing hotel listings and related resources.

## Features

- CRUD operations for hotels
- CRUD operations for countries
- JWT-based authentication and authorization
- Data validation and error handling
- Entity Framework Core with SQL Server support

## Requirements

- .NET SDK 8.0 or later
- SQL Server / LocalDB
- Visual Studio 2022 or Visual Studio Code

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio or VS Code.
3. Update the connection string in `appsettings.json`.
4. Run database migrations:
   ```bash
   dotnet ef database update
   ```
5. Start the application:
   ```bash
   dotnet run
   ```

## API Endpoints

- `GET /api/hotels`
- `GET /api/hotels/{id}`
- `POST /api/hotels`
- `PUT /api/hotels/{id}`
- `DELETE /api/hotels/{id}`
- `GET /api/countries`
- `GET /api/countries/{id}`
- `POST /api/countries`
- `PUT /api/countries/{id}`
- `DELETE /api/countries/{id}`

## Notes

- Use Swagger or Postman to explore the API.
- Ensure migrations are applied before running.

## License

This project is provided as-is for learning and demonstration purposes.

## SQL Container command to run docker on Linux or MAC OS
docker run -e 'ACCEPT_EULA=Y' /
           -e 'SA_PASSWORD=Str0ngP@$$w0rd' /
           -p 1433:1433 /
           -v hotel_database:/var/opt/mssql/ /
           --platform=linux/amd64  /
           --name sqlserver /
           -d mcr.microsoft.com/mssql/server:2022-latest