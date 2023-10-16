using Microsoft.EntityFrameworkCore;
using Negocio.Enum;
using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            modelBuilder.Entity<IoTDeviceModel>().HasDiscriminator(c => c.DeviceType)
                .HasValue<PulseiraModel>(EnumDeviceType.Pulseira)
                .HasValue<CaixaRemedioModel>(EnumDeviceType.CaixaRemedio);            
        }

        public DbSet<AssinaturaModel> Assinaturas { get; set; }
        public DbSet<PlanoModel> Planos { get; set; }
        public DbSet<IoTDeviceModel> IoTDevices { get; set; }
    }
}
