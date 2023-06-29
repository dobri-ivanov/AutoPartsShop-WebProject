namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface ISellerService
    {
        public Task<bool> IsSeller(Guid userId);
        public Task<bool> IsOwner(Guid userId);
        public Task<Guid> CompanyId(Guid userId);
    }

}
