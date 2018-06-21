-- =============================================
-- Author:		Kalyan Kapratwar
-- Create date: 20/06/2018
-- Description:	Get phonebook record by id.
-- =============================================
CREATE PROCEDURE GetPhonebookRecordById
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with Select statements.
	SET NOCOUNT ON;

	SELECT    Id
			, FirstName
			, LastName
			, PhoneNumber
			, Email
			, IsActive
			, CreatedDate
			, ModifiedDate
	FROM Phonebook
	WHERE Id = @id;
END
GO
