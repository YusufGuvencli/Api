using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Result;
using Dapper;
using System;
using System.Data;

namespace Data.DapperRepository
{
    public class DpRepository<T> : ConnectionFactory, IDpRepository<T> where T : class, IEntity, new()
    {
        public IDataResult<T> Any(string query, DynamicParameters parameters)
        {
            try
            {
                return new SuccessDataResult<T>(Connection().QueryFirstOrDefault<T>(query, parameters));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<T>(ex.Message);
            }
            finally
            {
                Close();
                Dispose();
            }
        }

        public async Task<IDataResult<T>> AnyAsync(string query, DynamicParameters parameters)
        {
            try
            {
                return new SuccessDataResult<T>(await Connection().QueryFirstOrDefaultAsync<T>(query, parameters));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<T>(ex.Message);
            }
            finally
            {
                Close();
                Dispose();
            }
        }

        public IResult ExecuteProcedure(string query, DynamicParameters parameters)
        {
            try
            {
                using IDbTransaction transaction = Connection().BeginTransaction();
                Connection().Execute(query, parameters, transaction);
                transaction.Commit();
                return new SuccessResult();
            }
            catch (System.Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            finally
            {
                Close();
                Dispose();
            }
        }

        public async Task<IResult> ExecuteProcedureAsync(string query, DynamicParameters parameters)
        {
            try
            {
                using IDbTransaction transaction = Connection().BeginTransaction();
                await Connection().ExecuteAsync(query, parameters, transaction);
                transaction.Commit();
                return new SuccessResult();
            }
            catch (System.Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            finally
            {
                Close();
                Dispose();
            }
        }

        public IResult ExecuteQuery(string query)
        {
            try
            {
                using IDbTransaction transaction = Connection().BeginTransaction();
                Connection().Execute(query);
                return new SuccessResult();
            }
            catch (System.Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            finally
            {
                Close();
                Dispose();
            }
        }

        public IResult ExecuteQuery(string query, DynamicParameters parameters)
        {
            using (var con = Connection())
            {
                try
                {
                    IDbTransaction transaction = con.BeginTransaction();
                    con.Execute(query, parameters, transaction);
                    transaction.Commit();
                    return new SuccessResult();
                }
                catch (System.Exception ex)
                {
                    return new ErrorResult(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Task<IResult> ExecuteQueryAsync(string query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> ExecuteQueryAsync(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<ScalarEntity> ExecuteScalar(string query, DynamicParameters p)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<ScalarEntity>> ExecuteScalarAsync(string query, DynamicParameters p)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<T> FirstOrDefault(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<T>> FirstOrDefaultAsync(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<IEnumerable<T>> Get(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<IEnumerable<T>> GetAll(string query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<T>>> GetAllAsync(string query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<T>>> GetAsync(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<T> GetById(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<T>> GetByIdAsync(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<IEnumerable<T>> GetWithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<IEnumerable<T>> GetWithQuery(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<T>>> GetWithQueryAsync(string query)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<T>>> GetWithQueryAsync(string query, DynamicParameters parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}