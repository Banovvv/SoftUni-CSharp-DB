SELECT TOP(10) * FROM [dbo].[Projects]
WHERE StartDate IS NOT NULL
ORDER BY StartDate ASC, [Name] ASC