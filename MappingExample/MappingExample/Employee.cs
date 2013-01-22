using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MappingExample
{
    public class Employee
    {
        protected const string EMAIL_SUFFIX = "@example.com";

        public virtual int EmployeeId{get;set;}

        public virtual string Name{get;set;}

        [Required]
        public virtual string Username{get;set;}

        public virtual Address Address{get;set;}

        public virtual string PhoneNumber{get;set;}

        public virtual string DepartmentName { get; set; }

        public virtual Department Department { get; set; }

        [NotMapped]
        public virtual string Email
        {
            get
            {
                return Username + "@example.com";
            }
        }

        //public virtual string Email()
        //{
        //    return Username + "@example.com"; 
        //}

    }
}
