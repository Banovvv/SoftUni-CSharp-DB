SELECT * INTO
	[EmployeesAverageSalaries]
FROM
	[dbo].[Employees]
WHERE
	[dbo].[Employees].[Salary] > 30000

---

DELETE FROM
	[EmployeesAverageSalaries]
WHERE
	[EmployeesAverageSalaries].[ManagerID] = 42

---

UPDATE
	[EmployeesAverageSalaries]
SET
	[EmployeesAverageSalaries].[Salary] += 5000
WHERE
	[EmployeesAverageSalaries].[DepartmentID] = 1

---

SELECT
	[EmployeesAverageSalaries].[DepartmentID],
	AVG(Salary) AS [AverageSalary]
FROM
	[EmployeesAverageSalaries]
GROUP BY
	[EmployeesAverageSalaries].[DepartmentID]