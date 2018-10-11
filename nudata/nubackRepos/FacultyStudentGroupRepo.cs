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
    public class FacultyStudentGroupRepo
    {
        public string ApiEndpoint;

        public FacultyStudentGroupRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<FacultyStudentGroup> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/facultyStudentGroup/all");

            List<FacultyStudentGroup> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<FacultyStudentGroup>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(FacultyStudentGroup fsg)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/facultyStudentGroup/add",
                new Dictionary<string, string>
                {
                    { "faculty_id", fsg.faculty_id.ToString() },
                    { "student_group_id", fsg.student_group_id.ToString() }                    
                });

            return response;
        }

        public FacultyStudentGroup get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/facultyStudentGroup/" + id.ToString());

            FacultyStudentGroup result;

            try
            {
                result = JsonConvert.DeserializeObject<FacultyStudentGroup>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(FacultyStudentGroup fsg, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/facultyStudentGroup/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "student_id", fsg.faculty_id.ToString() },
                    { "student_group_id", fsg.student_group_id.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/facultyStudentGroup/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }
}
