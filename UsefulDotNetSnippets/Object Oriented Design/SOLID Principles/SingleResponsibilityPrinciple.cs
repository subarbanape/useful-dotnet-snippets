using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets.Object_Oriented_Design.SOLID_Principles
{
    public class SingleResponsibilityPrinciple
    {
        public static void DemoRun()
        {
            int inputEmployeeId = 18729;

            // See how the information is divided into repository, payroll and employee object.
            // Each having its own responsibility.
            // With the SRP, we have a clean way to maintain and extend classes pertaining to their functionalities.

            IEmployeeRepository employeeRepository = new ABCCompanyEmployeeRepository();
            Employee employee = employeeRepository.FindEmployee(inputEmployeeId);
            IPayroll payroll = new ABCCompanyPayroll();
            payroll.Run(employee);
        }

        private interface IPayroll
        {
            void Run(Person employee);
        }

        private interface IEmployeeRepository
        {
            Employee FindEmployee(int inputEmployeeId);
        }

        public class Person
        {
            public int Id { get; set; }
        }

        class Employee : Person
        {
        }

        private class ABCCompanyPayroll : IPayroll
        {
            public void Run(Person employee)
            {
                throw new NotImplementedException();
            }
        }

        private class ABCCompanyEmployeeRepository : IEmployeeRepository
        {
            public Employee FindEmployee(int inputEmployeeId)
            {
                throw new NotImplementedException();
            }
        }
    }
}
