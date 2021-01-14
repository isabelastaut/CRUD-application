using CRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option)
        {
            Database.EnsureCreated(); /// toda vez que iniciar a aplicação, verifica se o banco existe. Se não existir, ele vai criar
        }


        public DbSet<User> User { get; set; } /// cria o banco usando esse modelo
    }
}
