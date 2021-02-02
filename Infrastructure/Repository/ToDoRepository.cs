using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Repository
{
    public class ToDoRepository:IToDoRepository
    {
         private readonly IConfiguration configuration;
        public ToDoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}