/*How many games have the total rating 9 or more?
Group them by rating
Count the number of games in rating
Order them in ascending order of the count result*/
SELECT COUNT(ID) as 'Number of games', TotalRating
FROM dbo.Games
GROUP BY TotalRating
HAVING TotalRating >= 9
ORDER BY COUNT(ID) ASC

/*Get all games and order them asc
Inner join the table Genres*/
SELECT g.Name, g.ReleaseDate, g.TotalRating, g.GameDetails, gr.Name AS 'Genre'
FROM dbo.Games AS g
INNER JOIN dbo.GameGenre AS gg ON g.ID = gg.GameId
INNER JOIN dbo.Genres AS gr ON gr.ID = gg.GenreId
ORDER BY TotalRating ASC

/* What games can i play on PC?
Order them by name*/
SELECT g.Name, g.ReleaseDate, g.TotalRating, g.GameDetails
FROM dbo.Games AS g
INNER JOIN dbo.GamePlatform AS gp ON g.ID = gp.GameId
INNER JOIN dbo.Platforms AS p ON p.ID = gp.PlatformId
WHERE p.Name = 'PC'
ORDER BY Name ASC

/*What games launched in 2011?
Order by release date*/
SELECT Name
FROM dbo.Games
WHERE ReleaseDate BETWEEN '2011-01-01' and '2011-12-31'
ORDER BY ReleaseDate

/*What games launched in 2018 and i can play on PC?
Order by release date*/
SELECT g.Name
FROM dbo.Games AS g
INNER JOIN dbo.GamePlatform AS gp ON g.ID = gp.GameId
INNER JOIN dbo.Platforms AS p ON p.ID = gp.PlatformId
WHERE p.Name = 'PC'
AND ReleaseDate BETWEEN '2018-01-01' and '2018-12-31'
ORDER BY ReleaseDate

/*What users have the username start with the letter C?
Order by LastName asc*/
SELECT *
FROM dbo.Users
WHERE Username LIKE 'c%'
ORDER BY LastName ASC

/*How many games are playable on each platform
Group them by Platforms Name
Count the number of games in platforms
Order them in descending order of the count result*/
SELECT COUNT(g.ID) as 'Number of games', p.Name
FROM dbo.Games AS g
INNER JOIN dbo.GamePlatform AS gp ON g.ID = gp.GameId
INNER JOIN dbo.Platforms AS p ON p.ID = gp.PlatformId
GROUP BY p.Name
ORDER BY COUNT(g.ID) DESC

/*How many games are of each genre and have the Total Rating between 5 and 10
Group them by Genre Name
Count the number of games in genres
Order them in ascending order of the count result*/
SELECT COUNT(g.ID) as 'Number of games', gr.Name
FROM dbo.Games AS g
INNER JOIN dbo.GameGenre AS gg ON g.ID = gg.GameId
INNER JOIN dbo.Genres AS gr ON gr.ID = gg.GenreId
WHERE g.TotalRating >= 5 AND g.TotalRating <= 10
GROUP by gr.Name
ORDER BY COUNT(g.ID) ASC

/* What is the average of all games' ratings?*/
SELECT AVG(TotalRating) AS Average
FROM dbo.Games

/* What are the comments of the game with ID = 6
Order asc */
SELECT c.Content
FROM dbo.Games AS g
INNER JOIN dbo.Comments as c on g.ID = c.GameId
WHERE g.ID = 6