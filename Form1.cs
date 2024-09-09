namespace Dictionaries
{
    public partial class Form_main : Form
    {
                

        public Form_main()
        {
            InitializeComponent();
            int curentID = 0; 
        }

        private void btn_loadData_Click(object sender, EventArgs e)
        {
            //загружаем реестр. Без диалога выбора названия. 
            // пролверяем наличие нужных файлов. Open or Create
            // выполнить через try catch
            // при первом запуске выдать сообщение "Реестр не найден. Создан новый реестр"

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form_adding form_Adding = new Form_adding();
            form_Adding.ShowDialog();
            
            // открыть форму 2 с полями для заполнения
            // заблокировать форму 1, пока открыта форма 2
        }

        private void btn_LoadMuch_Click(object sender, EventArgs e)
        {
            // загрузить из базы тысячу записей
            // предварительно создать базу
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // поиск текста из textBox_Search с учетом значения cb_typeOfSearch
            // использовать startWith предварительно уюрав пробелы с помощью trim.
        }
    }
}
