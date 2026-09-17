Dependency Injection (DI) - Interview Cheat Sheet

Definition
- DI is a technique where an object's dependencies are provided (injected) from the outside rather than created inside the object. Promotes testability and separation of concerns.

Why it matters in interviews
- Shows understanding of loose coupling, testability, and inversion of control.

Key concepts
- Constructor injection (preferred), property injection, method injection
- Service lifetimes: Singleton, Scoped, Transient

Keywords to remember
- IoC, container, constructor injection, service lifetime, registration

Tiny example (C# registration snippet):
  // Program.cs
  builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();
  builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

When to use which lifetime
- Singleton: One instance for app lifetime. Use for in-memory caches or stateless services.
- Scoped: One instance per request (ASP.NET Core). Use for DbContext or request-scoped services.
- Transient: New instance every time requested. Use for lightweight, stateless operations.

Interview Q&A
- Q: Why prefer constructor injection? A: It makes dependencies explicit and guarantees required dependencies are available at construction time.
- Q: How do you test a class that depends on a repository? A: Provide a test double (mock/fake) implementing the repository interface and pass it into the class's constructor.

Note
- Keep DI simple in interviews: explain purpose, show a short registration snippet, and name common lifetimes.
