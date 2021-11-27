using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.Xml;
using StarNewHotalApi.Model;

namespace StarNewHotalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("star_new_hotel");
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<FormaPagamento>().HasKey(c => c.IdFormaPagamento);
            modelBuilder.Entity<Quarto>().HasKey(c => c.IdQuarto);
            modelBuilder.Entity<Refeicao>().HasKey(c => c.IdRefeicao);
            modelBuilder.Entity<Reserva>().HasKey(c => c.IdReserva);
            modelBuilder.Entity<Resumo>().HasNoKey().ToView("resumo");
        }

        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Refeicao> Refeicao { get; set; }
        public DbSet<Quarto> Quarto { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Resumo> Resumos { get; set; }
    }
}
