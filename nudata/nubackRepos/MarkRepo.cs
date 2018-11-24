using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class MarkRepo
    {
        public string ApiEndpoint;

        public MarkRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Mark> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/mark/all");

            List<Mark> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Mark>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(Mark Mark)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/mark/add",
                new Dictionary<string, string>
                {
                    { "student_id", Mark.student_id.ToString() },
                    { "learning_plan_discipline_semester_id", Mark.learning_plan_discipline_semester_id.ToString() },
                    { "attestation_type", Mark.attestation_type },
                    { "mark_type_id", Mark.mark_type_id.ToString() },
                    { "mark_type_option_id", Mark.mark_type_option_id.ToString() },
                    { "date", Mark.date.ToString("yyyy-MM-dd") },
                    { "attempt", Mark.attempt.ToString() },
                    { "attestation_mark_type_option_id", Mark.attestation_mark_type_option_id.ToString() },
                    { "semester_rate", Mark.semester_rate.ToString() }

                });

            return response;
        }

        public Mark get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/mark/" + id.ToString());

            Mark result;

            try
            {
                result = JsonConvert.DeserializeObject<Mark>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Mark Mark, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/mark/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "student_id", Mark.student_id.ToString() },
                    { "learning_plan_discipline_semester_id", Mark.learning_plan_discipline_semester_id.ToString() },
                    { "attestation_type", Mark.attestation_type },
                    { "mark_type_id", Mark.mark_type_id.ToString() },
                    { "mark_type_option_id", Mark.mark_type_option_id.ToString() },
                    { "date", Mark.date.ToString("yyyy-MM-dd") },
                    { "attempt", Mark.attempt.ToString() },
                    { "attestation_mark_type_option_id", Mark.attestation_mark_type_option_id.ToString() },
                    { "semester_rate", Mark.semester_rate.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/mark/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<Mark> studentAll(int studentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/mark/student/" + studentId.ToString());

            List<Mark> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Mark>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
