using db;

namespace testing_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonMapper mapper = new();

            List<Person> people = mapper.GetPeople();

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
