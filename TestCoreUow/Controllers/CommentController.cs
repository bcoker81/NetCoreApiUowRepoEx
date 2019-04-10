using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCoreUow.Contracts;
using TestCoreUow.Entities;

namespace TestCoreUow.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("getall/{id}")]
        public IActionResult GetAllCommentsByGrant(int id)
        {
            var commentList = _unitOfWork.CommentRepository.Get(m => m.FkGrantId == id);
            return Ok(commentList);
        }

        [HttpPost]
        [Route("newComment")]
        public IActionResult NewComment([FromBody] Comments comment)
        {
            _unitOfWork.CommentRepository.Insert(comment);
            _unitOfWork.Save();
            return Ok();
        }
    }
}