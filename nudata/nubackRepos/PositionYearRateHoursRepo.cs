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
    public class PositionYearRateHoursRepo
    {
        public string ApiEndpoint;

        public PositionYearRateHoursRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<PositionYearRateHours> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/positionYearRateHours/all");

            List<PositionYearRateHours> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<PositionYearRateHours>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(PositionYearRateHours PositionYearRateHours)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/positionYearRateHours/add",
                new Dictionary<string, string>
                {
                    { "year", PositionYearRateHours.year.ToString() },
                    { "position", PositionYearRateHours.position },
                    { "rate_hours", PositionYearRateHours.rate_hours.ToString() }
                });

            return response;
        }

        public PositionYearRateHours get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/positionYearRateHours/" + id.ToString());

            PositionYearRateHours result;

            try
            {
                result = JsonConvert.DeserializeObject<PositionYearRateHours>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(PositionYearRateHours PositionYearRateHours, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/positionYearRateHours/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "year", PositionYearRateHours.year.ToString() },
                    { "position", PositionYearRateHours.position },
                    { "rate_hours", PositionYearRateHours.rate_hours.ToString() }
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/positionYearRateHours/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<int> allYears()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/positionYearRateHours/allYears");

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

        public List<PositionYearRateHours> year(int year)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/positionYearRateHours/year/" + year.ToString());

            List<PositionYearRateHours> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<PositionYearRateHours>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
