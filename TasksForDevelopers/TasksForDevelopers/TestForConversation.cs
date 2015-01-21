//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

////http://www.fulcrumweb.com.ua/archives/5271
//namespace TasksForDevelopers
//{
//	abstract class Employee
//	{
//		public int Id { get; set; }
//		public string Name { get; set; }
//		public double Salary { get; set; }
//		protected Employee() { }
//		protected Employee(int id, string n, double salary)
//		{
//			Id = id;
//			Name = n;
//			Salary = salary;
//		}
//		public abstract double GetSalary(double salary);
//	}
//	class FixedSalaryEmployee : Employee
//	{
//		public FixedSalaryEmployee(int id, string name, double salary)
//			: base(id, name, salary)
//		{
//		}
//		public override double GetSalary(double salary)
//		{
//			return salary;
//		}
//	}
//	class HourlySalaryEmployee : Employee
//	{
//		public HourlySalaryEmployee(int id, string name, double salary)
//			: base(id, name, salary)
//		{

//		}

//		public override double GetSalary(double salary)
//		{
//			return 20.8 * 8 * salary;
//		}
//	}

//	class EmployeeContainer : List<Employee>
//	{
//		//Load XmlFile
//		public void LoadXmlFile(string fileName)
//		{

//			XmlDocument xmlDocument = new XmlDocument();
//			xmlDocument.Load(fileName);
//			XmlNodeList employeeType = xmlDocument.GetElementsByTagName("Employee");
//			XmlNodeList employeeId = xmlDocument.GetElementsByTagName("id");
//			XmlNodeList employeeNames = xmlDocument.GetElementsByTagName("name");
//			XmlNodeList employeeSalary = xmlDocument.GetElementsByTagName("salary");
//			for (int i = 0; i < employeeType.Count; i++)
//			{

//				var xmlAttributeCollection = employeeType[i].Attributes;//get type of employee
//				if (xmlAttributeCollection != null && xmlAttributeCollection["type"].Value == "1")
//				{

//					this.Add(new FixedSalaryEmployee(int.Parse(employeeId[i].InnerText), employeeNames[i].InnerText,
//											   double.Parse(employeeSalary[i].InnerText)));
//				}
//				else
//				{
//					this.Add(new HourlySalaryEmployee(int.Parse(employeeId[i].InnerText), employeeNames[i].InnerText,
//											  double.Parse(employeeSalary[i].InnerText)));
//				}
//			}


//		}
//		//Get the list of sorted employees
//		public List<Employee> SortEmployee()
//		{
//			var sortedEmployees = this.OrderByDescending(salary => salary.GetSalary(salary.Salary)).ThenBy(name => name.Name).ToList();
//			return sortedEmployees;
//		}
//		//Output the sorted employees
//		public void SortedEmployees()
//		{
//			var getSortedEmployees = this.SortEmployee();
//			foreach (var sortedEmployee in getSortedEmployees)
//			{
//				Console.WriteLine(sortedEmployee.Name + "=" + sortedEmployee.GetSalary(sortedEmployee.Salary));
//			}
//		}
//		//Get the first five employees in (a) paragraph
//		public void GetFirstFiveEmployees()
//		{
//			var getSortedEmployees = this.SortEmployee();
//			Console.WriteLine("The first five employees");
//			var five = getSortedEmployees.Take(5);
//			foreach (var employee in five)
//			{
//				Console.WriteLine(employee.Name);
//			}
//		}
//		//Get the last three employees in (a) paragraph
//		public void GetTheLastThreeEmployees()
//		{
//			var getSortedEmployees = this.SortEmployee();
//			Console.WriteLine("The last three employees");
//			var three = getSortedEmployees.Skip(getSortedEmployees.Count - 3).Take(3);
//			foreach (var employee in three)
//			{
//				Console.WriteLine(employee.Name);
//			}

//		}
//	}

//	class Program
//	{
//		static void Main(string[] args)
//		{
//			var fileName = "Employee.xml";
//			if (File.Exists(fileName))
//			{
//				EmployeeContainer container = new EmployeeContainer();
//				container.LoadXmlFile(fileName);
//				Console.WriteLine("\nparagraph a\n");
//				container.SortedEmployees();
//				Console.WriteLine("\nparagraph b\n");
//				container.GetFirstFiveEmployees();
//				Console.WriteLine("\nparagraph c\n");
//				container.GetTheLastThreeEmployees();
//			}
//			else
//			{
//				Console.WriteLine("Not Found File");
//			}

//		}
//	}
//}
