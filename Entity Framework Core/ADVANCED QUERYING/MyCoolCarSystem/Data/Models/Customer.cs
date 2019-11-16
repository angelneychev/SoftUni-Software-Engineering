namespace MyCoolCarSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.Customer;

    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        public string FistName { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public ICollection<CarPurchase> Puschases { get; set; } = new HashSet<CarPurchase>();
    }
}
