using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Football
{
     class Person 
     {
        public static List<Person> people { get; } = new List<Person>();
        private string name;
        private int age;

        public const string NAME_REGEX = "([A-Z][a-z]* [A-Z][a-z]* [A-Z][a-z]*)" +
            "|([A-Z][a-z]* [A-Z][a-z]*)" +
            "|([А-Я][а-я]* [А-Я][а-я]* [А-Я][а-я]*-[А-Я][а-я]*)" +
            "|([А-Я][а-я]* [А-Я][а-я]* [А-Я][а-я]*)" +
            "|([А-Я][а-я]* [А-Я][а-я]*)";
        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Every player should have name");
                }
                if (Regex.Matches(value, NAME_REGEX).Count != 1)
                {
                    throw new ArgumentException("The name must be written in English or Cirilyc)");
                }
                name = value; 
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age can not be negative");
                }
                age = value; 
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            people.Add(this);
        }
        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
