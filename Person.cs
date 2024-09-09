using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{    
    internal class Person
    {
        public int id;
        public string firstName;
        public string lastName;
        public string surname;
        public DateOnly dateOfBirth;
        public string company;
        public string rank;
        public DateOnly dateOfHire;
        public Image photo;

        public Person(int id)
        {
            this.id = id;
            firstName = "";
            lastName = "";
            surname = "";
            dateOfBirth = new DateOnly();
            company = "";
            rank = "";
            dateOfHire = new DateOnly();
            photo = Image.FromFile("no_image.jpg");
        }
        public Person(int id, string lastName, string firstName, string surname, DateOnly dateOfBirth, string company, string rank, DateOnly dateOfHire, Image photo)
        {
            this.id = id;
            this.lastName = lastName; // фамилия
            this.firstName = firstName; // имя
            this.surname = surname; // отчество
            this.dateOfBirth = dateOfBirth; // дата рождения
            this.company = company; // организация
            this.rank = rank; // должность
            this.dateOfHire = dateOfHire; // дата устройства на работу
            this.photo = photo; // фото
        }

    }
}
