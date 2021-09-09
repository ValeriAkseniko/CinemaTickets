use TicketDB;
SELECT SUM(HallInfo.Capacity) AS Capacity
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
WHERE HallInfo.HallId = '1BD4C29B-CD0B-4909-ADAE-CA1B4B461E8C'

use TicketDB;
select sum(Capacity)
from Places
where Places.RowId = 'DAD80150-5083-4BCA-AF78-307CE73C8A40';