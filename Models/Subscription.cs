using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitCore.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; } 

        
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [Required(ErrorMessage = "Lütfen abonelik planını giriniz.")]
        public string PlanName { get; set; } 

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } 

        public decimal Price { get; set; } 
    }
}