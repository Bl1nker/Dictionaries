using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dictionaries
{
    public partial class Form_main : Form
    {
        public static List<Person> ListOfPersons = new List<Person>();
        XDocument xdoc;

        string fileName;

        string textToSearch = "";
        int stopIdx = 0;
        List<List<DataGridViewRow>> datarows = new List<List<DataGridViewRow>>() { new List<DataGridViewRow>(), new List<DataGridViewRow>()};
       
        public Form_main()
        {
            InitializeComponent();
            if (!Directory.Exists("Photo"))
            {
                DirectoryInfo photoDir = new DirectoryInfo(".");
                photoDir.CreateSubdirectory("Photo");

                Image noPhoto = Properties.Resources.no_image;
                noPhoto.Save(@"Photo\no_image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            this.FormClosing += CheckToSave;            
        }

        private void btn_loadData_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            fileName = openFileDialog1.FileName;
            try 
            {
                xdoc = XDocument.Load(fileName);
            } 
            catch (IOException ex)
            {
                MessageBox.Show("Не удалось открыть выбранный файл.\n");
                // need to add write in log XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            }

            XElement? persons = xdoc.Element("persons");

            if (persons == null)
            {
                MessageBox.Show("В уазанном файле нет реестра сотрудников");
                return;
            }

            ListOfPersons = ReadPersonsFromXml(persons);

            int loadedID = ListOfPersons.Max(x => x.id); // max ID in loaded file

            Person.SetCurrentPersonID(loadedID > 0 ? loadedID : 1);
            ShowPersons();

            contextMenuForTable1.Items.Add(removeItem);
            contextMenuForTable1.Items.Add(editItem);
            contextMenuForTable1.Items.Add(removeAll);

        }

        static List<Person> ReadPersonsFromXml(XElement persons)
        {
            List<Person> result = new List<Person>();

            foreach (var xPers in persons.Elements("person"))
            {
                int ID = int.Parse(xPers.Attribute("ID").Value);
                string LastName = xPers.Element("LastName").Value;
                string FirstName = xPers.Element("FirstName").Value;
                string Surname = xPers.Element("Surname").Value;
                DateOnly BirthDate = DateOnly.Parse(xPers.Element("DateOfBirth").Value);
                string company = xPers.Element("Company").Value;
                string rank = xPers.Element("Rank").Value;
                DateOnly HireDate = DateOnly.Parse(xPers.Element("DateOfHire").Value);
                string photo = xPers.Element("Photo").Value;

                Person tmpPers = new Person(ID, LastName, FirstName, Surname, BirthDate, company, rank, HireDate);
                tmpPers.photo_path = photo;
                result.Add(tmpPers);
            }

            return result;
        }

        static XDocument ConvertPersonToXml(List<Person> listToSave)
        {
            XDocument xdoc = new XDocument();

            XElement xPersons = new XElement("persons");
                                    
            foreach (Person pers in listToSave)
            {
                XElement xPerson = new XElement("person");
                XAttribute persIDAttr = new XAttribute("ID", pers.id);
                XElement persLastName = new XElement("LastName", pers.lastName);
                XElement persFirstName = new XElement("FirstName", pers.firstName);
                XElement persSurname = new XElement("Surname", pers.surname);
                XElement persDateOfB = new XElement("DateOfBirth", pers.dateOfBirth.ToShortDateString());
                XElement persCompany = new XElement("Company", pers.company);
                XElement persRank = new XElement("Rank", pers.rank);
                XElement persDateOfHire = new XElement("DateOfHire", pers.dateOfHire.ToShortDateString());
                XElement persPhoto = new XElement("Photo", $"{pers.id}.jpg");


                xPerson.Add(persIDAttr);
                xPerson.Add(persLastName);
                xPerson.Add(persFirstName);
                xPerson.Add(persSurname);
                xPerson.Add(persDateOfB);
                xPerson.Add(persCompany);
                xPerson.Add(persRank);
                xPerson.Add(persDateOfHire);
                xPerson.Add(persPhoto);

                xPersons.Add(xPerson);
            }

            xdoc.Add(xPersons);
            
            return xdoc;        
        }
        
        private void btn_saveData_Click(object sender, EventArgs e)
        {
            SaveListToXml();
        }

        private void CheckToSave(object sender, EventArgs e)
        {
            if (ListOfPersons.Count > 0)
            {                
                DialogResult result = MessageBox.Show("Сохранить реестр перед закрытием?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result.ToString() == "Yes")
                {
                    SaveListToXml();
                }
            }
        }
        public void SaveListToXml()
        {

            if (xdoc == null)
            {
                xdoc = new XDocument();
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
                if (saveFile.ShowDialog() == DialogResult.Cancel)
                    return;
                fileName = saveFile.FileName;
            }

            xdoc = ConvertPersonToXml(ListOfPersons);

            xdoc.Save(fileName);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form_adding form_Adding = new Form_adding();
            form_Adding.ShowDialog();
            Person addedPers = form_Adding.resultPerson;

            if (addedPers != null) 
            { 
                ListOfPersons.Add(addedPers);
                Table1.Rows.Add(PersonToRow(addedPers));
            }
            contextMenuForTable1.Items.Add(removeItem);
            contextMenuForTable1.Items.Add(editItem);
            contextMenuForTable1.Items.Add(removeAll);
        }

        void RemoveItem_Click(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Table1.SelectedRows)
            {
                Table1.Rows.RemoveAt(row.Index);
                ListOfPersons = ListOfPersons.Where(x => x.id != int.Parse((string)row.Cells[0].Value)).ToList();
                ShowPersons();
            }
            if(ListOfPersons.Count == 0)
            {
                contextMenuForTable1.Items.Remove(removeItem);
                contextMenuForTable1.Items.Remove(editItem);
                contextMenuForTable1.Items.Remove(removeAll);
            }
        }
        void RemoveAllItem_Click(object? sender, EventArgs e)
        {
            Table1.Rows.Clear();
            ListOfPersons.Clear();
            
            contextMenuForTable1.Items.Remove(removeItem);
            contextMenuForTable1.Items.Remove(editItem);
            contextMenuForTable1.Items.Remove(removeAll);
            
        }
        void EditItem_Click(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Table1.SelectedRows)
            {
                Person PersToEdit = ListOfPersons.Where(x => x.id == int.Parse((string)row.Cells[0].Value)).ToList()[0];

                Form_adding form_Adding = new Form_adding();
                form_Adding.FormToEdit(PersToEdit);
                
                form_Adding.ShowDialog();                

                ShowPersons();
            }
        }
        private void ShowPersons()
        {
            Table1.Rows.Clear();

            List<DataGridViewRow> rows;
            if (ListOfPersons.Count < 200)
            {
                rows = new List<DataGridViewRow>();
                foreach (Person pers in ListOfPersons)
                {
                    rows.Add(PersonToRow(pers));
                }                
            }
            else
            {
                Thread thrd1 = new Thread(this.Run);
                Thread thrd2 = new Thread(this.Run);
                thrd1.Start(1);
                thrd2.Start(2);
                thrd1.Join();
                thrd2.Join();
                rows = [.. datarows[0], .. datarows[1]];                
            }
            
            Table1.Rows.AddRange(rows.ToArray());            
        }

        void Run(object num)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            int midle = ListOfPersons.Count / 2;
            
            if((int) num == 1)
            {
                for (int i = 0; i < midle; i++)
                {
                    rows.Add(new DataGridViewRow());
                    rows[i] = PersonToRow(ListOfPersons[i]);
                }
            }
            else
            {
                for (int i = midle + 1; i < ListOfPersons.Count; i++)
                {
                    rows.Add(new DataGridViewRow());
                    rows[i - (midle + 1)] = PersonToRow(ListOfPersons[i]);
                }
            }
            datarows[(int)num - 1].AddRange(rows); 
        }

        static DataGridViewRow PersonToRow(Person pers)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewCell cell_ID = new DataGridViewTextBoxCell
            {
                Value = pers.id
            };
            
            DataGridViewCell cell_photo = new DataGridViewImageCell
            {                
                Value = Image.FromFile($"{pers.photo_path}")
            };            

            DataGridViewCell cell_lastName = new DataGridViewTextBoxCell
            {
                Value = pers.lastName
            };

            DataGridViewCell cell_firstName = new DataGridViewTextBoxCell
            {
                Value = pers.firstName
            };
            DataGridViewCell cell_surname = new DataGridViewTextBoxCell
            {

                Value = pers.surname
            };

            DataGridViewCell cell_BirthDate = new DataGridViewTextBoxCell
            {
                Value = pers.dateOfBirth.ToLongDateString()
            };

            DataGridViewCell cell_company = new DataGridViewTextBoxCell
            {
                Value = pers.company
            };

            DataGridViewCell cell_rank = new DataGridViewTextBoxCell
            {
                Value = pers.rank
            };

            DataGridViewCell cell_HireDate = new DataGridViewTextBoxCell
            {
                Value = pers.dateOfHire.ToLongDateString()
            };

            row.Cells.AddRange(cell_ID, cell_photo, cell_lastName, cell_firstName, cell_surname, cell_BirthDate, cell_company, cell_rank, cell_HireDate);

            return row;
        }
        
        private void btn_search_Click(object sender, EventArgs e)
        {       
            if(textToSearch != textBox_Search.Text.Trim())
            {
                textToSearch = textBox_Search.Text.Trim();
                Table1.ClearSelection();
                stopIdx = 0;
            }
            if (textToSearch == "") return;

            string TypeOfSearch = cb_typeOfSearch.Text;
            int coltoSearch = TypeOfSearch switch{
                "по фамилии" => 2,
                "по имени" => 3,
                "по отчеству" => 4,
                "по организации" => 6,
                "по должности" => 7,
                _ => 2
            };
            
            for(int i = stopIdx; i < Table1.Rows.Count; i++)
            {
                string tmpStr = Table1.Rows[i].Cells[coltoSearch].Value.ToString();
                if (tmpStr.StartsWith(textToSearch) && !Table1.Rows[i].Selected) 
                {
                    Table1.Rows[i].Selected = true;
                    stopIdx = ++i;
                }
                if(i == Table1.Rows.Count) stopIdx = 0;
            } 
        }
    }
}
