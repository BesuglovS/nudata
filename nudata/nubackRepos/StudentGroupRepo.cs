using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;

namespace nudata.nubackRepos
{
    public class StudentGroupRepo
    {
        public string ApiEndpoint;

        public StudentGroupRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<StudentGroup> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentGroup/all");

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

        public List<StudentGroup> facultyAll(int facultyId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentGroup/faculty/all/" + facultyId.ToString());

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

        public string add(StudentGroup group)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/studentGroup/add",
                new Dictionary<string, string>
                {
                    { "name", group.name },
                    { "from", group.from.ToString("yyyy-MM-dd") },
                    { "to", group.to.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public StudentGroup get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/studentGroup/" + id.ToString());

            StudentGroup result;

            try
            {
                result = JsonConvert.DeserializeObject<StudentGroup>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(StudentGroup group, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/studentGroup/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "name", group.name },
                    { "from", group.from.ToString("yyyy-MM-dd") },
                    { "to", group.to.ToString("yyyy-MM-dd") }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/studentGroup/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        //// Get All
        //var sgr = new StudentGroupRepo(ApiEndpoint);
        //var all = sgr.all();

        //// Get 
        //var sgr = new StudentGroupRepo(ApiEndpoint);
        //var all = sgr.get(2);

        //// Add
        //var sgr = new StudentGroupRepo(ApiEndpoint);
        //var nsg = new StudentGroup()
        //{
        //    name = "13 Б"
        //};
        //var result = sgr.add(nsg);

        //// Update
        //var sgr = new StudentGroupRepo(ApiEndpoint);
        //var sg = sgr.get(3);
        //sg.name = "14 Б";
        //var result = sgr.update(sg, sg.id);

        //// Delete 
        //var sgr = new StudentGroupRepo(ApiEndpoint);
        //var all = sgr.delete(3);
    }
}
