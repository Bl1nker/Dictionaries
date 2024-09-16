using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Dictionaries
{
    public partial class Form_adding : Form
    {
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
                pictureBox_Add_photo.Image = System.Drawing.Image.FromFile(openDialog.FileName);
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка чтения фото");
                return;
            }
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

            if (pictureBox_Add_photo.Image == pictureBox_Add_photo.ErrorImage)
            {    
                path = @".\Photo\no_image.jpg";   
                pictureBox_Add_photo.Image = System.Drawing.Image.FromFile(path);                             
            }
            else
            {
                path = $@".\Photo\{person.id}.jpg";
                SavingPhoto(path);
                
            }

            person.photo_path = path;
            
            resultPerson = person;

            this.Close();
        }

        public void SavingPhoto(string path)
        {
            System.Drawing.Image img = pictureBox_Add_photo.Image;
            Bitmap bmp = img as Bitmap;

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            
            int byteCount = bmpData.Stride * bmpData.Height;
            byte[] bytes = new byte[byteCount];

            Marshal.Copy(bmpData.Scan0, bytes, 0, byteCount);
            bmp.UnlockBits(bmpData);
            
            Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
            BitmapData bmpData1 = bmpNew.LockBits(new Rectangle(new Point(), bmpNew.Size), ImageLockMode.ReadWrite, bmp.PixelFormat);
            Marshal.Copy(bytes, 0, bmpData1.Scan0, bytes.Length);
            bmpNew.UnlockBits(bmpData1);
            bmp.Dispose();
            
            //code to manipulate bmpNew goes here.
            bmpNew.Save(path);
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
