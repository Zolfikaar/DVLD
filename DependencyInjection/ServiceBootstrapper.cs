using System;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Application.Services;

namespace DependencyInjection
{
    public class ServiceBootstrapper
    {
        public static PersonService CreatePersonService()
        {
            IPersonRepository personRepo = new PersonRepository();
            ICountryRepository countryRepo = new CountryRepository();

            return new PersonService(personRepo, countryRepo);
        }
    }
}
