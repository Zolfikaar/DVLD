using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
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
                FirstName = p.FirstName,
                SecondName = p.SecondName,
                ThirdName = p.ThirdName,
                LastName = p.LastName,
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

        public async Task<PersonDto?> GetPersonByNationalNoAsync(string nationalNo)
        {
            var personEntity = await _personRepository.GetByNationalNoAsync(nationalNo);
            if (personEntity is null)
            {
                throw new InvalidOperationException("A person with the provided National Id does not exists.");
            }
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

        public async Task<int> AddPersonAsync(PersonDto personDto)
        {
            if (personDto == null)
            {
                throw new ArgumentNullException(nameof(personDto));
            }

            // 1. التحقق من وجود الشخص عبر الـ Overloaded method
            var personExists = await _personRepository.IsExistsAsync(personDto.NationalNo);
            if (personExists)
            {
                throw new InvalidOperationException("A person with the same NationalNo already exists.");
            }

            // 2. تحويل الـ DTO إلى Entity (Mapping) للتعامل مع الـ Repository
            var personEntity = new Person
            {
                NationalNo = personDto.NationalNo,
                FirstName = personDto.FirstName,
                SecondName = personDto.SecondName,
                ThirdName = personDto.ThirdName,
                LastName = personDto.LastName,
                DateOfBirth = personDto.DateOfBirth,
                Gender = personDto.GenderText == "Female" ? (byte)1 : (byte)0, // أو bool حسب نوع الحقل بـ Entity
                Address = personDto.Address,
                Phone = personDto.Phone,
                Email = personDto.Email,
                NationalityCountryID = personDto.NationalityCountryID,
                ImagePath = personDto.ImagePath
            };

            // 3. التمرير للـ Repository وإرجاع الـ PersonID الجديد
            return await _personRepository.AddAsync(personEntity);

        }

        public async Task<bool> UpdatePersonAsync(PersonDto updatedPersonDto, int currentPersonID)
        {
            if (updatedPersonDto == null)
            {
                throw new ArgumentNullException(nameof(updatedPersonDto));
            }

            var personEntity = new Person
            {
                NationalNo = updatedPersonDto.NationalNo,
                FirstName = updatedPersonDto.FirstName,
                SecondName = updatedPersonDto.SecondName,
                ThirdName = updatedPersonDto.ThirdName,
                LastName = updatedPersonDto.LastName,
                DateOfBirth = updatedPersonDto.DateOfBirth,
                Gender = updatedPersonDto.GenderText == "Female" ? (byte)1 : (byte)0, // أو bool حسب نوع الحقل بـ Entity
                Address = updatedPersonDto.Address,
                Phone = updatedPersonDto.Phone,
                Email = updatedPersonDto.Email,
                NationalityCountryID = updatedPersonDto.NationalityCountryID,
                ImagePath = updatedPersonDto.ImagePath
            };

            return await _personRepository.UpdateAsync(personEntity,currentPersonID);

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