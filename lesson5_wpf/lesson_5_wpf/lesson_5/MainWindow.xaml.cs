using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    ////    Домашнее задание
    ////Создать WPF -приложение для ведения списка сотрудников компании.
    ////1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
    ////2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение).
    ////Это можно сделать, например, с использованием ComboBox или ListView.
    ////3. Предусмотреть редактирование сотрудников и департаментов.Должна быть возможность
    ////изменить департамент у сотрудника.Список департаментов для выбора можно выводить в
    ////ComboBox, и все это можно выводить на дополнительной форме.
    ////4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать это
    ////либо на форме редактирования, либо сделать новую форму.


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new
        ObservableCollection<Employee>();
        ObservableCollection<Department> depts = new
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
            //employees.Add(new Employee()
            //{
            //    Emp_Id = 1, Name = "Vasya", Age = 22, Salary = 3000});

            //employees.Add(new Employee()
            //{
            //    Emp_Id = 2, Name = "Petya", Age = 25, Salary = 6000 });

            //employees.Add(new Employee()
            //{
            //    Emp_Id = 3, Name = "Kolya", Age = 23, Salary = 8000 });
            depts.Add(new Department(1));
            depts.Add(new Department(2));
            depts.Add(new Department(3));
            depts.Add(new Department(4));
            depts.Add(new Department(5));
            AddNewEmployee();
            AddNewEmployee();
            AddNewEmployee();
            AddNewEmployee();
            AddNewEmployee();
            

            lv_employees.ItemsSource = employees;
            //cbDepartments.ItemsSource = depts;
        }
        void AddNewEmployee()
        {
            employees.Add(new Employee(
                ++count_emp_id, 
                "Name_" + count_emp_id, 
                rnd.Next(18, 66), 
                2500 + rnd.NextDouble() * 7500, 
                depts[rnd.Next(0,5)]));
        }

        void AddNewDepartment()
        {
            depts.Add(new Department(rnd.Next(1, 6)));
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
                edit_Form.ShowDialog();
            }
        }

        private void lv_employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editemployee = e.AddedItems[0] as Employee;
            MessageBox.Show(editemployee.ToString());
        }
    }

    public class Department
    {        
        public int Dept_Id { get; set; }
        public Department(int _id)
        {
            Dept_Id = _id;
        }
        /// <summary>
        /// default cotr
        /// </summary>
        public Department()
        {          
        }

        public override string ToString()
        {
            return $"Department: {Dept_Id}";
        }
    }

    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public Department Emp_dept { get; set; }
        /// <summary>
        /// Cotr with parameters
        /// </summary>
        /// <param name="id">inkrement id</param>
        /// <param name="_name">name</param>
        /// <param name="_age">age</param>
        /// <param name="_salary">salary</param>
        public Employee(int id, string _name, int _age, double _salary, Department department)
        {
            //MainWindow.count_emp_id++;
            Emp_Id = id;            
            Name = _name;
            Age = _age;
            Salary = _salary;
            Emp_dept = department; 
        }
        /// <summary>
        /// default cotr
        /// </summary>
        public Employee()
        {
            //MainWindow.count_emp_id++;
        }

        public override string ToString()
        {
            return $"{Emp_Id}\t{Name}\t{Age}\t{Salary:0}\t{Emp_dept}";
        }
    }
}
