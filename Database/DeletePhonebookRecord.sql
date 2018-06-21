-- =============================================
-- Author:		Kalyan Kapratwar
-- Create date: 20/06/2018
-- Description:	Delete phonebook record by id.
-- =============================================
CREATE PROCEDURE DeletePhonebookRecord
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with delete statements.
	SET NOCOUNT ON;

	Delete FROM Phonebook WHERE Id = @id;
END
GO
