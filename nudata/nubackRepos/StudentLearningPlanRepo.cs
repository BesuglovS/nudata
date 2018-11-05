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
    class StudentLearningPlanRepo
    {
        public string ApiEndpoint;

        public StudentLearningPlanRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<StudentLearningPlan> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentLearningPlan/all");

            List<StudentLearningPlan> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<StudentLearningPlan>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(StudentLearningPlan slp)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/studentLearningPlan/add",
                new Dictionary<string, string>
                {
                    { "student_id", slp.student_id.ToString() },
                    { "learning_plan_id", slp.learning_plan_id.ToString() },
                    { "from", slp.from.ToString("yyyy-MM-dd") },
                    { "to", slp.to.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public StudentLearningPlan get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentLearningPlan/" + id.ToString());

            StudentLearningPlan result;

            try
            {
                result = JsonConvert.DeserializeObject<StudentLearningPlan>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(StudentLearningPlan slp, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/studentLearningPlan/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "student_id", slp.student_id.ToString() },
                    { "learning_plan_id", slp.learning_plan_id.ToString() },
                    { "from", slp.from.ToString("yyyy-MM-dd") },
                    { "to", slp.to.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/studentLearningPlan/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }    
}
