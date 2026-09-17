LINQ and SQL - Interview Cheat Sheet

LINQ (C#) - quick patterns
- Get highest salary (single):
  var top = employees.OrderByDescending(e => e.Salary).FirstOrDefault();
  // or using Max + First
  var max = employees.Max(e => e.Salary);
  var top2 = employees.FirstOrDefault(e => e.Salary == max);

- Remove duplicates by a key (e.g., Email):
  var unique = employees.GroupBy(e => e.Email).Select(g => g.First()).ToList();

- Select projection and filtering:
  var names = employees.Where(e => e.IsActive).Select(e => new { e.FirstName, e.LastName }).ToList();

- Common methods: Where, Select, OrderBy/ThenBy, GroupBy, Join, Distinct, Any, All, FirstOrDefault, SingleOrDefault

SQL - quick patterns
- Highest salary (T-SQL):
  SELECT TOP 1 * FROM Employees ORDER BY Salary DESC;
  -- or using MAX
  SELECT * FROM Employees WHERE Salary = (SELECT MAX(Salary) FROM Employees);

- Remove duplicates (keep one row per email):
  -- Simple: use DISTINCT on selected columns
  SELECT DISTINCT Email, FirstName, LastName FROM Employees;
  -- Keep full row using window functions (SQL Server):
  WITH cte AS (
	SELECT *, ROW_NUMBER() OVER (PARTITION BY Email ORDER BY DateHired DESC) rn FROM Employees
  ) SELECT * FROM cte WHERE rn = 1;

- Filtering and joins:
  SELECT e.FirstName, d.Name FROM Employees e JOIN Departments d ON e.DepartmentId = d.Id WHERE e.IsActive = 1;

Interview Q&A
- Q: How to get top N salaries? A: OrderByDescending(e => e.Salary).Take(N) in LINQ; SELECT TOP(N) ... ORDER BY Salary DESC in SQL Server.
- Q: When to use GroupBy vs Distinct? A: Use Distinct when you want unique values of entire projection. Use GroupBy when you need aggregation or to pick a representative row per key.
- Q: How to remove duplicates efficiently in SQL? A: Use window functions (ROW_NUMBER) to pick one row per partition and delete others.

Keywords to remember
- projection, deferred execution, immediate execution (ToList, ToArray), expression trees (IQueryable), window functions, ROW_NUMBER
