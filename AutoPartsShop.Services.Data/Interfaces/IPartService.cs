namespace AutoPartsShop.Services.Data.Interfaces
{
    using AutoPartsShop.Web.ViewModels.Part;
    using System;

    public interface IPartService
    {
        public Task<IEnumerable<PartViewModel>> All();
        public Task AddSaveChangesAsync(PartFormModel formModel);
        public Task<PartDeleteViewModel?> DeleteDataAsync(Guid id);
        public Task<Guid> DeleteAsync(Guid id);
        public Task<PartFormModel?> EditDataAsync(Guid id);
        Task<Guid> EditSaveChangesAsync(Guid id, PartFormModel model);
    }
}
