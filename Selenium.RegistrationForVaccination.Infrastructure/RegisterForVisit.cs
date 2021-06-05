using Selenium.RegistrationForVaccination.Infrastructure.Selenium.BrowserFlows;

namespace Selenium.RegistrationForVaccination.Infrastructure
{
    public class RegisterForVisit : IRegisterForVisit
    {
        private readonly IBrowserFlow browserFlow;

        public RegisterForVisit(IBrowserFlow browserFlow)
        {
            this.browserFlow = browserFlow;
        }
        public void Register()
        {
            browserFlow.FollowTheSteps();
        }
    }
}
