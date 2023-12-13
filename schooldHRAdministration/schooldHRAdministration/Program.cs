using HRAdministrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schooldHRAdministration
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            foreach(IEmployee employee in employees)
            {
                totalSalaries += employee.Salary;
            }
            Console.WriteLine($"Total Salaries (including bonus):{totalSalaries}");
            Console.ReadKey();
        }
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = new Teacher
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Fisher",
                Salary = 40000
            };
            IEmployee teacher2 = new Teacher
            {
                Id = 2,
                FirstName = "Andrew",
                LastName = "David",
                Salary = 50000
            };
            IEmployee teacher3 = new Teacher
            {
                Id = 3,
                FirstName = "Maryam",
                LastName = "Erfani",
                Salary = 60000
            };
            IEmployee teacher4 = new Teacher
            {
                Id = 4,
                FirstName = "Bredna",
                LastName = "Mullins",
                Salary = 40000
            };
            employees.Add(teacher1);
            employees.Add(teacher2);
            employees.Add(teacher3);
            employees.Add(teacher4);
        }
    }
    public class Teacher: EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }
    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }
    public class DeputyHeadMaster: EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
    }
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }
}
