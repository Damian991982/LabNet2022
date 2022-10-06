namespace PracticaMVC.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shippers
    {
        [Key]
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(40, ErrorMessage = "The field {0} must have a maximum length of 40 characters")]
        public string CompanyName { get; set; }

        [StringLength(24, ErrorMessage = "The field {0} must have a maximum length of 24 characters")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "The format is wrong")]
        public string Phone { get; set; }
    }
}
