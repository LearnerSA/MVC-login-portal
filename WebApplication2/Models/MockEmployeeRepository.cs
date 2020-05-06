using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeelist;

        public MockEmployeeRepository()
        {
            _employeelist = new List<Employee>()
            {
                new Employee() {Id=1, Department = Dept.IT , Name = "sagnik" , Email = "abc" },
                new Employee() { Id = 2, Department = Dept.IT, Name = "rahul", Email = "abcd" },
                new Employee() {Id=3, Department = Dept.Payroll , Name = "john" , Email = "xyz" }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeelist.Max(e => e.Id) + 1;
            _employeelist.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetallEmployees()
        {
            return _employeelist;
        }

        public Employee GetEmployee(int id)
        {
            return _employeelist.FirstOrDefault(e => e.Id == id);
        }
    }
}
