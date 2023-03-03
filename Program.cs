using System.ComponentModel.DataAnnotations;

namespace DataValidation
{
    class Person
    {
        [Required, MaxLength(100), MinLength(1)]
        public string? Name { get; set; }

        [Required, Range(0, 120)]
        public int Age { get; set; }

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
            List<ValidationResult> result = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(person);

            var value = Validator.TryValidateObject(person, context, result, true);
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
