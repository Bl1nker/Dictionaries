namespace Dictionaries
{
    public partial class Form_main : Form
    {
        List<Person> ListOfPersons = new List<Person>();
        XDocument xdoc;
       
        public Form_main()
        {
            InitializeComponent();
            
        }

        private void btn_loadData_Click(object sender, EventArgs e)
        {
            //��������� ������. ��� ������� ������ ��������. 
            // ���������� ������� ������ ������. Open or Create
            // ��������� ����� try catch
            // ��� ������ ������� ������ ��������� "������ �� ������. ������ ����� ������"

            Person.SetCurrentPersonID(1); // ������������� �� �������, ���� ���� �������� �� �����������, ���� ���� ������ �� ���������, �� �������            

        }

        private void btn_saveData_Click(object sender, EventArgs e)
        {
            if (xdoc == null) 
            {
                xdoc = new XDocument();
                XElement xPersons = new XElement("persons");
            }
            
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
                XElement persDateOfHire = new XElement("DateOfHire", person,col_dateOfHire.ToShortDateString());
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
