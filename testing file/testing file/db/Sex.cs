using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
    public class Sex
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
        public Sex(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string? ToString()
        {
            return Name.ToLower();
        }
    }
}
