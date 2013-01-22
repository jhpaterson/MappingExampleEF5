using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // set database initializer
            Database.SetInitializer<CompanyContext>(new CompanyContextInitializer());

            // initialise EF Profiler
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            CompanyContext db = new CompanyContext();

            // Create Address objects
            Address ad1 = new Address
            {
                AddressId = 3,
                PropertyName = "LINQ Tower",
                PropertyNumber = 99,
                PostCode = "G1 1XX"
            };

            Address ad2 = new Address
            {
                AddressId = 4,
                PropertyName = "EF House",
                PropertyNumber = 101,
                PostCode = "G4 0XX"
            };

            // Create Employee objects and associate with Addresses
            Employee emp1 = new Employee
            {
                Name = "Fernando",
                Username = "fernando",
                PhoneNumber = "1234",
                Address = ad1
            };

            SalariedEmployee emp2 = new SalariedEmployee
            {
                Name = "Felipe",
                Username = "felipe",
                PhoneNumber = "5678",
                Address = ad2,
                DepartmentName = "Sales",                   // set FK property
                PayGrade = 3
            };

            // Create Department object
            Department dep1 = new Department
            {
                DepartmentName = "Sales"
            };

            // Add Employee objects to Department
            dep1.Employees.Add(emp1);
            //dep1.Employees.Add(emp2);

            db.Departments.Add(dep1);
            //db.Employees.Add(emp1);
            db.Employees.Add(emp2);
            db.SaveChanges();

            // dispose context and open a new context
            db.Dispose();
            db = new CompanyContext();

            // reload entity from database
            //db.Entry(dep1).Reload();

            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;

            List<Employee> employees = db.Employees
                .Include(e => e.Address)
                .Include(e => e.Department)
                .ToList<Employee>();   

            Address address = employees[0].Address;

            var query = from d in db.Departments
                        where d.DepartmentName == "Marketing"
                        select d;

            //string command = query.ToString();
            //Console.WriteLine(command + "\n");

            Department department = query.FirstOrDefault();


            // set break point here and inspect objects with debugger                   
            Console.WriteLine("Press any key to finish...");
            Console.ReadLine();
            
        }
    }
}
