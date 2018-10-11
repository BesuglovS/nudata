using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class FacultyRepo
    {
        public string ApiEndpoint;

        public FacultyRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Faculty> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/faculty/all");

            List<Faculty> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Faculty>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
        
        public string add(Faculty Faculty)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/faculty/add",
                new Dictionary<string, string>
                {
                    { "name", Faculty.name },
                    { "letter", Faculty.letter },
                    { "sorting_order", Faculty.sorting_order.ToString() }
                });

            return response;
        }

        public Faculty get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/faculty/" + id.ToString());

            Faculty result;

            try
            {
                result = JsonConvert.DeserializeObject<Faculty>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Faculty Faculty, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/faculty/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "name", Faculty.name },
                    { "letter", Faculty.letter },
                    { "sorting_order", Faculty.sorting_order.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/faculty/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }
}
