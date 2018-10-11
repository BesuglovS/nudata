using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class PositionRepo
    {
        public string ApiEndpoint;

        public PositionRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Position> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/position/all");

            List<Position> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Position>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(Position Position)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/position/add",
                new Dictionary<string, string>
                {
                    { "type", Position.type },
                    { "position", Position.position },
                    { "department", Position.department },
                    { "order", Position.order },
                    { "elected", Position.elected ? "1" : "0" },
                    { "election_protocol", Position.election_protocol },
                    { "teacher_id", Position.teacher_id.ToString() }
                });

            return response;
        }

        public Position get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/position/" + id.ToString());

            Position result;

            try
            {
                result = JsonConvert.DeserializeObject<Position>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Position Position, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/position/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "type", Position.type },
                    { "position", Position.position },
                    { "department", Position.department },
                    { "order", Position.order },
                    { "elected", Position.elected ? "1" : "0" },
                    { "election_protocol", Position.election_protocol },
                    { "teacher_id", Position.teacher_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/position/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<Position> teacherAll(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/position/teacher/all/" + teacherId.ToString());

            List<Position> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Position>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

    }
}
