namespace AutoPartsShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using AutoPartsShop.Services.Data.Interfaces;
    using AutoPartsShop.Web.Data;
    using AutoPartsShop.Web.ViewModels.Part;
    using AutoPartsShop.Data.Models;

    public class PartService : IPartService
    {
        private readonly AutoPartsDbContext data;

        public PartService(AutoPartsDbContext context)
        {
            data = context;
        }

        public async Task AddSaveChangesAsync(PartFormModel formModel)
        {
            Part part = new Part()
            {
                Name = formModel.Name,
                Description = formModel.Description,
                Price = formModel.Price,
                VehicleId = formModel.VehicleId,
                ImageUrl = formModel.ImageUrl
            };

            await data.Parts.AddAsync(part);
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<PartViewModel>> All()
        {
            List<PartViewModel> parts = await data.Parts
               .Select(p => new PartViewModel()
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
                   ImageUrl = p.ImageUrl,
                   Vehicle = String.Format($"{p.Vehicle.Make} {p.Vehicle.Model}"),
                   Seller = p.Vehicle.Company.Name
               })
               .ToListAsync();

            return parts;
        }

        public async Task<ICollection<PartViewModel>> AllByCompanyAsync(Guid id)
        {
            ICollection<PartViewModel> models = new HashSet<PartViewModel>();

            if (data.Parts.Any())
            {
                models = await data.Parts
               .Include(p => p.Vehicle)
               .Where(p => p.Vehicle.CompanyId == id)
               .Select(p => new PartViewModel()
               {
                   ImageUrl = p.ImageUrl,
                   Name = p.Name,
                   Price = p.Price,
                   Id = p.Id,
                   CompanyId = p.Vehicle.CompanyId,
                   Vehicle = p.Vehicle.ToString()
               })
               .ToListAsync();
            }

            return models;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            if (data.Parts.Any())
            {
                Part? part = await data.Parts.FirstAsync(p => p.Id == id);

                if (part != null)
                {
                    data.Parts.Remove(part);
                    await data.SaveChangesAsync();
                    return part.VehicleId;
                }
            }

            return Guid.Empty;
        }

        public async Task<PartDeleteViewModel?> DeleteDataAsync(Guid id)
        {
            if (data.Parts.Any())
            {
                Part? part = await data.Parts
                .Include(p => p.Vehicle)
                .FirstAsync(p => p.Id == id);

                if (part != null)
                {
                    PartDeleteViewModel model = new PartDeleteViewModel()
                    {
                        Id = id,
                        Name = part.Name,
                        Description = part.Description,
                        Price = part.Price,
                        ImageUrl = part.ImageUrl,
                        Vehicle = part.Vehicle.ToString()
                    };

                    return model;
                }
            }

            return null;
        }

        public async Task<PartFormModel?> EditDataAsync(Guid id)
        {
            if (data.Parts.Any())
            {
                Part? part = await data.Parts
                .Include(p => p.Vehicle)
                .FirstAsync(p => p.Id == id);

                if (part != null)
                {
                    PartFormModel model = new PartFormModel()
                    {
                        Id = id,
                        Name = part.Name,
                        Description = part.Description,
                        Price = part.Price,
                        ImageUrl = part.ImageUrl,
                        VehicleId = part.VehicleId,
                        CompanyId = part.Vehicle.CompanyId
                    };

                    return model;
                }
            }
            return null;
        }

        public async Task<Guid> EditSaveChangesAsync(Guid id, PartFormModel model)
        {
            if (data.Parts.Any())
            {
                Part? part = await data.Parts
                .Include(p => p.Vehicle)
                .FirstAsync(p => p.Id == id);

                if (part != null)
                {
                    part.Name = model.Name; 
                    part.Description = model.Description;
                    part.Price = model.Price;
                    part.ImageUrl = model.ImageUrl;

                    Guid oldVehicleId = part.VehicleId;
                    part.VehicleId = model.VehicleId;

                    await data.SaveChangesAsync();

                    return oldVehicleId;
                }
            }
            return Guid.Empty;
        }

        public async Task<PartInfoViewModel?> InfoAsync(Guid id)
        {
            PartInfoViewModel? model = new PartInfoViewModel();

            Part? part = await data.Parts
                .Include(p => p.Vehicle)
                .Include(p => p.Vehicle.Company)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (part != null)
            {
                var company = data.Companies
                    .Where(c => c.Id == part.Vehicle.CompanyId);

                model.Id = id;
                model.Name = part.Name;
                model.Vehicle = part.Vehicle.ToString();
                model.Description = part.Description;
                model.Price = part.Price;
                model.ImageUrl = part.ImageUrl;
                model.Company = part.Vehicle.Company.ToString();

                return model;
            }

            return null;

        }
    }
}
