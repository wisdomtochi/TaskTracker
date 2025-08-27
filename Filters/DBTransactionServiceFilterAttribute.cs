using Microsoft.AspNetCore.Mvc.Filters;
using TaskTracker.Data.UnitOfWork.Interface;
using TaskTracker.Entities;

namespace TaskTracker.Filters
{
    public class DBTransactionServiceFilterAttribute : Attribute, IActionFilter
    {
        private IUnitOfWork<IEntity> _unitOfWork;
        public DBTransactionServiceFilterAttribute(IUnitOfWork<IEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null) _unitOfWork.CommitTransaction();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _unitOfWork.BeginTransaction();
        }
    }
}
