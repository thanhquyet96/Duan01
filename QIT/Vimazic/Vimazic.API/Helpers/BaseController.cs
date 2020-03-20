using AutoMapper;
using EPS.TSC.Data;
using EPS.TSC.Service;
using EPS.Utils.Repository.Audit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPS.TSC.API.Helpers
{
    public class BaseController : Controller
    {
        private Lazier<TSCContext> _context;
        protected TSCContext Context
        {
            get
            {
                if (_context == null) _context = new Lazier<TSCContext>(HttpContext.RequestServices);

                return _context.Value;
            }
        }

        private Lazier<TSCBaseService> _baseService;
        protected TSCBaseService BaseService
        {
            get
            {
                if (_baseService == null) _baseService = new Lazier<TSCBaseService>(HttpContext.RequestServices);

                return _baseService.Value;
            }
        }

        private Lazier<TSCRepository> _repository;
        protected TSCRepository Repository
        {
            get
            {
                if (_repository == null) _repository = new Lazier<TSCRepository>(HttpContext.RequestServices);

                return _repository.Value;
            }
        }

        private Lazier<IUserIdentity<int>> _userIdentity;
        protected IUserIdentity<int> UserIdentity
        {
            get
            {
                if (_userIdentity == null) _userIdentity = new Lazier<IUserIdentity<int>>(HttpContext.RequestServices);

                return _userIdentity.Value;
            }
        }

        private Lazier<IMapper> _mapper;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null) _mapper = new Lazier<IMapper>(HttpContext.RequestServices);

                return _mapper.Value;
            }
        }

        private Lazier<ILogger<BaseController>> _logger;
        protected ILogger<BaseController> Logger
        {
            get
            {
                if (_logger == null) _logger = new Lazier<ILogger<BaseController>>(HttpContext.RequestServices);

                return _logger.Value;
            }
        }

        public BaseController()
        {
        }
    }
}
