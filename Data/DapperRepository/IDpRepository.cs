using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Result;
using Dapper;

namespace Data.DapperRepository
{
    public interface IDpRepository<T> where T : class, IEntity, new()
    {
        IDataResult<T> GetById(string query, DynamicParameters parameters);
        IDataResult<IEnumerable<T>> GetAll(string query);
        IDataResult<IEnumerable<T>> Get(string query, DynamicParameters parameters);
        IDataResult<T> Any(string query, DynamicParameters parameters);
        IDataResult<T> FirstOrDefault(string query, DynamicParameters parameters);
        IResult ExecuteQuery(string query);
        IResult ExecuteQuery(string query, DynamicParameters parameters);
        IDataResult<IEnumerable<T>> GetWithQuery(string query);
        IDataResult<ScalarEntity> ExecuteScalar(string query, DynamicParameters p);
        IDataResult<IEnumerable<T>> GetWithQuery(string query, DynamicParameters parameters);
        IResult ExecuteProcedure(string query, DynamicParameters parameters);
        Task<IDataResult<T>> GetByIdAsync(string query, DynamicParameters parameters);
        Task<IDataResult<IEnumerable<T>>> GetAllAsync(string query);
        Task<IDataResult<IEnumerable<T>>> GetAsync(string query, DynamicParameters parameters);
        Task<IDataResult<T>> AnyAsync(string query, DynamicParameters parameters);
        Task<IDataResult<T>> FirstOrDefaultAsync(string query, DynamicParameters parameters);
        Task<IResult> ExecuteQueryAsync(string query);
        Task<IResult> ExecuteQueryAsync(string query, DynamicParameters parameters);
        Task<IDataResult<IEnumerable<T>>> GetWithQueryAsync(string query);
        Task<IDataResult<IEnumerable<T>>> GetWithQueryAsync(string query, DynamicParameters parameters);
        Task<IResult> ExecuteProcedureAsync(string query, DynamicParameters parameters);
        Task<IDataResult<ScalarEntity>> ExecuteScalarAsync(string query, DynamicParameters p);
    }
}