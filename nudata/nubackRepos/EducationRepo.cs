using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class EducationRepo
    {
        public string ApiEndpoint;

        public EducationRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Education> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/education/all");

            List<Education> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Education>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(Education Education)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/education/add",
                new Dictionary<string, string>
                {
                    { "level", Education.level },
                    { "specialty", Education.specialty },
                    { "qualification", Education.qualification },
                    { "year", Education.year.ToString() },
                    { "teacher_id", Education.teacher_id.ToString() }
                });

            return response;
        }

        public Education get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/education/" + id.ToString());

            Education result;

            try
            {
                result = JsonConvert.DeserializeObject<Education>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Education Education, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/education/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "level", Education.level },
                    { "specialty", Education.specialty },
                    { "qualification", Education.qualification },
                    { "year", Education.year.ToString() },
                    { "teacher_id", Education.teacher_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/education/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<Education> teacherAll(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/education/teacher/all/" + teacherId.ToString());

            List<Education> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Education>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
