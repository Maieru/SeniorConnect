﻿using Microsoft.EntityFrameworkCore;
using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<AssinaturaModel> Assinaturas { get; set; }
        public DbSet<PlanoModel> Planos { get; set; }
        public DbSet<LembreteModel> Lembretes { get; set; }
        public DbSet<LembreteMedicamentoModel> LembreteMedicamentos { get; set; }
        public DbSet<MedicamentoModel> Medicamentos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
