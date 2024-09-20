namespace Bemol.Customer.Api.Controllers.ViewModels
{
    public class AddCustomer
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public long DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long ZipCode { get; set; }
    }
}
