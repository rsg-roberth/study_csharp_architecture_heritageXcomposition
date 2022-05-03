using System;

namespace study_csharp_architecture_heritageXimplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Visible all methods
            var personRepositoryHeritage = new PersonRepositoryHeritage();
            Console.WriteLine(personRepositoryHeritage.Add());
            Console.WriteLine(personRepositoryHeritage.Get());
            Console.WriteLine(personRepositoryHeritage.Delete());
            Console.WriteLine(personRepositoryHeritage.Update());

            var personRepositoryComposition = new PersonRepositoryComposition(new GenericRepository<Person>());
            Console.WriteLine(personRepositoryComposition.Add());
            Console.WriteLine(personRepositoryComposition.Get());
            //Console.WriteLine(personRepositoryComposition.Delete());//error, because not implementation
            //Console.WriteLine(personRepositoryComposition.Update());//error, because not implementation
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }


    public interface IGenericRepository<T> where T : class
    {
        string Add();
        string Delete();
        string Update();
        string Get();
    }

    public interface IPersonRepository
    {
        string Add();
        string Get();
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public string Add() => ("Return method ADD generic class.");

        public string Delete() => ("Return method Delete generic class.");

        public string Get() => ("Return method Get generic class.");

        public string Update() => ("Return method Update generic class.");

    }

    public class PersonRepositoryHeritage : GenericRepository<Person>, IPersonRepository { }

    public class PersonRepositoryComposition : IPersonRepository
    {
        private readonly IGenericRepository<Person> _genericRepository;
        public PersonRepositoryComposition(IGenericRepository<Person> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public string Add() => ("Return method ADD PersonRepositoryComposition class. " + _genericRepository.Add());

        public string Get() => ("Return method Get PersonRepositoryComposition class. " + _genericRepository.Get());
    }

}
