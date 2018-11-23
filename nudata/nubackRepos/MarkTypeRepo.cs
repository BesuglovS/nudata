using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class MarkTypeRepo
    {
        public string ApiEndpoint;

        public MarkTypeRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<MarkType> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markType/all");

            List<MarkType> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<MarkType>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(MarkType MarkType)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/markType/add",
                new Dictionary<string, string>
                {
                    { "name", MarkType.name }
                });

            return response;
        }

        public MarkType get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markType/" + id.ToString());

            MarkType result;

            try
            {
                result = JsonConvert.DeserializeObject<MarkType>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(MarkType MarkType, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/markType/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "name", MarkType.name }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/markType/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }
}
