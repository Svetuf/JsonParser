using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Web.Http;

using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class JsonController : ApiController
    {
        /// <summary>
        /// Main controller to parce Json body.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult parce()
        {
            string file = Request.Content.ReadAsStringAsync().Result;
            JsonLevel depth = new JsonLevel();
            JObject ans = null;

            try
            {
                ans = JObject.Parse(file);
            }
            catch (JsonException)
            {
                var json = new { error = "Invalid JSON" };
                return Json(json);
            }

            int count = depth.checkLevel(ans.ToString());
            
            var data = new { levels = count};
            return Json(data);
        }
    }
}

