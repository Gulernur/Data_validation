using System.ComponentModel.DataAnnotations;

namespace DataValidation
{
    class Person
    {
        //Name cannot be null/empty, cannot exceed 100 characters and must be at least 1 character long. 
        [Required, MaxLength(100), MinLength(1)]
        public string? Name { get; set; }

        //Age cannot be empty and must be bestween 0-120.  
        [Required, Range(0, 120)]
        public int Age { get; set; }

        //Must be a valid email format. 
        [EmailAddress]
        public string? Email { get; set; }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public static bool Validate(Person person)
        {
            //Empty list that represent the results of the validation operation. 
            List<ValidationResult> result = new List<ValidationResult>();

            //Provides contextual information about the person object, that is being validated. 
            ValidationContext context = new ValidationContext(person);

            //Performs the validation operation by taking 4 argumnets and returns either true or false. 
            var value = Validator.TryValidateObject(person, context, result, true);
            
            //If the validation failed, it will loop trough the result list and prints the error to the console. 
            foreach (ValidationResult r in result)
            {
                Console.WriteLine("Error is " + r);
            }
            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("troels", 24, "troels@t.dk");
            Person person2 = new Person("", 24, "troels@t.dk");
            Person person3 = new Person("troels", 124, "troels@t.dk");
            Person person4 = new Person("troels", 24, "troelstdk");
            Person person5 = new Person("", 124, "troelstdk");

            Console.WriteLine(Person.Validate(person1));
            Console.WriteLine(Person.Validate(person2));
            Console.WriteLine(Person.Validate(person3));
            Console.WriteLine(Person.Validate(person4));
            Console.WriteLine(Person.Validate(person5));
        }
    }
}
