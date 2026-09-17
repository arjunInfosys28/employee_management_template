Summary of changes and how to run

Files added
- docs/interview-guides/solid_and_oop.md
- docs/interview-guides/dependency_injection.md
- docs/interview-guides/middleware.md
- docs/interview-guides/exception_handling.md
- docs/interview-guides/linq_and_sql.md
- docs/interview-guides/factory_pattern.md
- docs/interview-guides/interview_cheatsheet.md
- docs/interview-guides/changes_summary.md (this file)

Code added
- src/Api/Middleware/SimpleAuthMiddleware.cs (header-based demo auth)
- Program.cs updated to register SimpleAuthMiddleware

How to run locally
1) From repo root (or Visual Studio), build the solution:
   dotnet build template/employeeMangement/employeeMangement.csproj

2) Run the API project:
   dotnet run --project template/employeeMangement/src/Api

3) Test endpoints (examples):
   - Get all employees:
	 curl http://localhost:5000/api/employees
   - Call with API key header to avoid 401 from SimpleAuthMiddleware:
	 curl -H "X-Api-Key: demo" http://localhost:5000/api/employees

Notes
- The middleware and docs are minimal, focused for interview explanations and quick demos.
- For production: configure secrets, use real authentication, and tune exception handling and logging.

Next steps
- Tell me which topic you want expanded with more examples or small exercises (e.g., DI unit tests, LINQ exercises, design question walkthroughs, or adding a Factory implementation).
