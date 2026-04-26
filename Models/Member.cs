using System;
using System.ComponentModel.DataAnnotations;

namespace FitCore.Models
{
    public class Member
    {
        [Key] 
        public int MemberId { get; set; } 

        [Required(ErrorMessage = "Lütfen üyenin adını ve soyadını giriniz.")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now; 
    }
}