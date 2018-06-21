namespace Phonebook.Database
{
    using System.Collections.Generic;
    using Phonebook.Common;
    using PhoneBook.Common;

    /// <summary>
    /// The IPhonebookRepository interface.
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Gets the phonebook records.
        /// </summary>
        /// <returns>The List<see cref="Phonebook>"/>./returns>
        List<Phonebook> GetPhonebookRecords();

        /// <summary>
        /// Gets the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The phonebook record.</returns>
        Phonebook GetPhonebookRecord(int id);

        /// <summary>
        /// Adds the new phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        int AddNewPhonebookRecord(Phonebook phonebook);

        /// <summary>
        /// Updates the phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        void UpdatePhonebookRecord(Phonebook phonebook);

        /// <summary>
        /// Deletes the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePhonebookRecord(int id);

        /// <summary>
        /// Adds the token.
        /// </summary>
        /// <param name="tokenRequest">The token request.</param>
        void AddToken(TokenRequestModel tokenRequest);

        /// <summary>
        /// Gets the token identifier.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        int GetTokenId(string token);
    }
}
