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
            IPersonRepository repo = new PersonRepository();
            return new PersonService(repo);
        }
    }
}
