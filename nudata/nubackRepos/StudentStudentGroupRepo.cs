using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    class StudentStudentGroupRepo
    {
        public string ApiEndpoint;

        public StudentStudentGroupRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<StudentStudentGroup> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentStudentGroup/all");

            List<StudentStudentGroup> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<StudentStudentGroup>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(StudentStudentGroup ssg)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/studentStudentGroup/add",
                new Dictionary<string, string>
                {
                    { "student_id", ssg.student_id.ToString() },
                    { "student_group_id", ssg.student_group_id.ToString() },
                    { "from", ssg.from.ToString("yyyy-MM-dd") },
                    { "to", ssg.to.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public StudentStudentGroup get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentStudentGroup/" + id.ToString());

            StudentStudentGroup result;

            try
            {
                result = JsonConvert.DeserializeObject<StudentStudentGroup>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(StudentStudentGroup ssg, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/studentStudentGroup/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "student_id", ssg.student_id.ToString() },
                    { "student_group_id", ssg.student_group_id.ToString() },
                    { "from", ssg.from.ToString("yyyy-MM-dd") },
                    { "to", ssg.to.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/studentStudentGroup/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }


        //// Get All
        //var rp = new StudentStudentGroupRepo(ApiEndpoint);
        //var all = rp.all();

        //// Get 
        //var rp = new StudentStudentGroupRepo(ApiEndpoint);
        //var all = rp.get(2);

        //// Add
        //var rp = new StudentStudentGroupRepo(ApiEndpoint);
        //var nsg = new StudentStudentGroup()
        //{
        //    student_id = 1,
        //    student_group_id = 2,
        //    from = new DateTime(2018, 9, 1),
        //    to = new DateTime(2019, 6, 30)
        //};
        //var result = rp.add(nsg);

        //// Update
        //var rp = new StudentStudentGroupRepo(ApiEndpoint);
        //var ssg = rp.get(3);
        //ssg.to = new DateTime(2019, 8, 31);
        //var result = rp.update(ssg, ssg.id);

        //// Delete 
        //var rp = new StudentStudentGroupRepo(ApiEndpoint);
        //var all = rp.delete(3);
    }
}
