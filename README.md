# UserManagementWeb

UserManagementWeb is an ASP.NET Core Razor Pages application for managing users. It provides functionality for user authentication, listing users, creating users individually or in bulk, updating user information, and deleting users.

## Prerequisites

- .NET 6.0 SDK
- Visual Studio 2022 or Visual Studio Code

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or the project folder in Visual Studio Code
3. Restore NuGet packages
4. Update the `appsettings.json` file with your API settings:
```
{
"ApiSettings": {
"BaseUrl": "https://your-api-base-url.com/"
}
}
```


5. Build the project
6. Run the application

## Project Structure

The project follows a standard ASP.NET Core Razor Pages structure:

- `Pages/`: Contains Razor Pages
- `Services/`: Contains service classes for authentication and user management
- `Interfaces/`: Contains interface definitions for services
- `Dtos/`: Contains Data Transfer Objects
- `wwwroot/`: Contains static files (CSS, JavaScript, etc.)


## Features

- User Authentication
- List Users with Pagination
- Create Individual Users
- Bulk Create Users
- Update User Information
- Delete Users

## Running the Application

After starting the application, navigate to `https://localhost:5001` in your web browser. You'll be redirected to the login page. After successful authentication, you can access the user management features.
