using AutoMapper;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Infrastructure.Presistence.UnitOfWork;

namespace Route.TechSummit.Application.Service
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
        }


    }
}
