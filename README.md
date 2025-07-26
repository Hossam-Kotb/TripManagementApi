# 🧭 Trip Management API

A clean and simple ASP.NET Core Web API for managing trip records using Entity Framework Core and SQL Server.

---

## 🔧 Features

- ✅ CRUD operations (Create, Read, Update, Delete)
- ✅ Entity Framework Core integration
- ✅ SQL Server database
- ✅ RESTful architecture
- ✅ Swagger (OpenAPI) documentation
- ✅ Custom Middleware for Rate Limiting & Performance Profiling

---

## 📦 Technologies Used

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger / Swashbuckle
- C#

---

## ▶️ How to Run

1. **Clone the repo**  
   ```bash
   git clone https://github.com/Hossam-Kotb/TripManagementAPI.git
   ```

2. **Navigate to the project folder**  
   ```bash
   cd TripManagementAPI
   ```

3. **Update `appsettings.json`**  
   Replace the connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=TripDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. **Apply migrations**  
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the app**  
   ```bash
   dotnet run
   ```

6. **Access Swagger UI**  
   Navigate to:  
   [https://localhost:xxxx/swagger](https://localhost:xxxx/swagger)

---

## 🔗 API Endpoints

| Method | Endpoint       | Description         |
|--------|----------------|---------------------|
| GET    | /trip          | Get all trips       |
| GET    | /trip/{id}     | Get trip by ID      |
| POST   | /trip          | Create a new trip   |
| PUT    | /trip/{id}     | Update a trip       |
| DELETE | /trip/{id}     | Delete a trip       |

---

## 🧩 Custom Middleware

### 🚦 Rate Limiting Middleware

- Limits the number of allowed requests within a 10-second window.
- If more than 5 requests are made in 10 seconds, the API returns:
  ```
  Rate limit exceeded
  ```
- ✅ Helps protect the API from overloading or abuse.

---

### ⏱️ Profiling Middleware

- Measures the execution time of each request using `Stopwatch`.
- Logs the duration like:
  ```
  Request: /trip | Took: 25ms
  ```
- ✅ Useful for performance monitoring and optimization.

---

### 🛠️ Middleware Registration

In `Program.cs`:
```csharp
app.UseMiddleware<RateLimitingMiddleware>();
app.UseMiddleware<ProfilingMiddleware>();
```

---

## 🙋‍♂️ Author

**Hossam Kotb**  
- [LinkedIn](https://www.linkedin.com/in/hossam-kotb-97ab9b155/)  
- [GitHub](https://github.com/Hossam-Kotb)

---

## 🌟 Show Some Support

If you like this project, consider giving it a ⭐ on GitHub!
