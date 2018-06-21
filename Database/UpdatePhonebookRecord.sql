-- =============================================
-- Author:		Kalyan Kapratwar
-- Create date: 20/06/2018
-- Description:	Update new record in phonebook.
-- =============================================
CREATE PROCEDURE UpdatePhonebookRecord
	@id int = 0,
	@firstName varchar(100),
	@lastName varchar(100),
	@phoneNumber varchar(15),
	@email varchar(200),
	@isActive bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with Update statements.
	SET NOCOUNT ON;

	Update Phonebook set FirstName = @firstName 
						,LastName = @lastName
						,PhoneNumber = @phoneNumber
						,Email = @email
						,IsActive = @isActive
						,ModifiedDate = GETDATE()
					where Id = @id;
END
GO
