﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{    
    public class Person
    {
        static int currentID;
        public readonly int id;
        public string firstName;
        public string lastName;
        public string surname;
        public DateOnly dateOfBirth;
        public string company;
        public string rank;
        public DateOnly dateOfHire;
        public string photo_path;        

        public static void SetCurrentPersonID(int newID)
        {
            currentID = newID; 
        }
        public static int GetCurrentPersonID()
        {
            return currentID;
        }
    
        public Person(int ID, string lastName, string firstName, string surname, DateOnly dateOfBirth, string company, string rank, DateOnly dateOfHire)
        {
            id = ID;
            this.lastName = lastName; // фамилия
            this.firstName = firstName; // имя
            this.surname = surname; // отчество
            this.dateOfBirth = dateOfBirth; // дата рождения
            this.company = company; // организация
            this.rank = rank; // должность
            this.dateOfHire = dateOfHire; // дата устройства на работу
            photo_path = "";
        }
        public Person(string lastName, string firstName, string surname, DateOnly dateOfBirth, string company, string rank, DateOnly dateOfHire)
        {
            id = currentID;
            this.lastName = lastName; // фамилия
            this.firstName = firstName; // имя
            this.surname = surname; // отчество
            this.dateOfBirth = dateOfBirth; // дата рождения
            this.company = company; // организация
            this.rank = rank; // должность
            this.dateOfHire = dateOfHire; // дата устройства на работу
            photo_path = "";
        }

    }
}
