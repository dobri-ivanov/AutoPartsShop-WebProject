namespace AutoPartsShop.Web.ViewModels.Company
{
    public class CompanyDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int EmployeeCount { get; set; }
    }
}
