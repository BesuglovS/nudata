using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class StudentRepo
    {
        public string ApiEndpoint;

        public StudentRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Student> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/student/all");

            List<Student> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Student>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;            
        }

        public List<StudentInGroup> groupAll(int groupId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/student/group/all/" + groupId.ToString());

            List<StudentInGroup> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<StudentInGroup>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public List<StudentGroup> groups(int studentId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/student/groups/" + studentId.ToString());

            List<StudentGroup> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<StudentGroup>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(Student student)
        {
            var response = 
                ApiHelper.Post(ApiEndpoint + "/student/add", 
                new Dictionary<string, string>
                {
                    { "f", student.f },
                    { "i", student.i },
                    { "o", student.o },
                    { "zach_number", student.zach_number },
                    { "birth_date", student.birth_date.ToString("yyyy-MM-dd") },
                    { "address", student.address },
                    { "phone", student.phone },
                    { "orders", student.orders },
                    { "starosta", student.starosta },
                    { "n_factor", student.n_factor },
                    { "paid_edu", student.paid_edu },
                    { "expelled", student.expelled }
                });

            return response;
        }

        public Student get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/student/" + id.ToString());

            Student result;

            try
            {
                result = JsonConvert.DeserializeObject<Student>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Student student, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/student/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "f", student.f },
                    { "i", student.i },
                    { "o", student.o },
                    { "zach_number", student.zach_number },
                    { "birth_date", student.birth_date.ToString("yyyy-MM-dd") },
                    { "address", student.address },
                    { "phone", student.phone },
                    { "orders", student.orders },
                    { "starosta", student.starosta },
                    { "n_factor", student.n_factor },
                    { "paid_edu", student.paid_edu },
                    { "expelled", student.expelled }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/student/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        //// Get All
        //var sr = new StudentRepo(ApiEndpoint);
        //var all = sr.all();

        //// Get 
        //var sr = new StudentRepo(ApiEndpoint);
        //var all = sr.get(11);

        //// Add
        //var sr = new StudentRepo(ApiEndpoint);
        //var ns = new Student() {
        //    f = "Сидоров",
        //    i = "Иван",
        //    o = "Петрович",
        //    zach_number = "12345",
        //    birth_date = new DateTime(1970, 1, 2),
        //    address = "Oxford St., 321",
        //    phone = "2322233",
        //    orders = "1 + 2 + 3",
        //    starosta = "0",
        //    n_factor = "0",
        //    paid_edu = "0",
        //    expelled = "0"
        //};            
        //var ss = sr.add(ns);

        //// Update
        //var sr = new StudentRepo(ApiEndpoint);            
        //var st = sr.get(11);
        //st.f = "Иванов3";
        //var ss = sr.update(st, st.id);

        //// Delete 
        //var sr = new StudentRepo(ApiEndpoint);
        //var all = sr.delete(11);
    }
}
