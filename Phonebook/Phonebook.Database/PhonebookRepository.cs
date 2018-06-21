namespace Phonebook.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Common;
    using Phonebook.Database.Exntensions;
    using PhoneBook.Common;

    /// <summary>
    /// The phonebookrepository class to perform database operations.
    /// </summary>
    public class PhonebookRepository : IPhonebookRepository
    {
        /// <summary>
        /// Adds the new phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns>The id of newly added phonebook record.</returns>
        int IPhonebookRepository.AddNewPhonebookRecord(Phonebook phonebook)
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                return phonebookEntities.AddPhonebookRecord(phonebook.FirstName, phonebook.LastName, phonebook.PhoneNumber, phonebook.Email, phonebook.Status);
            }
        }

        /// <summary>
        /// Adds the token.
        /// </summary>
        /// <param name="tokenRequest">The token request.</param>
        void IPhonebookRepository.AddToken(TokenRequestModel tokenRequest)
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                phonebookEntities.CreateToken(tokenRequest.Token, tokenRequest.ExpirationTime);
            }
        }

        /// <summary>
        /// Deletes the phonebook record of specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void IPhonebookRepository.DeletePhonebookRecord(int id)
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                phonebookEntities.DeletePhonebookRecord(id);
            }
        }

        /// <summary>
        /// Gets the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns> The phonebook record.</returns>
        Phonebook IPhonebookRepository.GetPhonebookRecord(int id)
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                return phonebookEntities.GetPhonebookRecordById(id).Select(x => x.ToModel()).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the phonebook records.
        /// </summary>
        /// <returns>The list of phonebook records.</returns>
        List<Phonebook> IPhonebookRepository.GetPhonebookRecords()
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                return phonebookEntities.GetPhonebookRecords().Select(x => x.ToModel()).ToList();
            }
        }

        /// <summary>
        /// Gets the token identifier.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        int IPhonebookRepository.GetTokenId(string token)
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                return Convert.ToInt32(phonebookEntities.GetTokenIdByToken(token).FirstOrDefault());
            }
        }

        /// <summary>
        /// Updates the phonebook record of specified id.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        void IPhonebookRepository.UpdatePhonebookRecord(Phonebook phonebook)
        {
            using (var phonebookEntities = new TestDbEntities())
            {
                phonebookEntities.UpdatePhonebookRecord(phonebook.Id, phonebook.FirstName, phonebook.LastName, phonebook.PhoneNumber, phonebook.Email, phonebook.Status);
            }
        }
    }
}
