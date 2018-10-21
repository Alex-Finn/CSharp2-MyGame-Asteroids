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
            cb_edit_department.ItemsSource = MainWindow.depts;
            FillData();            
        }
        

        private static void FillData()
        {
        }

        private static void cb_edit_department_SelectionChanged()
        {

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("button cancel");
            this.Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("button save");
            BindingExpression binding_id =
                tb_edit_id.GetBindingExpression(TextBox.TextProperty);
            binding_id.UpdateSource();
            BindingExpression binding_name =
                 tb_edit_name.GetBindingExpression(TextBox.TextProperty);
            binding_name.UpdateSource();
            BindingExpression binding_age =
                 tb_edit_age.GetBindingExpression(TextBox.TextProperty);
            binding_age.UpdateSource();
            BindingExpression binding_salary =
                 tb_edit_salary.GetBindingExpression(TextBox.TextProperty);
            binding_salary.UpdateSource();
            /*BindingExpression binding_dept =
               cb_edit_department.GetBindingExpression(TextBox.TextProperty);
            binding_dept.UpdateSource();*/

            this.Close();
        }
    }
}
