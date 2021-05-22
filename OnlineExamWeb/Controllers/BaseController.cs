using Exam.Core.Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamWeb.Controllers
{
    public abstract  class BaseController : Controller
    {
        protected readonly IUnitOfWork DB;
        public BaseController (IUnitOfWork db)
        {
            DB = db;
        }
    }
}
