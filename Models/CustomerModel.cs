using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CustomerModel
    {
        [Key] 
        public int cus_id { get; set; }
        public string cus_name { get; set; }
        public string cus_lname { get; set; }
        public string cus_add { get; set; }
        public string cus_tel { get; set; }
        public DateTime bdate { get; set; }
        public string sex { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
