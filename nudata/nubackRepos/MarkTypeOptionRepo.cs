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
    public class MarkTypeOptionRepo
    {
        public string ApiEndpoint;

        public MarkTypeOptionRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<MarkTypeOption> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markTypeOption/all");

            List<MarkTypeOption> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<MarkTypeOption>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(MarkTypeOption MarkTypeOption)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/markTypeOption/add",
                new Dictionary<string, string>
                {
                    { "mark_type_id", MarkTypeOption.mark_type_id.ToString() },
                    { "mark", MarkTypeOption.mark }
                });

            return response;
        }

        public MarkTypeOption get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markTypeOption/" + id.ToString());

            MarkTypeOption result;

            try
            {
                result = JsonConvert.DeserializeObject<MarkTypeOption>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(MarkTypeOption MarkTypeOption, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/markTypeOption/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "mark_type_id", MarkTypeOption.mark_type_id.ToString() },
                    { "mark", MarkTypeOption.mark }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/markTypeOption/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<MarkTypeOption> markTypeAll(int markTypeId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/markTypeOption/markType/" + markTypeId.ToString());

            List<MarkTypeOption> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<MarkTypeOption>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
