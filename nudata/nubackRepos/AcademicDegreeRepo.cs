using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class AcademicDegreeRepo
    {
        public string ApiEndpoint;

        public AcademicDegreeRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<AcademicDegree> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/academicDegree/all");

            List<AcademicDegree> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<AcademicDegree>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(AcademicDegree AcademicDegree)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/academicDegree/add",
                new Dictionary<string, string>
                {
                    { "degree", AcademicDegree.degree },
                    { "science_field", AcademicDegree.science_field },
                    { "date", AcademicDegree.date.ToString("yyyy-MM-dd") },
                    { "teacher_id", AcademicDegree.teacher_id.ToString() }
                });

            return response;
        }

        public AcademicDegree get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/academicDegree/" + id.ToString());

            AcademicDegree result;

            try
            {
                result = JsonConvert.DeserializeObject<AcademicDegree>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(AcademicDegree AcademicDegree, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/academicDegree/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "degree", AcademicDegree.degree },
                    { "science_field", AcademicDegree.science_field },
                    { "date", AcademicDegree.date.ToString("yyyy-MM-dd") },
                    { "teacher_id", AcademicDegree.teacher_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/academicDegree/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<AcademicDegree> teacherAll(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/academicDegree/teacher/all/" + teacherId.ToString());

            List<AcademicDegree> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<AcademicDegree>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
