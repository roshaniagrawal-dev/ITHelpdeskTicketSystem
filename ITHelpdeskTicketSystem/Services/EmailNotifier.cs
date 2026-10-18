using ITHelpdeskTicketSystem.Services.Interfaces;

namespace ITHelpdeskTicketSystem.Services
{
    public class EmailNotifier : INotifier
    {
        public string Send(string message)
        {
            return message + " Email sent";
        }
    }
}
