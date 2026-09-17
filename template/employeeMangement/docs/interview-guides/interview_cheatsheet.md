Comprehensive .NET & C# Interview Cheat Sheet (short answers)

Core C# and .NET
1) Value type vs Reference type?
- Value types (struct) stored on stack, copied on assignment; reference types (class) store reference to heap object.

2) What is boxing and unboxing?
- Boxing: wrapping a value type as object; unboxing: extracting value type from object. Avoid for performance-sensitive loops.

3) What is nullable reference types (C# 8+)?
- Compiler feature to track nullability: string? indicates nullable, enabling warnings to reduce NREs.

4) What are records in C#?
- Immutable reference types intended for data: provide value-based equality and concise syntax (record Person(string Name);).

5) Task vs Thread?
- Thread is OS thread. Task is higher-level abstraction representing an asynchronous operation; uses thread pool.

6) async/await best practices?
- Use async for I/O-bound work, avoid async void (except top-level event handlers), prefer ConfigureAwait(false) in libraries.

7) What is GC and generations?
- Garbage Collector reclaims memory; generations (0,1,2) optimize for short-lived objects.

8) Delegates and events?
- Delegate: type-safe function pointer. Event: a wrapper around delegate exposing subscription (+=/-=) for publishers/subscribers.

ASP.NET Core
9) What is the ASP.NET Core request pipeline?
- Ordered middleware components that process requests and responses; each can call next() or short-circuit.

10) How to register services in ASP.NET Core?
- Use builder.Services.AddSingleton/AddScoped/AddTransient in Program.cs.

11) What is IConfiguration and how to use it?
- Centralized config (JSON, env vars, secrets). Inject IConfiguration or bind to POCO via options pattern (IOptions<T>).

12) Difference between Use and Run middleware methods?
- Use can call next() to continue pipeline; Run short-circuits and does not call next().

13) How to host ASP.NET Core apps?
- Kestrel is the cross-platform web server; use reverse proxy (IIS, Nginx) in front for production scenarios.

14) How to handle configuration per environment?
- appsettings.{Environment}.json combined with environment variables; use IHostEnvironment to check environment.

Entity Framework Core
15) What is DbContext?
- Unit of work + repository-like class managing entity sets and change tracking. Represents a DB session.

16) Migrations: what are they?
- EF Core feature to evolve database schema using generated migration classes and Update-Database/apply commands.

17) Tracking vs NoTracking queries?
- Tracking tracks entities for change detection (useful for updates). AsNoTracking improves read performance.

18) Eager vs Lazy vs Explicit loading?
- Eager: Include(...); Lazy: load when navigation accessed (requires proxies); Explicit: Load() called manually.

19) How to handle concurrency in EF Core?
- Use concurrency tokens (rowversion/timestamp) and catch DbUpdateConcurrencyException to resolve conflicts.

20) How to write efficient EF queries?
- Project only needed columns, avoid N+1 (use Include or proper joins), use AsNoTracking for reads.

LINQ and Queries
21) Deferred vs immediate execution?
- Deferred: query executed when iterated (IQueryable/IEnumerable). Immediate: ToList/ToArray/Count forces execution.

22) How to remove duplicates in LINQ?
- Use Distinct on projection or GroupBy(key).Select(g => g.First()).

23) How to join two sequences in LINQ?
- Use Join or GroupJoin for left joins; use navigation properties when using EF Core.

24) Differences between Select and SelectMany?
- Select projects each item; SelectMany flattens sequences of sequences into single sequence.

25) How to get top N with LINQ?
- OrderByDescending(...).Take(N).

SQL and Database
26) What are indexes and when to use them?
- Indexes speed lookups on columns; use for frequently filtered or joined columns. Beware of write overhead.

27) Normalization vs denormalization?
- Normalization organizes data to reduce redundancy; denormalization improves read performance at cost of redundancy.

28) Difference between INNER JOIN, LEFT JOIN, RIGHT JOIN?
- INNER: rows matching both sides; LEFT: all left rows + matches; RIGHT: all right rows + matches.

29) Transactions and isolation levels?
- Transactions ensure atomicity; isolation levels (Read Uncommitted, Read Committed, Repeatable Read, Serializable) balance consistency vs concurrency.

30) How to prevent SQL injection?
- Use parameterized queries or ORM query APIs; never concatenate user input into SQL.

Design Principles & Patterns
31) What's SOLID (brief)?
- SRP, OCP, LSP, ISP, DIP — principles for maintainable design.

32) Common patterns: Repository, UnitOfWork, Factory, Strategy, Decorator?
- Repository: abstraction over data access. UnitOfWork: group operations in one transaction. Factory: object creation. Strategy: interchangeable algorithms. Decorator: extend behavior.

33) When to use Repository with EF Core?
- EF Core's DbContext already provides repository-like behavior; add repositories when you need abstraction for testing or complex behaviors.

34) What is CQRS?
- Command Query Responsibility Segregation: separate models for reads and writes; useful for scalability and separation of concerns.

Testing & Debugging
35) Unit vs Integration tests?
- Unit tests isolate a unit with mocks; integration tests use real components (DB, HTTP) to verify integration.

36) How to test controllers in ASP.NET Core?
- Use WebApplicationFactory for integration tests or instantiate controller with mocked services for unit tests.

37) How to mock DbContext or EF Core for tests?
- Prefer using in-memory provider (InMemory) or a SQLite in-memory DB for integration-like behavior; mocking DbSet is complex.

Performance & Security
38) How to diagnose performance issues?
- Use profilers, logging, application insights; look for I/O waits, DB slow queries, allocations, and blocking calls.

39) Authentication vs Authorization?
- Authentication: who are you. Authorization: what are you allowed to do.

40) What is JWT and when to use it?
- JSON Web Token: compact token for stateless authentication across services; ensure proper signature and expiry handling.

Advanced Topics / Common Interview Traps
41) Explain memory leaks in .NET?
- Leaks often due to event handlers not unsubscribed, static references, or unmanaged resources not disposed.

42) What is dispose pattern and using statement?
- IDisposable for cleanup of unmanaged resources; using ensures Dispose is called even on exceptions.

43) What are expression trees?
- Representation of code as data (Expression<Func<T>>). Used by LINQ providers (IQueryable) to translate to queries.

44) What is reflection and when to use it?
- Reflection inspects types at runtime (Type, MethodInfo). Use sparingly due to performance and complexity.

45) What is middleware order importance?
- Order determines which middleware can observe or catch exceptions and which can short-circuit; exception middleware should wrap downstream components.

Quick practice answers
- How to get employee with highest salary using LINQ? employees.OrderByDescending(e => e.Salary).FirstOrDefault();
- How to return 404 from a controller? return NotFound();
- How to register transient service? builder.Services.AddTransient<IMyService, MyService>();

Study tips
- Practice concise answers, know tradeoffs, write small code examples, and explain why you choose an approach.

