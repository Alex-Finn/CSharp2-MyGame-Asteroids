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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new
        ObservableCollection<Employee>();
        ObservableCollection<Department> depts = new
        ObservableCollection<Department>();
        Random rnd = new Random();
        public static int count_emp_id = 0;
        public static int count_dept_id = 0;

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
            AddNewEmployee();
            AddNewEmployee();
            AddNewEmployee();
            AddNewEmployee();
            AddNewEmployee();
            AddNewDepartment();
            AddNewDepartment();
            AddNewDepartment();
            AddNewDepartment();

            lvEmployee.ItemsSource = employees;
            cbDepartments.ItemsSource = depts;
        }
        void AddNewEmployee()
        {
            employees.Add(new Employee(
                count_emp_id, 
                "Name_" + count_emp_id, 
                rnd.Next(18, 66), 
                2500 + rnd.NextDouble() * 7500));
        }

        void AddNewDepartment()
        {
            depts.Add(
                new Department(
                    rnd.Next(1, 6),
                    Department.Parent_depts.basic));
        }

        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }
        private void lbEmployee_SelectionChanged(object sender,
        System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployee();
        }
    }

    public class Department
    {
        public enum Parent_depts
        {
            I = 1,
            II,
            III,
            IV,
            V,
            basic = 0
        }
        public int Dept_Id { get; set; }
        public Parent_depts Parent_Dept { get; set; }
        public Department(int _id, Parent_depts _parent)
        {
            MainWindow.count_dept_id++;
            Dept_Id = _id;
            Parent_Dept = _parent;
        }
        /// <summary>
        /// default cotr
        /// </summary>
        public Department()
        {
            MainWindow.count_dept_id++;
            Parent_Dept = Parent_depts.basic;            
        }
        public override string ToString()
        {
            return $"Department: {Dept_Id}\tParent department: {Parent_Dept}";
        }
    }

    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        /// <summary>
        /// Cotr with parameters
        /// </summary>
        /// <param name="id">inkrement id</param>
        /// <param name="_name">name</param>
        /// <param name="_age">age</param>
        /// <param name="_salary">salary</param>
        public Employee(int id, string _name, int _age, double _salary)
        {
            MainWindow.count_emp_id++;
            Emp_Id = id;            
            Name = _name;
            Age = _age;
            Salary = _salary;
        }
        /// <summary>
        /// default cotr
        /// </summary>
        public Employee()
        {
            MainWindow.count_emp_id++;
        }

        public override string ToString()
        {
            return $"{Emp_Id}\t{Name}\t{Age}\t{Salary:0}";
        }
    }
}
