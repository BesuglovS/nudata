using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class MarkTeacherRepo
    {
        public string ApiEndpoint;

        public MarkTeacherRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<MarkTeacher> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markTeacher/all");

            List<MarkTeacher> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<MarkTeacher>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(MarkTeacher MarkTeacher)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/markTeacher/add",
                new Dictionary<string, string>
                {
                    { "mark_id", MarkTeacher.mark_id.ToString() },
                    { "teacher_id", MarkTeacher.teacher_id.ToString() }
                });

            return response;
        }

        public MarkTeacher get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markTeacher/" + id.ToString());

            MarkTeacher result;

            try
            {
                result = JsonConvert.DeserializeObject<MarkTeacher>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(MarkTeacher MarkTeacher, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/markTeacher/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "mark_id", MarkTeacher.mark_id.ToString() },
                    { "teacher_id", MarkTeacher.teacher_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/markTeacher/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<MarkTeacher> markAll(int markId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markTeacher/mark/" + markId.ToString());

            List<MarkTeacher> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<MarkTeacher>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public int deleteMarkAll(int markId)
        {
            var StringResult = ApiHelper.Delete(ApiEndpoint + "/markTeacher/mark/" + markId.ToString(),
                new Dictionary<string, string>());

            int result;

            try
            {
                result = JsonConvert.DeserializeObject<int>(StringResult);
            }
            catch (Exception)
            {
                return -1;
            }

            return result;
        }
    }
}
