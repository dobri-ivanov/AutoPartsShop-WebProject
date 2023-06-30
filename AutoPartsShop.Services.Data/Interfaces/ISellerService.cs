namespace AutoPartsShop.Services.Data.Interfaces
{
    using AutoPartsShop.Web.ViewModels.Seller;

    public interface ISellerService
    {
        public Task<bool> IsSeller(Guid userId);
        public Task<Guid> IsValidEmployee(string email);
        public Task<bool> IsOwner(Guid userId, Guid companyId);
        public Task<Guid> CompanyId(Guid userId);
        public Task<Guid> CompanyIdBySellerId (Guid id);
        public Task AddEmployeeAsync(SellerFormModel formModel);
        public Task<SellerEditFormModel> EditDataAsync(Guid sellerId);
        public Task EditAsync(Guid sellerId, SellerEditFormModel formModel);
        public Task<SellerFormModel> DeleteAsync(Guid sellerId);
    }

}
