using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using nudata.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.nubackRepos
{
    public class TeacherCardRepo
    {
        public string ApiEndpoint;

        public TeacherCardRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<TeacherCard> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/all");

            List<TeacherCard> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCard>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(TeacherCard TeacherCard)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/teacherCard/add",
                new Dictionary<string, string>
                {
                    { "teacher_id", TeacherCard.teacher_id.ToString() },
                    { "position", TeacherCard.position },
                    { "academic_degree", TeacherCard.academic_degree },
                    { "academic_rank", TeacherCard.academic_rank },
                    { "department_rank", TeacherCard.department_rank },
                    { "department_id", TeacherCard.department_id.ToString() },
                    { "position_type", TeacherCard.position_type },
                    { "starting_year", TeacherCard.starting_year.ToString() }
                });

            return response;
        }

        public TeacherCard get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/" + id.ToString());

            TeacherCard result;

            try
            {
                result = JsonConvert.DeserializeObject<TeacherCard>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(TeacherCard TeacherCard, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/teacherCard/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "teacher_id", TeacherCard.teacher_id.ToString() },
                    { "position", TeacherCard.position },
                    { "academic_degree", TeacherCard.academic_degree },
                    { "academic_rank", TeacherCard.academic_rank },
                    { "department_rank", TeacherCard.department_rank },
                    { "department_id", TeacherCard.department_id.ToString() },
                    { "position_type", TeacherCard.position_type },
                    { "starting_year", TeacherCard.starting_year.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/teacherCard/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<int> allYears()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/allYears");

            List<int> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<int>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<TeacherCard> teacher(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/teacher/" + teacherId.ToString());

            List<TeacherCard> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCard>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<TeacherCard> year(int year)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/year/" + year.ToString());

            List<TeacherCard> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCard>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<TeacherCard> departmentId(int departmentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/departmentId/" + departmentId.ToString());

            List<TeacherCard> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCard>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<TeacherCard> yearDepartmentId(int year, int departmentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/yearDepartmentId/" + year.ToString() + "/" + departmentId.ToString());

            List<TeacherCard> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCard>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<TeacherCardJoined> yearDepartmentIdJoined(int year, int departmentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/yearDepartmentIdJoined/" + year.ToString() + "/" + departmentId.ToString());

            List<TeacherCardJoined> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCardJoined>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<int> yearDepartmentIds(int year)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCard/yearDepartmentIds/" + year.ToString());

            List<int> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<int>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
