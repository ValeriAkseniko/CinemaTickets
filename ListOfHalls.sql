SELECT        dbo.Halls.Id, dbo.Halls.Title, SUM(dbo.Places.Capacity) AS CapacityHall,
                             (SELECT        COUNT(*) AS Expr1
                               FROM            dbo.Rows
                               WHERE        (HallId = dbo.Halls.Id)) AS CountRow,
                             (SELECT        COUNT(*) AS Expr1
                               FROM            dbo.Places INNER JOIN
                                                         dbo.Rows ON dbo.Places.RowId = dbo.Rows.Id
                               WHERE        (dbo.Rows.HallId = dbo.Halls.Id)) AS CountPlace
FROM            dbo.Halls INNER JOIN
                         dbo.Rows ON dbo.Rows.HallId = dbo.Halls.Id INNER JOIN
                         dbo.Places ON dbo.Places.RowId = dbo.Rows.Id
GROUP BY dbo.Halls.Id, dbo.Halls.Title