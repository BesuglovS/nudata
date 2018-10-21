using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.nubackRepos
{
    public class LearningPlanRepo
    {
        public string ApiEndpoint;

        public LearningPlanRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<LearningPlan> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlan/all");

            List<LearningPlan> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<LearningPlan>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(LearningPlan LearningPlan)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/learningPlan/add",
                new Dictionary<string, string>
                {
                    { "speciality_code", LearningPlan.speciality_code },
                    { "speciality_name", LearningPlan.speciality_name },
                    { "profile", LearningPlan.profile },
                    { "starting_year", LearningPlan.starting_year.ToString() },
                    { "education_standard", LearningPlan.education_standard },
                    { "faculty_id", LearningPlan.faculty_id.ToString() }
                });

            return response;
        }

        public LearningPlan get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlan/" + id.ToString());

            LearningPlan result;

            try
            {
                result = JsonConvert.DeserializeObject<LearningPlan>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(LearningPlan LearningPlan, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/learningPlan/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "speciality_code", LearningPlan.speciality_code },
                    { "speciality_name", LearningPlan.speciality_name },
                    { "profile", LearningPlan.profile },
                    { "starting_year", LearningPlan.starting_year.ToString() },
                    { "education_standard", LearningPlan.education_standard },
                    { "faculty_id", LearningPlan.faculty_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/learningPlan/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }
}
