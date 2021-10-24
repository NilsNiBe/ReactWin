using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace ReactWinforms
{
  [RoutePrefix("api/time")]
  public class TimeController : ApiController
  {
    [HttpGet]
    [Route]
    public async Task<DateTime> GetCurrentTime()
    {
      await ThreadService.MainThread;
      return DateTime.Now;
    }
  }
}
