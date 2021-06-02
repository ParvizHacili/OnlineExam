using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.CommonModels;
using OnlineExam.WebAPI.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.WebAPI.Controllers
{
    [ApiController]
    public class ExamController : BaseApiController
    {
        public ExamController(IUnitOfWork db) :base(db)
        {
            
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var exams = DB.ExamRepository.Get();

                ExamDtoMapper examDtoMapper = new ExamDtoMapper();

                List<ExamDto> examDtos = new List<ExamDto>();

                foreach (var exam in exams)
                {
                    var examDto = examDtoMapper.Map(exam);

                    examDtos.Add(examDto);
                }

                return Ok(examDtos);
            }
            catch (Exception exc)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet]
        [Route("Get/{ID}")]
        public IActionResult Get(int ID)
        {
            try
            {
                var exam = DB.ExamRepository.Get(ID);

                if (exam == null)
                {
                    return BadRequest("İmtahan növü Mövcud Deyil");
                }

                ExamDtoMapper examDtoMapper = new ExamDtoMapper();
                ExamDto examDto = new ExamDto();

                return Ok(examDto);               
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(ExamDto examDto)
        {
            try
            {
                ExamDtoMapper examDtoMapper = new ExamDtoMapper();
                Exam1 exam = examDtoMapper.Map(examDto);
                exam.Creator = new User() { ID = 1 };

                if(examDto.ID==0)
                {
                   exam.ID=DB.ExamRepository.Add(exam);
                }
                else
                {
                    DB.ExamRepository.Update(exam);
                }

                return Ok(exam.ID);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        public IActionResult Delete(int ID)
        {
            try
            {
                var exam = DB.ExamRepository.Get(ID);

                if(exam==null)
                {
                    return BadRequest("Axtardığınız İmtahan Növü Mövcud Deyil");
                }
                exam.IsDeleted = true;
                exam.Creator = new User() { ID = 1 };

                DB.ExamRepository.Update(exam);

                return Ok();
            }
            catch(Exception exc)
            {
                return BadRequest();
            }
        }
    }
}
