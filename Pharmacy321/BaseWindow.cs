using System.Data;
using System.Windows.Controls;

namespace Pharmacy321
{
    public class BaseWindow
    {
        protected Database database;

        public BaseWindow()
        {
            database = new Database();
        }

        protected void LoadSpecialists(ComboBox specialistsComboBox)
        {
            DataTable specialists = database.GetSpecialists();

            specialistsComboBox.ItemsSource = specialists.DefaultView;
            specialistsComboBox.DisplayMemberPath = "FullNameAndPosition";
            specialistsComboBox.SelectedValuePath = "ID_Sotrudnic";
        }
    }
}