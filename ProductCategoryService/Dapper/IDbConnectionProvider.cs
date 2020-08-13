using System.Data;

namespace ProductCategoryService.Dapper
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetDbConnection();
    }
}