using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Models
{
    public partial class UserRegistrationvalid
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }


        [Required]
        [Display(Name = "Marriage Status")]
        public string MarriageStatus { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Course { get; set; }
        public List<SelectListItem> CourseItems { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public LanguageList LanguageItems { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Mobile { get; set; }

        [Required]
        [Remote("IsAlreadySigned", "UserInfo", HttpMethod = "POST", ErrorMessage = "EmailId already exists.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm-Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        public Nullable<bool> Status { get; set; }


        //GenderItems
        public List<SelectListItem> GenderItems { get; set; }

        public bool IsCheck { get; set; }


        [Required]
        public IEnumerable<SelectListItem> Values
        {
            get
            {
                return new[]
                {
                new SelectListItem { Value = "1", Text = "Pre-Approved" },
                new SelectListItem { Value = "2", Text = "Approved" },
                };
            }
        }




    }

    public enum LanguageList
    {
        English=1,
        Telugu=2
    }


    


}