using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FeedbackApi.Models;
using System.Linq;
using System;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly FeedbackContext _context;

        public FeedbackController(FeedbackContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Feedback> GetAll()
        {
            
            return _context.Feedbacks.ToList();
            
        }    

        [HttpPost]
        public IActionResult Create([FromBody] Feedback feedback)
        {
            if (feedback == null)
            {
                return BadRequest();
            }   
            int lastetId =  _context.Feedbacks.ToList().Count;
            feedback.Id = lastetId + 1;
            feedback.Date = DateTime.Now;

             _context.Feedbacks.Add(feedback);
             _context.SaveChanges();

            return Ok();
        }   
    }

}