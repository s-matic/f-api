using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FeedbackApi.Models;
using System.Linq;
using System;
using System.Text;
using System.Net.Http;

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
            if(!feedback.IsOverrideAble)
            feedback.Date = randomDate(feedback.Date);              
             _context.Feedbacks.Add(feedback);
             _context.SaveChanges();

            return Ok();
        }   

        [HttpDelete]
        public IActionResult Delete()
        {
        
        foreach (var entity in _context.Feedbacks)
        {
         _context.Feedbacks.Remove(entity);
        }

        _context.SaveChanges();

        return Ok("bra");
        
        }


        public DateTime randomDate(DateTime date)
            {
                Random rnd = new Random();
                int hour = rnd.Next(1, 3);
                int minute = rnd.Next(0,59);
                int second = rnd.Next(0,59);
                return date.AddHours(hour).AddMinutes(minute).AddSeconds(second);
            } 
    }

}