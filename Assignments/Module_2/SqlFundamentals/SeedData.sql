INSERT INTO dbo.Games (Name, ReleaseDate, TotalRating, GameDetails, ImageSrc)
VALUES
('Minecraft', '2011-11-18', 9, 'Minecraft is a sandbox video game developed by Mojang Studios. The game was created by Markus "Notch" Persson in the Java programming language.', 'minecraft.jpg'),
('Red Dead Redemption 2', '2018-10-26', 9.50, 'Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.', 'rdr2.jpg'),
('Grand Theft Auto V', '2013-9-17', 9, 'Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.', 'gta.jpg'),
('The Elder Scrolls V: Skyrim', '2011-11-11', 8, 'The Elder Scrolls V: Skyrim is an action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.', 'skyrim.jpg'),
('Among Us', '2018-11-18', 7.5, 'Among Us is a 2018 online multiplayer social deduction game developed and published by American game studio Innersloth.', 'amongus.jpg'),
('BioShock', '2007-7-12', 7, 'BioShock is a 2007 first-person shooter game developed by 2K Boston and 2K Australia, and published by 2K Games.', 'bioshock.jpg'),
('Disco Elysium', '2019-2-18', 9, 'Disco Elysium is a 2019 role-playing video game developed and published by ZA/UM.', 'disco.jpg'),
('Mass Effect 2', '2010-4-12', 9, 'Mass Effect 2 is an action role-playing video game developed by BioWare and published by Electronic Arts', 'masseffect.jpg'),
('Wreckfest', '2018-6-14', 9, 'Wreckfest is a racing video game developed by Bugbear Entertainment and published by THQ Nordic.', 'wreckfest.jpg'),
('Pac-Man', '1980-12-1', 9, 'Pac-Man, originally called Puck Man in Japan, is a 1980 maze action video game developed and released by Namco for arcades.', 'pacman.jpg')

INSERT INTO dbo.Genres (Name)
VALUES
('Sandbox'),
('Real-Time-Strategy'),
('Shooter'),
('MOBA'),
('RPG'),
('Simulation'),
('Action'),
('Adventure'),
('Horror'),
('Platformer')


INSERT INTO dbo.GameGenre (GameId, GenreId)
VALUES
(6, 1),
(6, 8),
(7, 3),
(7, 7),
(8, 3),
(8, 7),
(9, 8),
(9, 1),
(10, 7),
(11, 3),
(11, 7),
(12, 2),
(12, 5),
(13, 3),
(13, 8),
(14, 1),
(14, 7),
(15, 10)

INSERT INTO dbo.Platforms (Name)
VALUES
('Pc'),
('Nintendo Switch'),
('PS5'),
('PS4'),
('PS3'),
('Xbox One'),
('Xbox 360'),
('VR'),
('Android'),
('IOS')

INSERT INTO dbo.GamePlatform (GameId, PlatformId)
VALUES
(6, 1),
(6, 6),
(7, 1),
(7, 3),
(8, 1),
(8, 4),
(9, 1),
(9, 7),
(10, 1),
(10, 9),
(11, 1),
(11, 6),
(12, 2),
(12, 1),
(13, 1),
(13, 7),
(14, 1),
(14, 4),
(15, 1),
(15, 10)

INSERT INTO dbo.Developers (Name, Headquarters)
VALUES
('Mojang Studios', 'Stockholm, Sweden'),
('Rockstar Games', 'New York, US'),
('Bethesda', 'Rockville, Maryland'),
('InnerSloth LLC', 'Redmond, US'),
('2K Games', 'Novato, California'),
('ZA/UM', 'London, UK'),
('Bioware', 'Edmonton, Canada'),
('Bugbear Entertainment', 'Helsinki, Finland'),
('Nintendo', 'Kyoto, Japan'),
('Riot Games', 'Los Angeles, US')


INSERT INTO dbo.GameDeveloper (GameId, DeveloperId)
VALUES
(6, 1),
(7, 2),
(8, 2),
(9, 3),
(10, 4),
(11, 5),
(12, 6),
(13, 7),
(14, 8),
(15, 9)

INSERT INTO dbo.Users(Username, FirstName, LastName)
VALUES
('bryan', 'Bryan', 'John'),
('lemar', 'Lemar', 'Rudd'),
('carmen', 'Carmen', 'Dean'),
('constance', 'Constance', 'Caldwell'),
('brendon', 'Brendon', 'Walton'),
('emnett', 'Emmett', 'Turnbull'),
('alesha', 'Alesha', 'Cline'),
('darragh', 'Darragh', 'Brady'),
('freja', 'Freja', 'Ross'),
('yannis', 'Yannis', 'Penn'),
('vivaan', 'Vivaan', 'Gibson')

INSERT INTO dbo.Reviews(GameId, UserId, Rating, Content)
VALUES
(6, 1, 9, 'good game'),
(6, 2, 8, 'i liked the game'),
(6, 4, 7, 'interesting game'),
(9, 3, 5, 'bad game'),
(10, 6, 4, 'didnt like'),
(11, 2, 2, 'bad quality game'),
(12, 10, 10, 'excellent game'),
(12, 8, 6, 'average game'),
(14, 6, 1, 'didnt like'),
(15, 7, 8, 'good game')

INSERT INTO dbo.Comments(GameId, UserId, Content)
VALUES
(6, 5, 'hello'),
(7, 3, 'hi'),
(6, 5, 'opinions?'),
(9, 1, 'interesting'),
(8, 3, 'friend req?'),
(11, 9, 'i like to comment'),
(10, 8, 'hiiii'),
(13, 6, 'hello'),
(14, 4, 'very good'),
(15, 6, 'good game')

INSERT INTO dbo.Replies(UserId, CommentId, Content)
VALUES
(1, 1, 'hello'),
(1, 2, 'hi'),
(3, 3, 'good opinions'),
(9, 3, 'bad opinions'),
(4, 3, 'average opinions'),
(5, 4, 'like to comment too'),
(6, 5, 'hiiii'),
(6, 6, 'hello'),
(10, 7, 'very good'),
(10, 8, 'good game')