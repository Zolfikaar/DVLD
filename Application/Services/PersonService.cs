using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Person;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICountryRepository _countryRepository;

        public PersonService(IPersonRepository personRepository, ICountryRepository countryRepository)
        {
            _personRepository = personRepository;
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPeopleAsync()
        {
            var people = await _personRepository.GetAllAsync();
            return people.Select(p => new PersonDto
            {
                PersonID = p.PersonId,
                NationalNo = p.NationalNo,
                FullName = $"{p.FirstName} {p.SecondName} {p.ThirdName} {p.LastName}".Replace("  ", " "),
                DateOfBirth = p.DateOfBirth,
                GenderText = p.Gender == 0 ? "Male" : "Female",
                Address = p.Address,
                Phone = p.Phone,
                Email = p.Email,
                NationalityCountryID = p.NationalityCountryID,
                ImagePath = p.ImagePath
            });
        }

        public async Task<PersonDto?> GetPersonByPersonIdAsync(int id)
        {
            var personEntity = await _personRepository.GetByPersonIdAsync(id);

            if (personEntity == null) return null;

            // تحويل الـ Entity إلى DTO بداخل طبقة الـ Application
            return new PersonDto
            {
                PersonID = personEntity.PersonId,
                NationalNo = personEntity.NationalNo,
                FirstName = personEntity.FirstName,
                SecondName = personEntity.SecondName,
                ThirdName = personEntity.ThirdName,
                LastName = personEntity.LastName,
                FullName = $"{personEntity.FirstName} {personEntity.SecondName} {personEntity.ThirdName} {personEntity.LastName}".Trim(),
                GenderText = personEntity.Gender == 0 ? "Male" : "Female",
                DateOfBirth = personEntity.DateOfBirth,
                Phone = personEntity.Phone,
                Email = personEntity.Email,
                Address = personEntity.Address,
                NationalityCountryID = personEntity.NationalityCountryID,
                ImagePath = personEntity.ImagePath
            };
        }

        public async Task<Person> GetPersonByNationalNoAsync(string nationalNo)
        {
            var person = await _personRepository.GetByNationalNoAsync(nationalNo);
            if (person is null)
            {
                throw new InvalidOperationException("A person with the provided National Id does not exists.");
            }
            return person;
        }

        public async Task<int> AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            else
            {
                var personExists = await _personRepository.IsExistsAsync(person.NationalNo);
                if (personExists)
                {
                    throw new InvalidOperationException("A person with the same NationalNo already exists.");
                }
                else
                {
                    return await _personRepository.AddAsync(person);
                }
            }
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            else
            {
                return await _personRepository.UpdateAsync(person);
            }
        }

        public async Task<bool> DeletePersonAsync(int personId)
        {
            var person = await _personRepository.GetByPersonIdAsync(personId);
            if (person is null)
            {
                throw new InvalidOperationException("A person with the provided Person Id does not exists.");
            } else
            {
                return await _personRepository.DeleteAsync(personId);
            }
        }

        public async Task<bool> IsPersonExists(int personId)
        {
            return await _personRepository.IsExistsAsync(personId);
        }

        public async Task<bool> IsPersonExists(string nationalNo)
        {
            return await _personRepository.IsExistsAsync(nationalNo);
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            return countries.Select(c => new CountryDto
            {
                CountryID = c.CountryID,
                CountryName = c.CountryName
            });
        }
    }
}