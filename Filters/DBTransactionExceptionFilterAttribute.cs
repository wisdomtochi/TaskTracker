using Microsoft.AspNetCore.Mvc.Filters;
using TaskTracker.Data.UnitOfWork.Interface;
using TaskTracker.Entities;

namespace TaskTracker.Filters
{
    public class DBTransactionExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private IUnitOfWork<IEntity> _unitOfWork;

        public DBTransactionExceptionFilterAttribute(IUnitOfWork<IEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnException(ExceptionContext context)
        {
            _unitOfWork.RollbackTransaction();
        }
    }
}
