INSERT INTO [dbo].[Towns]
([Name])

VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');

INSERT INTO [dbo].[Departments]
([Name])

VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');

INSERT INTO [dbo].[Addresses]
([AddressText], [TownId])

VALUES
('78 Aleksandar Malinov blvd', 1),
('78 Aleksandar Malinov blvd', 2),
('78 Aleksandar Malinov blvd', 3),
('78 Aleksandar Malinov blvd', 4),
('78 Aleksandar Malinov blvd', 3);

INSERT INTO [dbo].[Employees]
([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId])

VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.0, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.0, 2),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 3),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.0, 4),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 5);