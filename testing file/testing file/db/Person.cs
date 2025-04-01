using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
    public class Person
    {

        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        private Sex _type;
        public Sex Sex
        {
            get => _type;
            set => _type = value;
        }
        public Person(int id, string name, int age, Sex sex) :this(id,name,age)
        {
            this.Sex = sex;
        }
        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string? ToString()
        {
            return $"{Id} {Name} {Age} {this.Sex}";
        }
    }
}
