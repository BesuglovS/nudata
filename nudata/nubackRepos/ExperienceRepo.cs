using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class ExperienceRepo
    {
        public string ApiEndpoint;

        public ExperienceRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Experience> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/experience/all");

            List<Experience> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Experience>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(Experience Experience)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/experience/add",
                new Dictionary<string, string>
                {
                    { "type", Experience.type },
                    { "duration", Experience.duration.ToString() },
                    { "date", Experience.date.ToString("yyyy-MM-dd") },
                    { "teacher_id", Experience.teacher_id.ToString() }
                });

            return response;
        }

        public Experience get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/experience/" + id.ToString());

            Experience result;

            try
            {
                result = JsonConvert.DeserializeObject<Experience>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Experience Experience, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/experience/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "type", Experience.type },
                    { "duration", Experience.duration.ToString() },
                    { "date", Experience.date.ToString("yyyy-MM-dd") },
                    { "teacher_id", Experience.teacher_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/experience/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<Experience> teacherAll(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/experience/teacher/all/" + teacherId.ToString());

            List<Experience> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Experience>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
