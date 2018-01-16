using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPArserService.Models
{
    public class ResultViewModel
    {
        public ResumeDataField Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }

   public class ResumeDataField
    {
        public PersonalData Personal { get; set; }
        public ResumeData ResumeData { get; set; }

    }


    public class PersonalData
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }

   public class ResumeData
    {
        public string Profile { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Courses { get; set; }
        public string Skills { get; set; }
        public string Refrences { get; set; }

    }
}