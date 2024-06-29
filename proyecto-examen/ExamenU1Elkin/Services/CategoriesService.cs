using ExamenU1Elkin.Database.Entities;
using ExamenU1Elkin.Dtos.Categories;
using ExamenU1Elkin.Services.Interfaces;
using System.Xml;

namespace ExamenU1Elkin.Services
{
    public class CategoriesService : ICategoriesService
    {
        public readonly string _JSON_FILE;

        public CategoriesService() 
        {
            _JSON_FILE = "SeedData/Productos.json";
        }

        public async Task<List<CategoryDto>> GetCategoriesListAsync() {
            return await ReadCategoriesFromFileAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id) { 
            var categories =  await ReadCategoriesFromFileAsync();
            CategoryDto producto = categories.FirstOrDefault(c => c.Id == id);
            return producto;
        }

        public async Task<bool> CreateAsync(CategoryCreateDto dto)
        {
            var productoDtos = await CategoryDto{ 
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Cantidad = dto.Canti,
                Precio = dto.Sale,
            };
            
            categoriesDtos.Add(CategoryDto);

            var categories = categoriesDtos.Select(x => new Categoria{ 
            Id = x.Id,
            Name = x.Name,
            Cantidad = x.Canti,
            Precio = x.Sale,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);

            return true;
        }

        public async Task<bool> EditAsync(CategoryEditDto dto, Guid id)
        {
            var categoriesDto = await ReadCategoriesFromFileAsync();

            var existingCategory = categoriesDto
                .FirstOrDefault(category => category.Id == id);
            if (existingCategory is null)
            {
                return false;
            }

            for (int i = 0; i < categoriesDto.Count; i++)
            {
                if (categoriesDto[i].Id == id)
                {
                    categoriesDto[i].Name = dto.Name;
                    categoriesDto[i].Canti = dto.Canti;
                    categoriesDto[i].Sale = dto.Precio;
                }
            }

            var categories = categoriesDto.Select(x => new Categoria
            {
                Id = x.Id,
                Name = x.Name,
                Cantidad = x.Canti,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoriesDto = await ReadCategoriesFromFileAsync();
            var categoryToDelete = categoriesDto.FirstOrDefault(x => x.Id == id);

            if (categoryToDelete is null)
            {
                return false;
            }

            categoriesDto.Remove(categoryToDelete);

            var categories = categoriesDto.Select(x => new Categoria
            {
                Id = x.Id,
                Name = x.Name,
                Cantidad = x.Canti,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);

            return true;
        }

        private async Task<List<CategoryDto>> ReadCategoriesFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<CategoryDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var categories = JsonConvert.DeserializeObject<List<Categoria>>(json);

            var dtos = categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Canti = x.Cantidad,
            }).ToList();

            return dtos;
        }

        private async Task WriteCategoriesToFileAsync(List<Categoria> categories)
        {
            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            if (File.Exists(_JSON_FILE))
            {
                await File.WriteAllTextAsync(_JSON_FILE, json);
            }

        }
    }
}
