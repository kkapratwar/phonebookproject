using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Phonebook.TestUI.Startup))]
namespace Phonebook.TestUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
