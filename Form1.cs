namespace Dictionaries
{
    public partial class Form_main : Form
    {
        List<Person> ListOfPersons = new List<Person>();
       
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
