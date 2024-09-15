using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Dictionaries
{
    public partial class Form_adding : Form
    {
        System.Drawing.Image? photo;

        public Person resultPerson;
        int editingID = 0;
        public Form_adding()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                photo = System.Drawing.Image.FromFile(openDialog.FileName);
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка чтения фото");
                return;
            }

            pictureBox_Add_photo.Image = photo;

        }
        public void FormToEdit(Person pers)
        {
            this.Text = "Изменение записи";
            textBox_LstName.Text = pers.lastName;
            textBox_FrstName.Text = pers.firstName;
            textBox_Surname.Text = pers.surname;
            textBox_dayOfB.Text = pers.dateOfBirth.Day.ToString();
            comboBox_monthOfB.Text = pers.dateOfBirth.Month.ToString();
            textBox_yearOfB.Text = pers.dateOfBirth.Year.ToString();
            textBox_company.Text = pers.company;
            textBox_rank.Text = pers.rank;
            textBox_dayOfHire.Text = pers.dateOfHire.Day.ToString();
            comboBox_monthOfHire.Text = pers.dateOfHire.Month.ToString();
            textBox_yearOfHire.Text = pers.dateOfHire.Year.ToString();
            pictureBox_Add_photo.Image = System.Drawing.Image.FromFile(pers.photo_path);
            btn_AddItem.Text = "Изменить";
            editingID = pers.id;
        }
        private void btn_AddItem_Click(object sender, EventArgs e)
        {
            string lastName = textBox_LstName.Text;
            string firstName = textBox_FrstName.Text;
            string surname = textBox_Surname.Text;
            DateOnly dateOfB = ConvertToDate(textBox_dayOfB.Text, comboBox_monthOfB.Text, textBox_yearOfB.Text, "birth", out bool empty_dateOfB);
            string company = textBox_company.Text;
            string rank = textBox_rank.Text;
            DateOnly dateOfHire = ConvertToDate(textBox_dayOfHire.Text, comboBox_monthOfHire.Text, textBox_yearOfHire.Text, "hire", out bool empty_dateOfHire);

            if((!empty_dateOfB && dateOfB == default) || (!empty_dateOfHire && dateOfHire == default))
            {
                return;
            }
            if(Person.GetCurrentPersonID() == 0)
            {
                Person.SetCurrentPersonID(1);
            }
            Person person;
            if (editingID != Person.GetCurrentPersonID())
            {
                person = new Person(editingID, lastName, firstName, surname, dateOfB, company, rank, dateOfHire);
            }
            else
            {
                person = new Person(lastName, firstName, surname, dateOfB, company, rank, dateOfHire);
            }                 

            string path;

            if (photo == null)
            {    
                path = @"Photo\no_image.jpg";   
                photo = System.Drawing.Image.FromFile(path);                             
            }
            else
            {
                path = $@"Photo\{person.id}.jpg";
                photo.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }  
                        
            person.photo_path = path;
            
            resultPerson = person;

            this.Close();
        }
              

        private static DateOnly ConvertToDate(string d, string m, string y, string e, out bool empty)
        {
            if (d == "" && m == "" && y == "")
            {
                empty = true;
                return new DateOnly();
            }

            empty = false;
            
            string ev = e == "birth" ? " рождения" : " принятия на работу";

            int month = m switch
            {
                "Январь" => 1,
                "Февраль" => 2,
                "Март" => 3,
                "Апрель" => 4,
                "Май" => 5,
                "Июнь" => 6,
                "Июль" => 7,
                "Август" => 8,
                "Сентябрь" => 9,
                "Октябрь" => 10,
                "Ноябрь" => 11,
                "Декабрь" => 12,
                _ => 0
            };

            if (!DateOnly.TryParse(($"{d}.{month}.{y}"), out DateOnly result))
            {
                MessageBox.Show($"Проверьте корректность введенной даты{ev}.");
            }

            return result;
        }
    }
}
