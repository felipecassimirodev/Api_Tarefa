﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APITarefas.Models.Entidades;

namespace APITarefas.Data
{
    public class APITarefasContext : DbContext
    {
        public APITarefasContext (DbContextOptions<APITarefasContext> options)
            : base(options)
        {
        }

        public DbSet<Chamado> Chamado { get; set; } = default!;
    }
}
