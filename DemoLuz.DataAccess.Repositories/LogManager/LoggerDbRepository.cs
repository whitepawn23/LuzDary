using DemoLuz.Core.Logger;
using DemoLuz.DataAccess.Core;
using DemoLuz.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLuz.DataAccess.Repositories.LogManager
{
    public class LoggerDbRepository : ILogger
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoggerDbRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void LogError(Exception e)
        {
            var entity = new Logger
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Type = LogType.ERROR,
                Message = e.Message,
                Source = e.Source
            };
            _unitOfWork.Repository<Logger>().Add(entity);
            _unitOfWork.Repository<Logger>().SaveChanges();
        }

        public void LogError(string error)
        {
            var entity = new Logger
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Type = LogType.ERROR,
                Message = error,
                Source = null
            };
            _unitOfWork.Repository<Logger>().Add(entity);
            _unitOfWork.Repository<Logger>().SaveChanges();
        }
    }
}
