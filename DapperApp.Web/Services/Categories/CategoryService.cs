using Dapper;
using DapperApp.Web.Context;
using DapperApp.Web.DTOs.Categories;

namespace DapperApp.Web.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "Insert Into Categories (Name) Values(@Name)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createCategoryDto.Name);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete From Categories Where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "select * from categories";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<ResultCategoryDto> GetByIdAsync(int id)
        {
            string query = "select * from categories Where CategoryId=@CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Categories Set Name = @Name Where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", updateCategoryDto.Name);
            parameters.Add("@CategoryId", updateCategoryDto.CategoryId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

        }
    }
}
