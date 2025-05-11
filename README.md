A modern Web API built with ASP.NET Core 8 for building RESTful services.

## 📦 Requirements

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- IDE (e.g., [Visual Studio 2022+](https://visualstudio.microsoft.com/), [Rider](https://www.jetbrains.com/rider/), or [VS Code](https://code.visualstudio.com/))

## ⚙️ Getting Started

### 1. Clone the repository
git clone https://github.com/your-username/your-repo-name.git


cd mockapi/Truestory.Mock.API

dotnet restore

dotnet build

dotne run



The API will start on:
https://localhost:7226 or http://localhost:5198 (depending on your launch settings)




You can test endpoints using:
Swagger UI: Navigate to https://localhost:7226/swagger or http://localhost:5198/swagger/index.html

OR

Postman / curl
POST request
http://localhost:5198/api/MockAPI   

Body
{
  "id": "string",
  "name": "string",
  "data": "string"
}

GET request
http://localhost:5198/api/MockAPI  


DELETE request
http://localhost:5198/api/MOockAPI/{id}   