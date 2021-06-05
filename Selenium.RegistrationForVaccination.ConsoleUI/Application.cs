using Selenium.RegistrationForVaccination.Infrastructure;

namespace Selenium.RegistrationForVaccination.ConsoleUI
{
    public class Application
    {
        private readonly IRegisterForVisit registerForVisit;

        public Application(IRegisterForVisit registerForVisit)
        {
            this.registerForVisit = registerForVisit;
        }

        public void Run()
        {
            registerForVisit.Register();
        }
    }
}
