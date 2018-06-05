using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMS
{
    class User
    {
        private int ID;
        private string Name;
        private string Position;
        public User(int id,string name,string position)
        {
            ID = id;
            Name = name;
            Position = position;
        }
        public User()
        {

        }
    }
}
