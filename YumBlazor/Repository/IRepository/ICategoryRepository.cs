using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
        //Task<bool> CategoryExists(string name);
        //Task<bool> Save();
    }
}
