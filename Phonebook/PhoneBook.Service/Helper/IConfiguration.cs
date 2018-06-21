using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.Helper
{
    public interface IConfiguration
    {
        string ApiKey { get; }

        int ExpirationTime { get; }
    }
}
