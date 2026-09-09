using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Person;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPeopleAsync()
        {
            var people = await _personRepository.GetAllAsync();
            return people.Select(p => new PersonDto
            {
                PersonalID = p.PersonalId,
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

        public async Task<Person> GetPersonByPersonalIdAsync(int id)
        {
            var person = await _personRepository.GetByPersonalIdAsync(id);
            if (person is null)
            {
                throw new InvalidOperationException("A person with the provided Personal Id does not exists.");
            }
            return person;
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
            var person = await _personRepository.GetByPersonalIdAsync(personId);
            if (person is null)
            {
                throw new InvalidOperationException("A person with the provided Personal Id does not exists.");
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
    }
}