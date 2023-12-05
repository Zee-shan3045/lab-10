namespace Q1
{
    public partial class Form1 : Form
    {
        private List<Employee> employees;
        public Form1()
        {
            InitializeComponent();
            InitializeEmployees();
        }

        private void InitializeEmployees()
        {
            employees = new List<Employee>
            {
                new Employee("Fadiy", "Fakhouri", 675),
                new Employee("Terrygg", "hj", 67777),
                new Employee("Eugeklne", "mnj", 89),
                new Employee("Lance", "hgf", 567),
                new Employee("mikel", "ohy", 0990),
                new Employee("Michael", "chill", 6778),
                new Employee("sydnet", "chill2", 4980),
                new Employee("Clarie", "O'Donelle", 4500),
                new Employee("Cesar", "Garcia", 1000),
                new Employee("Hanying", "Feng", 8000),
            };
        }

        private void DisplayResults(List<Employee> resList)
        {
            listView1.Items.Clear();

            foreach (var employee in resList)
            {
                var item = new ListViewItem(new[] { employee.FirstName, employee.LastName, employee.Salary.ToString() });
                listView1.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayResults(employees);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = employees.Where(emp => emp.Salary >= 4000 && emp.Salary <= 6000);
            DisplayResults(result.ToList());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = employees.OrderBy(emp => emp.FirstName);
            DisplayResults(result.ToList());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = employees.Distinct(new EmployeeComparer());
            DisplayResults(result.ToList());
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public Employee(string firstName, string lastName, int salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
    }
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName.Equals(y.FirstName) && x.LastName.Equals(y.LastName) && x.Salary == y.Salary;
        }
        public int GetHashCode(Employee obj)
        {
            return obj.FirstName.GetHashCode() ^ obj.LastName.GetHashCode() ^ obj.Salary.GetHashCode();
        }
    }


}