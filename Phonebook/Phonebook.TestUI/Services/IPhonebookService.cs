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
        /// <param name="token">The token.</param>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        int AddPhonebookRecord(string token, Phonebook phonebook);

        /// <summary>
        /// Deletes the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool DeletePhonebookRecord(string token, int id);

        /// <summary>
        /// Updates the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        bool UpdatePhonebookRecord(string token, Phonebook phonebook);

        /// <summary>
        /// Gets all phonebook records.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        List<Phonebook> GetAllPhonebookRecords(string token);

        /// <summary>
        /// Gets the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Phonebook GetPhonebookRecord(string token, int id);

        /// <summary>
        /// Validates the and get.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>The token.</returns>
        string ValidateAndGet(string token = null);
    }
}
