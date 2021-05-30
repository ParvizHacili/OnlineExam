using Newtonsoft.Json;
using OnlineExam.CommonModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.WebApi.TestApp
{
    public class WebApiClient
    {
        private readonly string WebApiAddress;

        private static HttpClient client = new HttpClient();

        public WebApiClient(string webApiAddress)
        {
            WebApiAddress = webApiAddress;
        }

        public async Task<bool> AuthenticateAsync(LoginDto loginDto)
        {
            string uri = $"{WebApiAddress}/account/authenticate";

            string postJson = JsonConvert.SerializeObject(loginDto);

            HttpContent content = new StringContent(postJson, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(uri, content);

            if (result.IsSuccessStatusCode)
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<SubjectDto>> GetSubjectsAsync()
        {
            string uri = $"{WebApiAddress}/subject/getall";

            HttpResponseMessage result = await client.GetAsync(uri);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json))
                    return new List<SubjectDto>();

                var subjectDtos = JsonConvert.DeserializeObject<List<SubjectDto>>(json);

                return subjectDtos;
            }
            else
            {
                throw new Exception("Exception occured");
            }
        }

        public async Task<SubjectDto> GetSubjectAsync(int ID)
        {
            string uri = $"{WebApiAddress}/subject/get/{ID}";
            HttpResponseMessage result = await client.GetAsync(uri);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json))
                    return null;

                var subjectDto = JsonConvert.DeserializeObject<SubjectDto>(json);

                return subjectDto;
            }
            else
            {
                throw new Exception("Exception occured");
            }
        }

        public async Task<int> PostSubjectAsync(SubjectDto subjectDto)
        {
            string uri = $"{WebApiAddress}/subject";

            string postJson = JsonConvert.SerializeObject(subjectDto);

            HttpContent content = new StringContent(postJson, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(uri, content);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json))
                    return 0;

                var id = JsonConvert.DeserializeObject<int>(json);

                return id;
            }
            else
            {
                throw new Exception("Exception occured");
            }
        }

        public async Task DeleteSubjectAsync(int id)
        {
            string uri = $"{WebApiAddress}/subject/{id}";

            var result = await client.DeleteAsync(uri);

            if (result.IsSuccessStatusCode == false)
            {
                throw new Exception("Exception occured");
            }
        }
    }
}
