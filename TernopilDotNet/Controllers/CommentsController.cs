using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TernopilDotNet.Models;

namespace TernopilDotNet.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        // TODO: replace with database
        private static List<string> comments = new List<string>();
        public CommentsController(IConfiguration config)
        {
        }

        [HttpGet]
        public List<string> GetComments()
        {
            return comments;
        }

        [HttpPost]
        public void SaveComment([FromQuery]string comment)
        {
            comments.Add(comment);
        }
    }
}
