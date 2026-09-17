Middleware - Interview Cheat Sheet

Definition
- Middleware is code that runs in the request/response pipeline. Each middleware can inspect, modify, short-circuit, or pass the request to the next middleware.

Why it matters
- Common interview topic: ordering, short-circuiting, exception handling, cross-cutting concerns (logging, auth, metrics).

Keywords to remember
- pipeline, next, short-circuit, order matters, exception handling

Tiny examples
- Registering middleware (Program.cs):
  app.UseMiddleware<RequestLoggingMiddleware>();
  app.UseMiddleware<GlobalExceptionMiddleware>();
  app.UseMiddleware<SimpleAuthMiddleware>();

- SimpleAuthMiddleware behavior: checks X-Api-Key header and returns 401 if missing.

Interview Q&A
- Q: Where should exception middleware be placed? A: Early in the pipeline so it can catch exceptions from downstream middleware/handlers.
- Q: How does middleware short-circuit a request? A: Do not call await _next(context) and write the response instead.

Note
- Keep examples small. In interviews, explain ordering and give a short code example showing short-circuit and logging.
