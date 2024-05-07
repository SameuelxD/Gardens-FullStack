﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data;

public partial class GardensContext : DbContext
{
    public GardensContext() { }

    public GardensContext(DbContextOptions<GardensContext> options)
        : base(options) { }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<GamaProducto> GamaProductos { get; set; }

    public virtual DbSet<Oficina> Oficinas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<Rol> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRol> UsersRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        /*modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");*/

        /* OnModelCreatingPartial(modelBuilder); */
    }

    /*partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
}
