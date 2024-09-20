using System.ComponentModel.DataAnnotations;

namespace Bemol.Customer.Api.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public long DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long ZipCode { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsActive { get; set; }
    }
}
