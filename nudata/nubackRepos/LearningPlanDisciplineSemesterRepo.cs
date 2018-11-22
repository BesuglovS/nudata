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
    class LearningPlanDisciplineSemesterRepo
    {
        public string ApiEndpoint;

        public LearningPlanDisciplineSemesterRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<LearningPlanDisciplineSemester> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDisciplineSemester/all");

            List<LearningPlanDisciplineSemester> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<LearningPlanDisciplineSemester>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(LearningPlanDisciplineSemester LearningPlanDisciplineSemester)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/learningPlanDisciplineSemester/add",
                new Dictionary<string, string>
                {
                    { "semester", LearningPlanDisciplineSemester.semester.ToString() },
                    { "lecture_hours", LearningPlanDisciplineSemester.lecture_hours.ToString() },
                    { "lab_hours", LearningPlanDisciplineSemester.lab_hours.ToString() },
                    { "practice_hours", LearningPlanDisciplineSemester.practice_hours.ToString() },
                    { "independent_work_hours", LearningPlanDisciplineSemester.independent_work_hours.ToString() },
                    { "control_hours", LearningPlanDisciplineSemester.control_hours.ToString() },
                    { "z_count", LearningPlanDisciplineSemester.z_count.ToString() },
                    { "zachet", LearningPlanDisciplineSemester.zachet ? "1" : "0" },
                    { "exam", LearningPlanDisciplineSemester.exam ? "1" : "0" },
                    { "zachet_with_mark", LearningPlanDisciplineSemester.zachet_with_mark ? "1" : "0" },
                    { "course_project", LearningPlanDisciplineSemester.course_project ? "1" : "0" },
                    { "course_task", LearningPlanDisciplineSemester.course_task ? "1" : "0" },
                    { "control_task", LearningPlanDisciplineSemester.control_task ? "1" : "0" },
                    { "referat", LearningPlanDisciplineSemester.referat ? "1" : "0" },
                    { "essay", LearningPlanDisciplineSemester.essay ? "1" : "0" },
                    { "individual_hours", LearningPlanDisciplineSemester.individual_hours.ToString() },
                    { "learning_plan_discipline_id", LearningPlanDisciplineSemester.learning_plan_discipline_id.ToString() },
                });

            return response;
        }

        public LearningPlanDisciplineSemester get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDisciplineSemester/" + id.ToString());

            LearningPlanDisciplineSemester result;

            try
            {
                result = JsonConvert.DeserializeObject<LearningPlanDisciplineSemester>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(LearningPlanDisciplineSemester LearningPlanDisciplineSemester, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/learningPlanDisciplineSemester/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "semester", LearningPlanDisciplineSemester.semester.ToString() },
                    { "lecture_hours", LearningPlanDisciplineSemester.lecture_hours.ToString() },
                    { "lab_hours", LearningPlanDisciplineSemester.lab_hours.ToString() },
                    { "practice_hours", LearningPlanDisciplineSemester.practice_hours.ToString() },
                    { "independent_work_hours", LearningPlanDisciplineSemester.independent_work_hours.ToString() },
                    { "control_hours", LearningPlanDisciplineSemester.control_hours.ToString() },
                    { "z_count", LearningPlanDisciplineSemester.z_count.ToString() },
                    { "zachet", LearningPlanDisciplineSemester.zachet ? "1" : "0" },
                    { "exam", LearningPlanDisciplineSemester.exam ? "1" : "0" },
                    { "zachet_with_mark", LearningPlanDisciplineSemester.zachet_with_mark ? "1" : "0" },
                    { "course_project", LearningPlanDisciplineSemester.course_project ? "1" : "0" },
                    { "course_task", LearningPlanDisciplineSemester.course_task ? "1" : "0" },
                    { "control_task", LearningPlanDisciplineSemester.control_task ? "1" : "0" },
                    { "referat", LearningPlanDisciplineSemester.referat ? "1" : "0" },
                    { "essay", LearningPlanDisciplineSemester.essay ? "1" : "0" },
                    { "individual_hours", LearningPlanDisciplineSemester.individual_hours.ToString() },
                    { "learning_plan_discipline_id", LearningPlanDisciplineSemester.learning_plan_discipline_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/learningPlanDisciplineSemester/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<LearningPlanDisciplineSemester> learningPlanDisciplineAll(int learningPlanDisciplineId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDisciplineSemester/learningPlanDiscipline/" + learningPlanDisciplineId.ToString());

            List<LearningPlanDisciplineSemester> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<LearningPlanDisciplineSemester>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<LearningPlanDisciplineSemester> learningPlanAll(int learningPlanId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/learningPlanDisciplineSemester/learningPlan/" + learningPlanId.ToString());

            List<LearningPlanDisciplineSemester> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<LearningPlanDisciplineSemester>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
