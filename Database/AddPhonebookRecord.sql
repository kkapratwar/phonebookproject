-- =============================================
-- Author:		Kalyan Kapratwar
-- Create date: 20/06/2018
-- Description:	Create new record in phonebook.
-- =============================================
CREATE PROCEDURE AddPhonebookRecord
	@firstName varchar(100),
	@lastName varchar(100),
	@phoneNumber varchar(15),
	@email varchar(200),
	@isActive bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with Insert statements.
	SET NOCOUNT ON;

	Insert into Phonebook (FirstName, LastName, PhoneNumber, Email, IsActive, CreatedDate) 
					Values (@firstName, @lastName, @phoneNumber, @email, @isActive, GETDATE());

	SELECT SCOPE_IDENTITY() Id;
END
GO
