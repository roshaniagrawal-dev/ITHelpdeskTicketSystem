using ITHelpdeskTicketSystem.Services.Interfaces;

namespace ITHelpdeskTicketSystem.Services
{
    public class SmsNotifier : INotifier
    {
        public string Send(string message)
        {
            return message + " SMS sent.";
        }
    }
}
