namespace HelperFunctions
{
    public class Functions
    {
        public static string FilterJSONData(string response, bool fahrenheit)
        {
            // store JSON in an object we can use dot notation to retreive just the values we need
            // and store them in a new JSON oject
            dynamic data = Newtonsoft.Json.Linq.JObject.Parse(response);
            dynamic dataNew = new Newtonsoft.Json.Linq.JObject();
            dataNew.city = data.location.name;
            dataNew.region = data.location.region;
            dataNew.country = data.location.country;
            dataNew.localTime = data.location.localtime;
            if (fahrenheit)
            {
                dataNew.temperature = data.current.temp_f + "\u2109";
            }
            else
            {
                dataNew.temperature = data.current.temp_c + "\u2103";
            }
           
            // return the new JSON object as a string
            return dataNew.ToString();
        }

        public static string FilterJSONAstroData(string response, string finalResponse)
        {
            // store JSON in an object we can use dot notation to retreive just the values we need
            // and store them in a new JSON oject
            dynamic originaldata = Newtonsoft.Json.Linq.JObject.Parse(finalResponse);
            dynamic astrodata = Newtonsoft.Json.Linq.JObject.Parse(response);
            dynamic dataNew = new Newtonsoft.Json.Linq.JObject();
            dataNew.sunrise = astrodata.astronomy.astro.sunrise;
            dataNew.sunset = astrodata.astronomy.astro.sunset;
            dataNew.Merge(originaldata);
            
            // return the new JSON object as a string
            return dataNew.ToString();
        }

        public static bool ValidateCityParam(string strCityName) 
        {
            if (strCityName != null)
            {
                strCityName = strCityName.Trim();
                if ((strCityName.Length <= 0) || (strCityName.GetType() != typeof(string)))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateFahrenheitParam(string strFahrenheit)
        {
            if (strFahrenheit == null)
            {
                return false;
            }

            strFahrenheit = strFahrenheit.Trim();

            if (strFahrenheit == "1" || strFahrenheit == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
