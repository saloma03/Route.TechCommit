using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Route.TechSummit.Infrastructure.Presistence.UnitOfWork;

namespace Route.TechSummit.Application.Service
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
        }


    }
}
