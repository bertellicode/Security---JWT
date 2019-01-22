using AutoMapper;
using Security.Application.Interfaces;
using Security.Domain.Core.Interfaces;
using Security.Domain.Core.Notifications;

namespace Security.Application.Services
{
    public class AppService : IAppService
    {
        private readonly INotificationHandler _notificationHandler;
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public AppService(IUnitOfWork unitOfWork,
                            INotificationHandler notificationHandler,
                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
            _mapper = mapper;
        }

        public bool Commit()
        {
            if (_notificationHandler.HasNotifications()) return false;

            if (_unitOfWork.Commit()) return true;

            _notificationHandler.Handle(new Notification("Commit", "Ocorreu um erro ao salvar os dados no banco"));

            return false;
        }
    }
}
