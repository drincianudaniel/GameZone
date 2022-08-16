
-- WORKING TRANSACTION
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE dbo.Games
		SET TotalRating = 10
		WHERE ID = 6;

		Update dbo.Games
		Set GameDetails = 'Edited game details'
		Where ID = 7;
		
		Update dbo.Games
		Set GameDetails = 'Edited game details', TotalRating = 9.6
		Where ID = 8;

		Update dbo.Users
		Set Username = 'bryan778'
		Where ID = 1;

		Update dbo.Users
		Set Username = 'colt', FirstName = 'Colt', LastName = 'Yvonne'
		Where ID = 2;

		Update dbo.Users
		Set Username = 'triinu', FirstName = 'Triinu', LastName = 'Micol'
		Where ID = 3;

		Update dbo.Comments
		Set Content = 'Hi!'
		Where ID = 1;

		Update dbo.Comments
		Set Content = 'Hello!'
		Where ID = 2;

		Update dbo.Comments
		Set Content = 'Hi!'
		Where ID = 8;

		DELETE FROM Genres
		Where ID = 4;

		DELETE FROM Genres
		Where ID = 9;

		DELETE FROM GamePlatform
		Where ID = 13;

		DELETE FROM Platforms
		Where ID = 2;

		DELETE FROM Platforms
		Where ID = 5;
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
    SELECT ERROR_MESSAGE() AS ErrorMessage;
	ROLLBACK TRANSACTION
END CATCH

-- FAIL TRANSACTION


-- WORKING TRANSACTION
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE dbo.Games
		SET TotalRating = 10
		WHERE ID = 6;

		Update dbo.Games
		Set GameDetails = 'Edited game details'
		Where ID = 16;
		
		Update dbo.Games
		Set GameDetails = 'Edited game details', TotalRating = 9.6
		Where ID = 8;

		Update dbo.Users
		Set Username = 'bryan778'
		Where ID = 15;

		Update dbo.Users
		Set Username = 'colt', FirstName = 'Colt', LastName = 'Yvonne'
		Where ID = 2;

		Update dbo.Users
		Set Username = 'triinu', FirstName = 'Triinu', LastName = 'Micol'
		Where ID = 3;

		Update dbo.Comments
		Set Content = 'Hi!'
		Where ID = 1;

		Update dbo.Comments
		Set Content = 'Hello!'
		Where ID = 2;

		Update dbo.Comments
		Set Content = 'Hi!'
		Where Content = 43;

		DELETE FROM Genres
		Where ID = 4;

		DELETE FROM Genres
		Where ID = 9;

		DELETE FROM GamePlatform
		Where ID = 13;

		DELETE FROM Platforms
		Where ID = 20;

		DELETE FROM Platforms
		Where ID = 20;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
    SELECT ERROR_MESSAGE() AS ErrorMessage;
	ROLLBACK TRANSACTION
END CATCH