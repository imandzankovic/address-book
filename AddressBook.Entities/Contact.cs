using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AddressBook.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        public int Phone { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

    }
}

