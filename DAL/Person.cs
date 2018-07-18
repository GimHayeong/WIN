using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
        public Person(string name, int age, bool male)
        {
            Name = name;
            Age = age;
            Male = male;
        }
    }

    [Table(Name="tblPeople")]
    public class People
    {
        private string _Name;
        [Column(IsPrimaryKey = true, Storage = "_Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Age;
        [Column(Storage = "_Age")]
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        private bool _Male;
        [Column(Storage = "_Male")]
        public bool Male
        {
            get { return _Male; }
            set { _Male = value; }
        }
    }
}
