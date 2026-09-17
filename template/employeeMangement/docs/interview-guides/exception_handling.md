Exception Handling - Interview Cheat Sheet

Purpose
- Handle errors centrally, return consistent HTTP responses, and avoid leaking internal details.

Global exception middleware (already present in the project)
- Catches unhandled exceptions and returns a 500 response with a generic error payload.

Mapping exceptions to HTTP codes (common practice)
- ValidationException -> 400 Bad Request
- UnauthorizedAccessException -> 401 Unauthorized
- KeyNotFoundException or NotFoundException -> 404 Not Found
- TimeoutException -> 504 Gateway Timeout
- Default/unknown -> 500 Internal Server Error

Example extension (pseudocode inside GlobalExceptionMiddleware):
  try { await _next(context); }
  catch (ValidationException ex) { context.Response.StatusCode = 400; }
  catch (UnauthorizedAccessException ex) { context.Response.StatusCode = 401; }
  catch (NotFoundException ex) { context.Response.StatusCode = 404; }
  catch (Exception ex) { context.Response.StatusCode = 500; }

Interview Q&A
- Q: Why not return exception details in responses? A: Security - avoid leaking implementation details. Log details server-side and return a user-friendly message.
- Q: Where to translate domain errors? A: Throw domain-specific exceptions from services; map them centrally in middleware or an exception filter.

Keywords to remember
- central handling, mapping, log, don't leak internals, user-friendly messages
