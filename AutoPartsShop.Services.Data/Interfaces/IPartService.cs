namespace AutoPartsShop.Services.Data.Interfaces
{
    using AutoPartsShop.Web.ViewModels.Part;
    
    public interface IPartService
    {
        public Task<IEnumerable<PartViewModel>> All();
        public Task AddSaveChangesAsync(PartFormModel formModel);
    }
}
