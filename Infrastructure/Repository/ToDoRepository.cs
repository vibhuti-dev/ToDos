using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace Infrastructure.Repository
{
    public class ToDoRepository:IToDoRepository
    {
        private readonly IConfiguration configuration;
        public ToDoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(ToDo entity)
        {
            //entity.AddedOn = DateTime.Now;
            var sql = "Insert into ToDos (Description) VALUES (@Description)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM ToDos WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<ToDo>> GetAllAsync()
        {
            var sql = "SELECT * FROM ToDos";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ToDo>(sql);
                return result.ToList();
            }
        }

        public async Task<ToDo> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM ToDos WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<ToDo>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(ToDo entity)
        {
            //entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE ToDos SET Description =@Description WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}