﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursoMVC5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDPasajeEntities : DbContext
    {
        public BDPasajeEntities()
            : base("name=BDPasajeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asiento> Asiento { get; set; }
        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DETALLEVENTA> DETALLEVENTA { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Lugar> Lugar { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolPagina> RolPagina { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoBus> TipoBus { get; set; }
        public virtual DbSet<TipoContrato> TipoContrato { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<TIPOUSUARIOREGISTRO> TIPOUSUARIOREGISTRO { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VENTA> VENTA { get; set; }
        public virtual DbSet<Viaje> Viaje { get; set; }
    }
}
