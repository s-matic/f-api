using System;

namespace FeedbackApi.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsPositive { get; set; }
    }
}