using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Abstract
{
    public interface IUserRepository
    {
        User Get(string username);

    }
}
