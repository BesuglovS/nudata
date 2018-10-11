using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nudata.Net
{
    public static class ApiHelper
    {
        public static string Get(string url)
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential(StartupForm.username, StartupForm.password);
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string StringResult = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return StringResult;
        }

        public static string Post(string url, Dictionary<string, string> requestParams)
        {
            var client = new WebClient();
            client.Credentials = new NetworkCredential(StartupForm.username, StartupForm.password);

            var method = "POST";

            var parameters = new NameValueCollection();
            foreach (var kvp in requestParams)
            {
                parameters.Add(kvp.Key, kvp.Value);
            }

            /* Always returns a byte[] array data as a response. */
            var response_data = client.UploadValues(url, method, parameters);

            // Parse the returned data (if any) if needed.
            var responseString = Encoding.UTF8.GetString(response_data);

            return responseString;
        }

        public static string Delete(string url, Dictionary<string, string> requestParams)
        {
            var client = new WebClient();
            client.Credentials = new NetworkCredential(StartupForm.username, StartupForm.password);

            var method = "DELETE";

            var parameters = new NameValueCollection();
            foreach (var kvp in requestParams)
            {
                parameters.Add(kvp.Key, kvp.Value);
            }

            /* Always returns a byte[] array data as a response. */
            var response_data = client.UploadValues(url, method, parameters);

            // Parse the returned data (if any) if needed.
            var responseString = Encoding.UTF8.GetString(response_data);

            return responseString;
        }
    }
}
