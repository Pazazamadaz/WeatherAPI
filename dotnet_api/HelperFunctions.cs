namespace HelperFunctions
{
    public class Functions
    {
        public static string FilterJSONData(string response)
        {
            // store JSON in an object we can use dot notation to retreive just the values we need
            // and store them in a new JSON oject
            dynamic data = Newtonsoft.Json.Linq.JObject.Parse(response);
            dynamic dataNew = new Newtonsoft.Json.Linq.JObject();
            dataNew.city = data.location.name;
            dataNew.region = data.location.region;
            dataNew.country = data.location.country;
            dataNew.localTime = data.location.localtime;
            dataNew.temperature = data.current.temp_c;

            // return the new JSON object as a string
            return dataNew.ToString();
        }

        public static bool ValidateUserInput(string strCityName) 
        {
            if ((strCityName.Length <= 0) || (strCityName.GetType() != typeof(string)))
            {
                return false;
            }

            return true;
        }
    }
}
