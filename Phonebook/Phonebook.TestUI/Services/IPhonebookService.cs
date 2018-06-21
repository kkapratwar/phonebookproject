namespace Phonebook.TestUI.Services
{
    using System.Collections.Generic;
    using Phonebook.Common;

    /// <summary>
    /// The IPhonebookService contract.
    /// </summary>
    public interface IPhonebookService
    {
        /// <summary>
        /// Adds the phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        int AddPhonebookRecord(Phonebook phonebook);

        /// <summary>
        /// Deletes the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool DeletePhonebookRecord(int id);

        /// <summary>
        /// Updates the phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        bool UpdatePhonebookRecord(Phonebook phonebook);

        /// <summary>
        /// Gets all phonebook records.
        /// </summary>
        /// <returns></returns>
        List<Phonebook> GetAllPhonebookRecords();

        /// <summary>
        /// Gets the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Phonebook GetPhonebookRecord(int id);
    }
}
