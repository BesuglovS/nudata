using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class AcademicRankRepo
    {
        public string ApiEndpoint;

        public AcademicRankRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<AcademicRank> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/academicRank/all");

            List<AcademicRank> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<AcademicRank>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(AcademicRank AcademicRank)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/academicRank/add",
                new Dictionary<string, string>
                {
                    { "rank", AcademicRank.rank },
                    { "date", AcademicRank.date.ToString("yyyy-MM-dd") },
                    { "teacher_id", AcademicRank.teacher_id.ToString() }
                });

            return response;
        }

        public AcademicRank get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/academicRank/" + id.ToString());

            AcademicRank result;

            try
            {
                result = JsonConvert.DeserializeObject<AcademicRank>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(AcademicRank AcademicRank, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/academicRank/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "rank", AcademicRank.rank },
                    { "date", AcademicRank.date.ToString("yyyy-MM-dd") },
                    { "teacher_id", AcademicRank.teacher_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/academicRank/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<AcademicRank> teacherAll(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/academicRank/teacher/all/" + teacherId.ToString());

            List<AcademicRank> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<AcademicRank>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
