using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Models
{
    public class Student
    {
       
        [Key] //data-anotations
        
        public int StudentId { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Required(ErrorMessage ="This Field is Required")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Roll No")]
        public string Rollno { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Email ID")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Address")]
        public string Address { get; set; }

    }
}
