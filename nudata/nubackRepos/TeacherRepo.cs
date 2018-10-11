using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class TeacherRepo
    {
        public string ApiEndpoint;

        public TeacherRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Teacher> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacher/all");

            List<Teacher> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Teacher>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
        
        public string add(Teacher Teacher)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/teacher/add",
                new Dictionary<string, string>
                {
                    { "f", Teacher.f },
                    { "i", Teacher.i },
                    { "o", Teacher.o },
                    { "phone", Teacher.phone },
                    { "birth_date", Teacher.birth_date.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public Teacher get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacher/" + id.ToString());

            Teacher result;

            try
            {
                result = JsonConvert.DeserializeObject<Teacher>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Teacher Teacher, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/teacher/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "f", Teacher.f },
                    { "i", Teacher.i },
                    { "o", Teacher.o },
                    { "phone", Teacher.phone },
                    { "birth_date", Teacher.birth_date.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/teacher/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }
}
