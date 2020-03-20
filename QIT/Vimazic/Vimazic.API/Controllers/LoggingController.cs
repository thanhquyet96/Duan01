using EPS.TSC.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using EPS.TSC.API.Helpers;
using EPS.TSC.Data.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;
using EPS.TSC.Service.Dtos.Common;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using EPS.TSC.Data.Logging;
using EPS.Utils.Repository.Audit;
using System.Security.Claims;
using EPS.TSC.Service.Dtos.Log;
using EPS.Utils.Service;
using EPS.Utils.Common;
using AutoMapper;
using System.Linq.Dynamic.Core;

namespace EPS.TSC.API.Controllers
{
    [Produces("application/json")]
    [Route("api/logging")]
    [Authorize]
    public class LoggingController : BaseController
    {
        private Lazier<LoggingContext> _loggingContext;
        protected IMapper _mapper;
        protected LoggingContext LoggingContext
        {
            get
            {
                if (_loggingContext == null) _loggingContext = new Lazier<LoggingContext>(HttpContext.RequestServices);

                return _loggingContext.Value;
            }
        }
        public LoggingController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Ok(await LoggingContext.SYSTEM_LOGS.ToListAsync());
        }
    
        public async virtual Task<PagingResult<TDto>> FilterPagedAsync<TEntity, TDto>(PagingParams<TDto> pagingParams, params Expression<Func<TDto, bool>>[] predicates)
            where TEntity : class
        {
            if (pagingParams == null)
            {
                throw new ArgumentNullException("pagingParams");
            }

            var result = new PagingResult<TDto>() { PageSize = pagingParams.ItemsPerPage, CurrentPage = pagingParams.Page };

            IQueryable<TDto> query = LoggingContext.Set<TEntity>().ProjectTo<TDto>(_mapper.ConfigurationProvider);

            var pagingPredicates = pagingParams.GetPredicates();
            if (pagingPredicates != null && pagingPredicates.Any())
            {
                query = query.WhereMany(pagingPredicates);
            }

            if (predicates != null && predicates.Any())
            {
                query = query.WhereMany(predicates);
            }

            result.TotalRows = await query.CountAsync();

            // Ordering
            if (pagingParams.SortExpression != null)
            {
                query = query.OrderBy(pagingParams.SortExpression);

                // Skipping only work after ordering
                if (pagingParams.StartingIndex > 0)
                {
                    query = query.Skip(pagingParams.StartingIndex);
                }
            }

            if (pagingParams.ItemsPerPage != -1 && pagingParams.ItemsPerPage <= 0)
            {
                pagingParams.ItemsPerPage = 100;
            }

            if (pagingParams.ItemsPerPage > 0)
            {
                query = query.Take(pagingParams.ItemsPerPage);
            }

            result.Data = await query.ToListAsync();

            return result;
        }
    }
}
