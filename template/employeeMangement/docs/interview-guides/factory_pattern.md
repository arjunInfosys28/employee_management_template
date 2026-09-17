Factory Pattern - Interview Cheat Sheet

Definition
- A creational pattern that provides an interface for creating objects but lets subclasses or a factory method decide which class to instantiate.

Why it matters
- Useful when creation logic is centralized or varies by input. In interviews, explain when to use Factory vs DI.

When to use Factory vs DI
- Use DI when you want the container to provide dependencies at runtime and you have concrete implementations wired up.
- Use Factory when creation requires runtime parameters, complex initialization, or selecting different implementations based on input.

Tiny example (C#):
  public static class EmployeeFactory
  {
	  public static Employee Create(string role)
	  {
		  return role switch
		  {
			  "engineer" => new Employee { Position = "Software Engineer", Salary = 80000m },
			  "manager" => new Employee { Position = "Manager", Salary = 100000m },
			  _ => new Employee { Position = "Staff", Salary = 60000m }
		  };
	  }
  }

Interview Q&A
- Q: Can Factory and DI work together? A: Yes. You can inject a factory (Func<T> or an IFactory<T>) via DI to create instances with runtime data.

Keywords to remember
- creational, factory method, simple factory, abstract factory, runtime parameters
