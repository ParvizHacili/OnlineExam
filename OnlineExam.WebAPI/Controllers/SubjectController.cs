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
    public class SubjectController : BaseApiController
    {
        public SubjectController(IUnitOfWork db) : base(db)
        {

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var subjects = DB.SubjectRepository.Get();

                SubjectDtoMapper subjectDtoMapper = new SubjectDtoMapper();

                List<SubjectDto> subjectDtos = new List<SubjectDto>();

                foreach (var subject in subjects)
                {
                    var subjectDto = subjectDtoMapper.Map(subject);

                    subjectDtos.Add(subjectDto);
                }

                return Ok(subjectDtos);
            }
            catch (Exception exc)
            {
                // TODO: log exception message here
                return BadRequest("Internal Server Error");
            }
        }

       [HttpGet]
       [Route("Get/{ID}")]
        public IActionResult Get(int ID)
        {
            try
            {
                var subject = DB.SubjectRepository.Get(ID);

                if(subject==null)
                {
                    return BadRequest("Axtardığınız Fənn mövcüd deyil!");
                }

                SubjectDtoMapper subjectDtoMapper = new SubjectDtoMapper();

                SubjectDto subjectDto = subjectDtoMapper.Map(subject);

                return Ok(subjectDto);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }
        //(Post add, Put update)
        [HttpPost]
        public IActionResult Post(SubjectDto subjectDto)
        {
            try
            {
                // STEP 1. Validate branchDto

                SubjectDtoMapper subjectDtoMapper = new SubjectDtoMapper();

                Subject subject = subjectDtoMapper.Map(subjectDto);

                subject.Creator = new User() { ID = 1 }; // TODO: Use identity user here

                if (subject.ID == 0)
                {
                    subject.ID = DB.SubjectRepository.Add(subject);
                }
                else
                {
                    DB.SubjectRepository.Update(subject);
                }

                return Ok(subject.ID);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{ID}")]
        public IActionResult Delete(int ID)
        {
            try
            {
                var subject = DB.SubjectRepository.Get(ID);

                if(subject==null)
                {
                    return BadRequest("Axtardığınız Fənn mövcüd deyil!");
                }

                subject.IsDeleted = true;
                subject.Creator = new User() { ID = 1 };

                DB.SubjectRepository.Update(subject);

                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }
    }
}
