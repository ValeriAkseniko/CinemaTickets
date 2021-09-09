use TicketDB;
SELECT SUM(HallInfo.Capacity) AS Capacity
FROM ( 
	SELECT
		Halls.Id,
		Halls.Title,
		HallRows.RowNumber AS RowNumber,
		HallRows.PlaceNumber AS PlaceNumber, 
		HallRows.Capacity As Capacity
	FROM Halls
	LEFT JOIN (
		SELECT 
			Rows.HallId, 
			Rows.Id, 
			Rows.Number AS RowNumber, 
			Places.Number AS PlaceNumber, 
			Places.Capacity 
		FROM Rows
		LEFT JOIN Places 
		ON Places.RowId = Rows.Id
	) AS HallRows 
	ON Halls.Id = HallRows.HallId 
) AS HallInfo
WHERE HallInfo.Id = '1BD4C29B-CD0B-4909-ADAE-CA1B4B461E8C'

use TicketDB;
select sum(Capacity)
from Places
where Places.RowId = 'DAD80150-5083-4BCA-AF78-307CE73C8A40';