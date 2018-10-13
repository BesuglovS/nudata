using Newtonsoft.Json;
using nudata.DomainClasses.Extra;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.nubackRepos
{
    public class DepartmentHeadRepo
    {
        public string ApiEndpoint;

        public DepartmentHeadRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<DepartmentHead> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/departmentHead/all");

            List<DepartmentHead> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<DepartmentHead>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(DepartmentHead departmentHead)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/departmentHead/add",
                new Dictionary<string, string>
                {
                    { "department_id", departmentHead.department_id.ToString() },
                    { "teacher_id", departmentHead.teacher_id.ToString() },
                    { "from", departmentHead.from.ToString("yyyy-MM-dd") },
                    { "to", departmentHead.to.ToString("yyyy-MM-dd") },
                });

            return response;
        }

        public DepartmentHead get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/departmentHead/" + id.ToString());

            DepartmentHead result;

            try
            {
                result = JsonConvert.DeserializeObject<DepartmentHead>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(DepartmentHead departmentHead, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/departmentHead/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "department_id", departmentHead.department_id.ToString() },
                    { "teacher_id", departmentHead.teacher_id.ToString() },
                    { "from", departmentHead.from.ToString("yyyy-MM-dd") },
                    { "to", departmentHead.to.ToString("yyyy-MM-dd") },
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/departmentHead/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<DepartmentHeadWithTeacherFio> departmentAll(int departmentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/departmentHead/department/" + departmentId.ToString());

            List<DepartmentHeadWithTeacherFio> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<DepartmentHeadWithTeacherFio>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
