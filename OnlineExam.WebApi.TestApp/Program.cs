using OnlineExam.CommonModels;
using System;
using System.Text;

namespace OnlineExam.WebApi.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            WebApiClient webApiClient = new WebApiClient("http://localhost:40662");

            #region Authenticate Request

            //LoginDto loginDto = new LoginDto()
            //{
            //    Username = "Admin",
            //    Password = "12345"
            //};

            //var taskResult = webApiClient.AuthenticateAsync(loginDto);
            //var loginSuccess = taskResult.Result;

            //if (loginSuccess)
            //{
            //    Console.WriteLine("Welcome!!!");
            //}
            //else
            //{
            //    Console.WriteLine("Username or password is incorrect");
            //}

            #endregion

            #region GET Request

            //var taskResult = webApiClient.GetSubjectsAsync();
            //var subjectDtos = taskResult.Result;

            //foreach (var subjectDto in subjectDtos)
            //{
            //    Console.WriteLine($"{subjectDto.ID} {subjectDto.Name}");
            //}

            #endregion

            #region GET Request with id

            //var taskResult = webApiClient.GetSubjectAsync(2);
            //var subjectDto = taskResult.Result;

            //Console.WriteLine($"{subjectDto.ID} {subjectDto.Name}");

            #endregion

            #region POST request for add

            //SubjectDto subjectDto = new SubjectDto()
            //{
            //    Name = "TEST",
            //};

            //var taskResult = webApiClient.PostSubjectAsync(subjectDto);
            //int ID = taskResult.Result;

            //Console.WriteLine("Inserted id: " + ID);

            #endregion

            #region POST request for update

            //SubjectDto subjectDto = new SubjectDto()
            //{
            //    ID = 7,
            //    Name = "TESTUpdate",
            //};

            //var taskResult = webApiClient.PostSubjectAsync(subjectDto);
            //int id = taskResult.Result;

            //Console.WriteLine("Inserted id: " + id);

            #endregion

            #region Delete request 

            //var taskResult = webApiClient.DeleteSubjectAsync(7);
            //taskResult.Wait();

            //var getTaskResult = webApiClient.GetSubjectsAsync();
            //var subjectDtos = getTaskResult.Result;

            //foreach (var subjectDto in subjectDtos)
            //{
            //    Console.WriteLine($"{subjectDto.ID} {subjectDto.Name}");
            //}

            #endregion

            //Console.WriteLine("Please press any key to terminating program");
            //Console.ReadLine();
        }
    }
}
