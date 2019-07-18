using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalizerBusinessDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace PersonalizerBusinessDemo.Controllers
{
    [Route("api/[controller]")]
    public class MetadataController : Controller
    {
        private readonly IActionsRepository _actionsRepository;

        public MetadataController(IActionsRepository actionsRepository)
        {
            _actionsRepository = actionsRepository;
        }

        [HttpGet("Actions")]
        public JsonResult Actions(bool useTextAnalytics)
        {
            return new JsonResult(_actionsRepository.GetActionsWithMetadata(useTextAnalytics));
        }

        [HttpGet("UserAgent")]
        public JsonResult UserAgent()
        {
            var userAgent = new UserAgentInfo();
            userAgent.UseUserAgent(Request.Headers["User-Agent"]);

            return new JsonResult(userAgent);
        }
    }
}