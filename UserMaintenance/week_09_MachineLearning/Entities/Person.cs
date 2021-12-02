using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_09_MachineLearning.Entities
{
    public class Person
    {
        public Gender Gender { get; set; }
        public int BirthYear { get; set; }
        public int NumberOfChildren { get; set; }
        public bool IsAlive { get; set; }

        public Person()
        {
            IsAlive = true;
        }
    }
}
