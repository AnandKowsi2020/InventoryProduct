using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace myTestWebApi.Models
{
    public class clsEmployees 
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
