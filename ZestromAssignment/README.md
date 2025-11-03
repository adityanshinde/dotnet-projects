# ZestromAssignment

Simple ASP.NET Core MVC sample that demonstrates a basic login flow validated against an EF Core InMemory database. This is intentionally minimal for learning purposes.

How to run

1. Open a terminal in this folder.
2. Restore and run the app:

```powershell
dotnet restore
dotnet run --project .\ZestromAssignment.csproj
```

3. The app will open (or listen) and the login page is at `/`.

Sample users seeded:
- Username: admin  Password: password
- Username: user   Password: 1234

Notes
- This uses an in-memory database and plain-text passwords for demonstration only. Do not use this approach in production. For real apps, learn ASP.NET Core Identity and proper password hashing.
