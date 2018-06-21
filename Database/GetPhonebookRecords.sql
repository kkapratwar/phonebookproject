-- =============================================
-- Author:		Kalyan Kapratwar
-- Create date: 20/06/2018
-- Description:	Get phonebook records.
-- =============================================
CREATE PROCEDURE GetPhonebookRecords
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
	FROM Phonebook;
END
GO
