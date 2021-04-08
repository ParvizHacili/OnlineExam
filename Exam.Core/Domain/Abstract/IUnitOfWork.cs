using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

    }
}
