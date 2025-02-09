

using FluentValidation.Results;
using System.Net;

namespace B3.Common.Errors
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool TemNotificacoes => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotificacao(string message, HttpStatusCode erroCode = HttpStatusCode.BadRequest)
        {
            _notifications.Add(new Notification(message, erroCode));
        }

        public void AddNotificacao(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotificacoes(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddNotificacao(error.ErrorMessage);

        }
    }
}
