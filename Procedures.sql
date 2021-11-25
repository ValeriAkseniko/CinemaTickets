USE [TicketDB]
GO
/****** Object:  StoredProcedure [dbo].[CapacityHallById]    Script Date: 25.11.2021 15:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CapacityHallById]
@id UNIQUEIDENTIFIER,
@CapacityHall Int output
as
SELECT @CapacityHall =  SUM(HallInfo.Capacity)
FROM ( 
	SELECT
		Halls.Id AS HallId,
		HallRows.Capacity As Capacity
	FROM Halls
	LEFT JOIN (
		SELECT 
			Rows.HallId, 
			Places.Capacity 
		FROM Rows
		LEFT JOIN Places 
		ON Places.RowId = Rows.Id
	) AS HallRows 
	ON Halls.Id = HallRows.HallId 
) AS HallInfo
WHERE HallInfo.HallId = @id




GO
/****** Object:  StoredProcedure [dbo].[CapacityHallByTitle]    Script Date: 25.11.2021 15:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CapacityHallByTitle]
@title NVARCHAR(Max),
@CapacityHall Int output
as
SELECT @CapacityHall = SUM(HallInfo.Capacity)
FROM ( 
	SELECT
		Halls.Title AS Title,
		HallRows.Capacity As Capacity
	FROM Halls
	LEFT JOIN (
		SELECT 
			Rows.HallId, 
			Places.Capacity 
		FROM Rows
		LEFT JOIN Places 
		ON Places.RowId = Rows.Id
	) AS HallRows 
	ON Halls.Id = HallRows.HallId 
) AS HallInfo
WHERE HallInfo.Title = @title




GO
/****** Object:  StoredProcedure [dbo].[FilmInfoById]    Script Date: 25.11.2021 15:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[FilmInfoById]
@id UniqueIdentifier
as
select Films.Id as Id,
       Films.Title as Title,
	   Genres.Title as Genre,
	   AgeRestrictions.Title as AgeRestriction
from Films
       left join Genres on Films.GenreId = Genres.Id
	   left join AgeRestrictions on Films.AgeRestrictionId = AgeRestrictions.Id
where Films.Id = @id



GO
/****** Object:  StoredProcedure [dbo].[FilmInfoByTitle]    Script Date: 25.11.2021 15:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[FilmInfoByTitle]
@title NVARCHAR(Max)
as
select Films.Id as Id,
       Films.Title as Title,
	   Genres.Title as Genre,
	   AgeRestrictions.Title as AgeRestriction
from Films
       left join Genres on Films.GenreId = Genres.Id
	   left join AgeRestrictions on Films.AgeRestrictionId = AgeRestrictions.Id
where Films.Title = @title