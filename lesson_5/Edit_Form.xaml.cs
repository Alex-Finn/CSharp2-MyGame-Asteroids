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
        Binding s = new Binding();
        
        public Edit_Form(Employee employee)
        {
            InitializeComponent();
            /*Binding binding = new Binding();
            binding.ElementName = nameof(MainWindow.depts);
            // Элемент-источник
            binding.Path = new PropertyPath("Text");
            // Свойство элемента-источника
            cb_edit_department.SetBinding(TextBlock.TextProperty, binding);
            // Установка привязки для элемента-приемника*/
            maingridedit.DataContext = employee;
            FillData(employee);            
        }
        

        private static void FillData(Employee employee)
        {
        }

        private static void cb_edit_department_SelectionChanged()
        {

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button cancel");
            this.Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button save");
            this.Close();
        }
    }
}
