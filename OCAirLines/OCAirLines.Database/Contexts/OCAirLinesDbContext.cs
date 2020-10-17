using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OCAirLines.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCAirLines.Database.Contexts
{
    public class OCAirLinesDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraItem> CompraItens { get; set; }
        public DbSet<Favorita> Favoritas { get; set; }
        public DbSet<Pesquisa> Pesquisas { get; set; }
        public DbSet<AppAuthentication> AppAuthentications { get; set; }
        public DbSet<Passagem> Passagens { get; set; }


        public OCAirLinesDbContext(DbContextOptions<OCAirLinesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            #region ~~ Usuario feature ~~
           
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
                i.Property(x => x.Senha).IsRequired();
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
            #endregion

            #region ~~ Cartao ~~
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
           
            #region ~~ Favorita ~~
            modelBuilder.Entity<Favorita>(i =>
            {
                i.ToTable("Favoritas");
                i.HasKey(x => x.Id);

                i.Property(x => x.Empresa).IsRequired();
                i.Property(x => x.Origem).IsRequired();
                i.Property(x => x.Destino).IsRequired();
                i.Property(x => x.Preco).HasColumnType("decimal(16,2)");

                i.HasOne(x => x.Usuario)
                .WithMany(x => x.Favoritas)
                .HasForeignKey(x => x.UsuarioId);
            });
            #endregion
            
            #region ~~ Pesquisa ~~
            modelBuilder.Entity<Pesquisa>(i =>
            {
                i.ToTable("Pesquisas");
                i.HasKey(x => x.Id);

                i.Property(x => x.Empresa).IsRequired();
                i.Property(x => x.Origem).IsRequired();
                i.Property(x => x.Destino).IsRequired();
                i.Property(x => x.Preco).HasColumnType("decimal(16,2)");

                i.HasOne(x => x.Usuario)
                .WithMany(x => x.Pesquisas)
                .HasForeignKey(x => x.UsuarioId);
            });
            #endregion
            
            #endregion
           
            #region ~~ Compra ~~
            modelBuilder.Entity<Compra>(i =>
            {
                i.ToTable("Compras");
                i.HasKey(x => x.Id);

                i.HasOne(x => x.Usuario)
                .WithMany(x => x.Compras)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

                i.HasOne(x => x.Cartao)
                .WithMany(x => x.Compras)
                .HasForeignKey(x => x.CartaoId)
                .OnDelete(DeleteBehavior.NoAction);

                i.HasMany(x => x.Itens)
                .WithOne(x => x.Compra)
                .HasForeignKey(x => x.CompraId);
            });

            modelBuilder.Entity<CompraItem>(i =>
            {
                i.ToTable("CompraItens");
                i.HasKey(x => x.Id);

                i.Property(x => x.Empresa).IsRequired();
                i.Property(x => x.Origem).IsRequired();
                i.Property(x => x.Destino).IsRequired();
                i.Property(x => x.Preco).HasColumnType("decimal(16,2)");

                i.HasOne(x => x.Compra)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.CompraId);
            });
            #endregion

            #region ~~ AppAuthentication ~~
            modelBuilder.Entity<AppAuthentication>(i =>
            {
                i.ToTable("AppAuthentications");
                i.HasKey(x => x.Id);
                i.Property(x => x.HashId).IsRequired();
                i.HasIndex(x => x.Email).IsUnique();
                i.Property(x => x.AppRole).IsRequired();
                i.Property(x => x.Name).IsRequired();
                i.Property(x => x.Password).IsRequired();
            });
            #endregion

            #region ~~ Passagens ~~
            modelBuilder.Entity<Passagem>(i =>
            {
                i.ToTable("Passagens");
                i.HasKey(x => x.Id);
                i.Property(x => x.Companhia).IsRequired();
                i.Property(x => x.LocalOrigem).IsRequired();
                i.Property(x => x.LocalDestino).IsRequired();
                i.Property(x => x.Preco).IsRequired();
                i.Property(x => x.Classificacao).IsRequired();
                i.Property(x => x.TipoCabine).IsRequired();
                i.Property(x => x.DuracaoViagem).IsRequired();
                i.Property(x => x.DataOrigem).IsRequired();
                i.Property(x => x.DataDestino).IsRequired();
            });
            #endregion
        }
    }
}
