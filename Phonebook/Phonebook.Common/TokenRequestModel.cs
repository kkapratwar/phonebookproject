using System;

namespace PhoneBook.Common
{
    public class TokenRequestModel
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTime ExpirationTime { get; set; }
    }
}