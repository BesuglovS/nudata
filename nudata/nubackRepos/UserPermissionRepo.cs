using Newtonsoft.Json;
using nudata.DomainClasses.Extra;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class UserPermissionRepo
    {
        public string ApiEndpoint;

        public UserPermissionRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<UserPermission> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/userPermission/all");

            List<UserPermission> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<UserPermission>>(StringResult);
            }
            catch (JsonException)
            {
                return null;
            }

            return result;
        }

        public UserPermission get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/userPermission/" + id.ToString());

            UserPermission result;

            try
            {
                result = JsonConvert.DeserializeObject<UserPermission>(StringResult);
            }
            catch (JsonException)
            {
                return null;
            }

            return result;
        }

        public List<string> getByName(string name)
        {
            
            List<string> result;

            try
            {
                var StringResult = ApiHelper.Get(ApiEndpoint + "/userPermission/byName/" + name);
                result = JsonConvert.DeserializeObject<List<string>>(StringResult);
            }
            catch (JsonException)
            {                
                return null;
            }

            return result;
        }
    }
}
