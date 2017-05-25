using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrameworkTwo.Web.Utils
{
    public class ServiceInterface
    {
        private string baseServiceURL = "http://localhost:64219";

        static ServiceInterface instance = null;

        public static ServiceInterface Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceInterface();
                }
                return instance;
            }
        }

        public static void Reset()
        {
            instance = null;
        }

        private ServiceInterface()
        {
        }

        public async Task<RestMessage<T>> GetDataAsync<T>(string controller) where T : class
        {
            RestMessage<T> output = new RestMessage<T>();

            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseServiceURL + "/api/" + controller);
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    output.Result = JsonConvert.DeserializeObject<T>(responseString);

                    output.SetAsGoodRequest();
                }
                else
                {
                    output.SetAsBadRequest();
                    output.Exception = new Exception("Error during processing");
                }
            }
            catch (Exception e)
            {
                output.Exception = e;
                output.SetAsBadRequest();
                output.StatusText = "Error during processing";
            }

            return output;
        }
    }
}
