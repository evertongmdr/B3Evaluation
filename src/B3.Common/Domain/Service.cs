using B3.Common.Errors;

namespace B3.Common.Domain
{
    public abstract class Service
    {
        protected readonly NotificationContext _notificationContext;
        public Service(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }
    }
}
