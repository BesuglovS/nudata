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
    public class NoteRepo
    {
        public string ApiEndpoint;

        public NoteRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<Note> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/note/all");

            List<Note> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<Note>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(Note Note)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/note/add",
                new Dictionary<string, string>
                {
                    { "text", Note.text }
                });

            return response;
        }

        public Note get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/note/" + id.ToString());

            Note result;

            try
            {
                result = JsonConvert.DeserializeObject<Note>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(Note Note, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/note/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "text", Note.text }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/note/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }
    }
}
