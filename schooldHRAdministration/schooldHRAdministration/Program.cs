using HRAdministrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schooldHRAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            //foreach(IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}
            //Console.WriteLine($"Total Salaries (including bonus):{totalSalaries}");
              Console.WriteLine($"Total salaries including bonus:{employees.Sum(e => e.Salary)}");
              Console.ReadKey();
        }
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);


            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,2, "Maryam", "Erfani", 50000);
            IEmployee teacher3 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Andrew", "David", 60000);


            IEmployee teacher4 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 4, "Vijay", "Kumar", 70000);
            
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
    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee=null;
            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee=new Teacher { Id = id, FirstName=firstName, LastName=lastName,Salary=salary};
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee=new HeadOfDepartment {  Id = id, FirstName=firstName,LastName=lastName,Salary=salary}; 
                    break;
                case EmployeeType.DeputyHeadMaster: employee=new DeputyHeadMaster {  Id = id, FirstName=firstName,LastName=lastName,Salary =salary}; 
                    break;
                case EmployeeType.HeadMaster:
                    employee=new HeadMaster {  Id = id, FirstName=firstName,LastName = lastName,Salary =salary};
                    break;
                default:
                    break;
            }
            return employee;
        }
    }
}
