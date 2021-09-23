using System;
using System.Collections.Generic;
using System.Text;

namespace DiaryInWpf.Models.Wrappers
{
   public class StudentWrapper
    {

        public StudentWrapper()
        {
            Group = new GroupWrapper();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Comments { get; set; }

        public string Math { get; set; }

        public string Technology { get; set; }

        public string Physics { get; set; }

        public string PolishLang { get; set; }

        public bool Activities { get; set; }

        public string ForeignLang { get; set; } 

        public GroupWrapper Group { get; set; }
    }
}
