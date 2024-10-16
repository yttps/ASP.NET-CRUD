using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TypeProduct
    {
        [Key] //4.set type_id Prymary key
        public int type_id { get; set; } 
        public string type_name { get; set; }
    }
}
