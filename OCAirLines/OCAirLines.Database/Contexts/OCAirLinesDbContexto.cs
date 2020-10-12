using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCAirLines.Database.Contexts
{
    public class OCAirLinesDbContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraItem> CompraItens { get; set; }
        public DbSet<Favorita> Favoritas { get; set; }
        public DbSet<Pesquisa> Pesquisas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));

            string connection = jAppSettings["ConnectionStrings"]["ConexaoPadrao"].ToString();
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ~~ Usuario ~~
            modelBuilder.Entity<Usuario>(i =>
            {
                i.ToTable("Usuarios");
                i.HasKey(x => x.Id);

                i.HasIndex(x => x.Email).IsUnique();

                i.Property(x => x.Nome).IsRequired();
                i.Property(x => x.Sobrenome).IsRequired();
                i.Property(x => x.TpIdentificacao).IsRequired();
                i.Property(x => x.NrIdentificacao).IsRequired();
                i.Property(x => x.Email).IsRequired();
                i.Property(x => x.Telefone1).IsRequired();

                i.HasMany(x => x.Cartoes)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);

                i.HasMany(x => x.Compras)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);

                i.HasMany(x => x.Favoritas)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);

                i.HasMany(x => x.Pesquisas)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
            });

            modelBuilder.Entity<Cartao>(i =>
            {
                i.ToTable("Cartoes");
                i.HasKey(x => x.Id);

                i.Property(x => x.Bandeira).IsRequired();
                i.Property(x => x.Numero).IsRequired();
                i.Property(x => x.CodSeguranca).IsRequired();
                i.Property(x => x.Vencimento).IsRequired();

                i.HasOne(x => x.Usuario)
                .WithMany(x => x.Cartoes)
                .HasForeignKey(x => x.UsuarioId);

                i.HasMany(x => x.Compras)
                .WithOne(x => x.Cartao)
                .HasForeignKey(x => x.CartaoId);
            });
            #endregion
        }
    }
}
