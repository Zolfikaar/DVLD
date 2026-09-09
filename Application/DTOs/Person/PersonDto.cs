using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Person
{
    public class PersonDto
    {
        public int PersonalID { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string GenderText { get; set; } = string.Empty; // "Male" or "Female"
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int NationalityCountryID { get; set; }
        public string? ImagePath { get; set; }
    }
}
