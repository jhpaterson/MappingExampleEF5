using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MappingExample
{
    public class Department
    {
        private List<Employee> employees;

        [Key]                  
        public virtual string DepartmentName { get; set; }

        public virtual List<Employee> Employees
        {
            get { return employees; }
        }

        public Department()
        {
            employees = new List<Employee>();
        }
    }
}
