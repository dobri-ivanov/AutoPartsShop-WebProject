using AutoPartsShop.Web.ViewModels.Part;

namespace AutoPartsShop.Services.Data.Interfaces
{
    public interface IPartService
    {
        public Task<IEnumerable<PartViewModel>> All();
    }
}
