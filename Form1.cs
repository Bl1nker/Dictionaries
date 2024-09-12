using System.Xml.Linq;

namespace Dictionaries
{
    public partial class Form_main : Form
    {
        static List<Person> ListOfPersons = new List<Person>();
        XDocument xdoc;

        string dictName;
       
        public Form_main()
        {
            InitializeComponent();
            
        }

        private void btn_loadData_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            dictName = openFileDialog1.FileName;
            try 
            {
                xdoc = XDocument.Load(dictName);
            } 
            catch (IOException ex)
            {
                MessageBox.Show("Не удалось открыть выбранный файл.\n");
                // need to add write in log XXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            }

            string str = "sdfsd";
            //if (!xdoc.("persons"))
            //{
            //    MessageBox.Show("В уазанном файле нет реестра сотрудников");
            //    return;
            //}

            //XElement? persons = xdoc.Element("persons");


            //if (persons.Count > 0) Person.SetCurrentPersonID(persons.ID.Max());
            //else Person.SetCurrentPersonID(1);
            //// ��� ������ ������� ������ ��������� "������ �� ������. ������ ����� ������"

            //ListOfPersons = GetListOfPersons(persons);

        }

        static void saveData()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = saveFileDialog1.FileName;
             // сохраняем текст в файл
            
            MessageBox.Show("Файл сохранен");
        }
        //static List<Person> GetListOfPersons(XDocument xdoc)
        //{
        //    List<Person> result = new List<Person>();

        //    foreach (XElement pers in xpeople)
        //    {
        //        Person tmp = new Person(pers.ID, pers.LastName, pers.FirstName, pers.Surname, DateOnly.Parse(pers.DateOfBirth), pers.Company, pers.Rank, DateOnly.Parse(pers.DateOfHire));
        //        result.Add(tmp);
        //    }
        //    return result;
        //}

        public void TakePerson(Person person)
        {
            ListOfPersons.Add(person);
        }

        private void btn_saveData_Click(object sender, EventArgs e)
        {
            if (xdoc == null) 
            {
                xdoc = new XDocument();                
            }

            XElement xPersons = new XElement("persons");

            foreach (Person person in ListOfPersons)
            {
                XElement xPerson = new XElement("person");
                XAttribute persIDAttr = new XAttribute("ID", person.id.ToString());
                XElement persLastName = new XElement("LastName", person.lastName);
                XElement persFirstName = new XElement("FirstName", person.firstName);
                XElement persSurname = new XElement("Surname", person.surname);
                XElement persDateOfB = new XElement("DateOfBirth", person.dateOfBirth.ToShortDateString());
                XElement persCompany = new XElement("Company", person.company);
                XElement persRank = new XElement("Rank", person.rank);
                XElement persDateOfHire = new XElement("DateOfHire", person.dateOfHire.ToShortDateString());
                XElement persPhoto = new XElement("Photo", person.photo_path);

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
            
            xPersons.Save("persons.xml");

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form_adding form_Adding = new Form_adding();
            form_Adding.ShowDialog();

            ListOfPersons.Add(form_Adding.resultPerson);
            // ������� ����� 2 � ������ ��� ����������
            // ������������� ����� 1, ���� ������� ����� 2
        }

        private void btn_LoadMuch_Click(object sender, EventArgs e)
        {
            // ��������� �� ���� ������ �������
            // �������������� ������� ����
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // ����� ������ �� textBox_Search � ������ �������� cb_typeOfSearch
            // ������������ startWith �������������� ����� ������� � ������� trim.
        }
    }
}
