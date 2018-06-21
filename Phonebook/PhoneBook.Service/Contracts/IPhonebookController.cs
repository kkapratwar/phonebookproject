
namespace PhoneBook.Service.Contracts
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using Phonebook.Common;

    public interface IPhonebookController
    {
        /// <summary>
        /// Gets all the phonebook records.
        /// </summary>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        HttpResponseMessage Get();

        /// <summary>
        /// Adds the specified phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        HttpResponseMessage Post([FromBody]Phonebook phonebook);

        /// <summary>
        /// Updates the specified phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        HttpResponseMessage Put([FromBody]Phonebook phonebook);

        /// <summary>
        /// Deletes the specified phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="HttpResponseMessage"/></returns>
        HttpResponseMessage Delete(int id);
    }
}
