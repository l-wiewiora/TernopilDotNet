using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TernopilDotNetDatabase;
using TernopilDotNet.Models;

namespace TernopilDotNet.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentRepository commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        [HttpGet]
        public List<string> GetComments()
        {
            return commentRepository.Get().Select(x => x.Text).ToList();
        }

        [HttpPost]
        public void SaveComment([FromQuery]string comment)
        {
            commentRepository.Create(new Comment {Text = comment});
        }
    }
}
