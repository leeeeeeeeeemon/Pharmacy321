﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PharmacyEntities : DbContext
    {
        public PharmacyEntities()
            : base("name=PharmacyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Dogovor> Dogovor { get; set; }
        public virtual DbSet<Graphik> Graphik { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Material_Oborudovanie> Material_Oborudovanie { get; set; }
        public virtual DbSet<Ostatok_preparat> Ostatok_preparat { get; set; }
        public virtual DbSet<Postavka> Postavka { get; set; }
        public virtual DbSet<Postavshik> Postavshik { get; set; }
        public virtual DbSet<Preparat> Preparat { get; set; }
        public virtual DbSet<Shopping_history> Shopping_history { get; set; }
        public virtual DbSet<Sklad> Sklad { get; set; }
        public virtual DbSet<Sotrudnik> Sotrudnik { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
        public virtual DbSet<Zapis_priem> Zapis_priem { get; set; }
    }
}