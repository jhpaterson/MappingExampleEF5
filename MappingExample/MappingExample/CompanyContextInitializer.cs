using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MappingExample
{
    public class CompanyContextInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            base.Seed(context);

            Address ad1 = new Address
            {
                AddressId = 1,
                PropertyName = "Code-First Quay",
                PropertyNumber = 10,
                PostCode = "G2 1YY"
            };

            Address ad2 = new Address
            {
                AddressId = 2,
                PropertyName = "ORM Mansions",
                PropertyNumber = 11,
                PostCode = "G3 0TT"
            };

            Employee emp1 = new Employee
            {
                Name = "Jenson",
                Username = "jenson",
                PhoneNumber = "9876",
                Address = ad1
            };

            SalariedEmployee emp2 = new SalariedEmployee
            {
                Name = "Checo",
                Username = "checo",
                PhoneNumber = "5432",
                Address = ad2,
                PayGrade = 3
            };

            Department dep1 = new Department
            {
                DepartmentName = "Marketing"
            };

            dep1.Employees.Add(emp1);
            dep1.Employees.Add(emp2);

            context.Departments.Add(dep1);

            context.SaveChanges();

        }
    }
}
