using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            _db.Category.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return false;
            }
            _db.Category.Remove(category);
            return (await _db.SaveChangesAsync()) > 0;
        }
        public async Task<Category> GetCategory(int id)
        {
            var category = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return new Category();
            }
            return category;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _db.Category.ToListAsync();
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            var categoryFromDb = await _db.Category.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (categoryFromDb == null)
            {
                return category;
            }
            categoryFromDb.Name = category.Name;
            _db.Category.Update(categoryFromDb);
            await _db.SaveChangesAsync();
            return categoryFromDb;
        }
    }
}
