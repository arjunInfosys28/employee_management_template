SOLID and OOP - Interview Cheat Sheet

Purpose
- Short, interview-ready definitions, keywords, tiny code examples, and 1-2 common Q&A for each topic.

OOP (Object-Oriented Programming)
- Definition: A programming paradigm that models software as interacting objects with state and behavior.
- Core concepts: Encapsulation, Abstraction, Inheritance, Polymorphism
- Keywords to remember: class, object, interface, inheritance, override, virtual, sealed
- Tiny example (C#):
  public class Person { public string Name { get; set; } }
  public class Employee : Person { public decimal Salary { get; set; } }
- Interview Q: What's encapsulation? A: Hiding internal state and exposing behavior via methods/properties to ensure invariants.

SOLID
- Single Responsibility Principle (SRP)
  - Definition: A class should have one reason to change (one responsibility).
  - Keywords: cohesion, single purpose
  - Mini example: Split validation logic out of a repository into a separate validator.

- Open/Closed Principle (OCP)
  - Definition: Software entities should be open for extension, closed for modification.
  - Keywords: extension, abstractions, polymorphism
  - Mini example: Use interfaces and new implementations rather than editing existing classes.

- Liskov Substitution Principle (LSP)
  - Definition: Subtypes must be substitutable for their base types without breaking behavior.
  - Keywords: behavioral contract, replaceability
  - Interview tip: Watch for methods that throw in derived types or narrow preconditions.

- Interface Segregation Principle (ISP)
  - Definition: Prefer many small client-specific interfaces over one large general interface.
  - Keywords: client-specific, granular interfaces

- Dependency Inversion Principle (DIP)
  - Definition: High-level modules should not depend on low-level modules; both should depend on abstractions.
  - Keywords: abstractions, constructor injection, IoC
  - Tiny example (C#):
	public interface IRepository { void Add(Employee e); }
	public class Service { private readonly IRepository _repo; public Service(IRepository repo) { _repo = repo; } }

Quick interview Q&A
- Q: How would you apply SRP to a controller that both validates input and saves to DB? A: Move validation to a validator/service and keep controller orchestrating.
- Q: When to use an interface vs abstract class? A: Use interface for a contract without implementation; abstract class when you want shared base implementation.

Notes
- Keep answers short, give a small example, and mention tradeoffs. For interviews, emphasize intent and one-line benefits.
