namespace Phonebook.Database.Exntensions
{
    using Phonebook.Common;

    public static class ModelConverter
    {
        public static Phonebook ToModel(this GetPhonebookRecords_Result result)
        {
            return new Phonebook
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Id = result.Id,
                Status = result.IsActive,
                CreatedDate = result.CreatedDate,
                ModifiedDate = result.ModifiedDate
            };
        }

        public static Phonebook ToModel(this GetPhonebookRecordById_Result result)
        {
            return new Phonebook
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Id = result.Id,
                Status = result.IsActive,
                CreatedDate = result.CreatedDate,
                ModifiedDate = result.ModifiedDate
            };
        }
    }
}
