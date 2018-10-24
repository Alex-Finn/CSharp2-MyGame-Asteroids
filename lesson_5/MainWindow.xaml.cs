using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lesson_5
{
    ////    Домашнее задание 7
    ///
    ////    Изменить WPF-приложение для ведения списка сотрудников компании (из урока 5), используя
    ////    связывание данных, DataGrid и ADO.NET.
    ////    1. Создать таблицы Employee и Department в БД MSSQL Server и заполнить списки сущностей
    ////       начальными данными.
    ////    2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение).
    ////       Это можно сделать, например, с использованием ComboBox или ListView.
    ////    3. Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность
    ////       изменить департамент у сотрудника.Список департаментов для выбора можно выводить в
    ////       ComboBox, и все это можно выводить на дополнительной форме.
    ////    4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную
    ////       возможность либо на форме редактирования, либо сделать новую форму.

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Employee> employees = new
        ObservableCollection<Employee>();
        public static ObservableCollection<Department> depts = new
        ObservableCollection<Department>();
        Employee editemployee = new Employee();
        Random rnd = new Random();
        public static int count_emp_id = 0;

        public MainWindow()
        {
            InitializeComponent();
            FillData();
        }
        void FillData()
        {
            //  ============================================================
            //  Запуск однократно для заполнения данных в таблице работников
            //  После продумаю как не коментировать этот блок
            //
            //string connectionString =
            //    @" Data source = (localdb)\MSSQLLocalDB;
            //    initial catalog = Lesson7;
            //    integrated security = True; 
            //    Pooling = False";

            //try
            //{
            //    var random = new Random();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        var employee = new Employee
            //        {
            //            Emp_Id = $"{++count_emp_id}",
            //            Name = $"Name_{random.Next(0, 100)}",
            //            Age = $"{random.Next(18, 100)}",
            //            Salary = $"{random.Next(2500,7501)}",
            //            Emp_dept = $"{random.Next(1, 6)}"
            //        };

            //        var sql = $@"INSERT INTO Employee (Id, Name, Age, Salary, Department)
            //        VALUES ('{employee.Emp_Id}', '{employee.Name}', '{employee.Age}', '{employee.Salary}', '{employee.Emp_dept}')";

            //        //Console.WriteLine(sql);
            //        //Console.WriteLine();

            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            connection.Open();

            //            SqlCommand command = new SqlCommand(sql, connection);
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("exit");
            //}
            //  ===============================================================
            //  Запуск однократно для заполнения данных в таблице департаментов
            //  После продумаю как не коментировать этот блок
            //
            //string connectionString =
            //    @" Data source = (localdb)\MSSQLLocalDB;
            //    initial catalog = Lesson7;
            //    integrated security = True; 
            //    Pooling = False";

            //try
            //{
            //    var random = new Random();
            //    for (int i = 0; i < 5; i++)
            //    {
            //        var dept = new Department
            //        {
            //            Dept_Id = i,
            //            Name = $"Department"                        
            //        };

            //        var sql = $@"INSERT INTO Department (Id, Name)
            //        VALUES ('{dept.Dept_Id}', '{dept.Name}')";

            //        //Console.WriteLine(sql);
            //        //Console.WriteLine();

            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            connection.Open();

            //            SqlCommand command = new SqlCommand(sql, connection);
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("exit");
            //}

            //depts.Add(new Department(1));
            //depts.Add(new Department(2));
            //depts.Add(new Department(3));
            //depts.Add(new Department(4));
            //depts.Add(new Department(5));
            //AddNewEmployee();
            //AddNewEmployee();
            //AddNewEmployee();
            //AddNewEmployee();
            //AddNewEmployee();


            //lv_employees.ItemsSource = employees;
            //cbDepartments.ItemsSource = depts;
        }
        void AddNewEmployee()
        {
            //employees.Add(new Employee(
            //    ++count_emp_id,
            //    "Name_" + count_emp_id,
            //    rnd.Next(18, 66),
            //    2500 + rnd.NextDouble() * 7500,
            //    depts[rnd.Next(0, 5)]));
        }

        void AddNewDepartment()
        {
            //depts.Add(new Department(rnd.Next(1, 6)));
        }

        //private void lv_employees_Selected (object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(e.Source.ToString());
        //}
        //private void lbEmployee_SelectionChanged(object sender,
        //System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    MessageBox.Show(e.AddedItems[0].ToString());
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployee();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (editemployee.Name != null)
            {
                Edit_Form edit_Form = new Edit_Form(editemployee);
                edit_Form.Owner = this;
                edit_Form.ShowDialog();
            }
        }
        private void lv_employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editemployee = e.AddedItems[0] as Employee;
            //MessageBox.Show(editemployee.ToString());
        }

        private void Edit_Click(object sender, MouseButtonEventArgs e)
        {
            if (editemployee.Name != null)
            {
                Edit_Form edit_Form = new Edit_Form(editemployee);
                edit_Form.Owner = this;
                edit_Form.ShowDialog();
            }
        }
    }     
}
