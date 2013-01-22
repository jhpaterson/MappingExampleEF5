using System.ComponentModel.DataAnnotations.Schema;

namespace MappingExample
{
    public class HourlyPaidEmployee : Employee
    { 
        [NotMapped]
        public override string Email
        {
            get
            {
                return Username + "_h_" + "@example.com";
            }
        }

        //public override string Email()
        //{
        //    return  Username + "_h_" + "@example.com";
        //}
    }
}
