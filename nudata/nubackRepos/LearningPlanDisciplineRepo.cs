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
    public class LearningPlanDisciplineRepo
    {
        public string ApiEndpoint;

        public LearningPlanDisciplineRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<LearningPlanDiscipline> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDiscipline/all");

            List<LearningPlanDiscipline> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<LearningPlanDiscipline>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(LearningPlanDiscipline LearningPlanDiscipline)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/learningPlanDiscipline/add",
                new Dictionary<string, string>
                {
                    { "code", LearningPlanDiscipline.code },
                    { "name", LearningPlanDiscipline.name },
                    { "total_hours", LearningPlanDiscipline.total_hours.ToString() },
                    { "contact_work_hours", LearningPlanDiscipline.contact_work_hours.ToString() },
                    { "independent_work_hours", LearningPlanDiscipline.independent_work_hours.ToString() },
                    { "control_hours", LearningPlanDiscipline.control_hours.ToString() },
                    { "z_count", LearningPlanDiscipline.z_count.ToString() },
                    { "learning_plan_id", LearningPlanDiscipline.learning_plan_id.ToString() },
                    { "order", LearningPlanDiscipline.order.ToString() }
                });

            return response;
        }

        public LearningPlanDiscipline get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDiscipline/" + id.ToString());

            LearningPlanDiscipline result;

            try
            {
                result = JsonConvert.DeserializeObject<LearningPlanDiscipline>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(LearningPlanDiscipline LearningPlanDiscipline, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/learningPlanDiscipline/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "code", LearningPlanDiscipline.code },
                    { "name", LearningPlanDiscipline.name },
                    { "total_hours", LearningPlanDiscipline.total_hours.ToString() },
                    { "contact_work_hours", LearningPlanDiscipline.contact_work_hours.ToString() },
                    { "independent_work_hours", LearningPlanDiscipline.independent_work_hours.ToString() },
                    { "control_hours", LearningPlanDiscipline.control_hours.ToString() },
                    { "z_count", LearningPlanDiscipline.z_count.ToString() },
                    { "learning_plan_id", LearningPlanDiscipline.learning_plan_id.ToString() },
                    { "order", LearningPlanDiscipline.order.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/learningPlanDiscipline/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<LearningPlanDiscipline> learningPlanAll(int learningPlanId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDiscipline/learningPlan/" + learningPlanId.ToString());

            List<LearningPlanDiscipline> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<LearningPlanDiscipline>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
