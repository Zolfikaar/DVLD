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

        public static UserService CreateUserService()
        {
            IUserRepository userRepo = new UserRepository();
            return new UserService(userRepo);
        }

        public static ApplicationTypeService CreateApplicationTypeService()
        {
            IApplicationTypeRepository applicationTypeRepo = new ApplicationTypeRepository();
            return new ApplicationTypeService(applicationTypeRepo);
        }
    }
}
