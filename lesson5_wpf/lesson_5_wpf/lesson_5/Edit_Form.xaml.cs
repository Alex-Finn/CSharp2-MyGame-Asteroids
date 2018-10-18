using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lesson_5
{
    /// <summary>
    /// Логика взаимодействия для Edit_Form.xaml
    /// </summary>
    public partial class Edit_Form : Window
    {
        public Edit_Form(Employee employee)
        {
            InitializeComponent();
            //cb_edit_department.ItemsSource = employee;
            FillData(employee);
        }
        

        private static void FillData(Employee employee)
        {
            
             
            //ComboBox.bin
        }
    }
}
