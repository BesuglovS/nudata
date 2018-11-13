using Newtonsoft.Json;
using nudata.DomainClasses.Extra;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class DepartmentRepo
    {
        public string ApiEndpoint;

        public DepartmentRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Department> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/department/all");

            List<Department> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Department>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }        

        public string add(Department department)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/department/add",
                new Dictionary<string, string>
                {
                    { "name", department.name }
                });

            return response;
        }

        public Department get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/department/" + id.ToString());

            Department result;

            try
            {
                result = JsonConvert.DeserializeObject<Department>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Department department, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/department/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "name", department.name }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/department/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public DepartmentYearPositionRates rateHours(int year, int departmentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/department/rateHours/" + year.ToString() + "/" + departmentId.ToString());

            DepartmentYearPositionRates result;

            try
            {
                result = JsonConvert.DeserializeObject<DepartmentYearPositionRates>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
