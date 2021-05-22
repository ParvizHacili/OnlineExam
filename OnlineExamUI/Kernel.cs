using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core
{
    public static class Kernel
    {
        public static User CurrentUser;
        public static IUnitOfWork DB;
    }
}
