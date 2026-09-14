using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName {  get; set; } = string.Empty;
        public string LastName {  get; set; } = string.Empty;
        public DateTime DateOfBirth {  get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int NationalityCountryID { get; set; }
        public string ImagePath {  get; set; } = string.Empty;
    }
}
