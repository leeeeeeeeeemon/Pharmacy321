﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
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
    
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Dogovor> Dogovor { get; set; }
        public DbSet<Graphik> Graphik { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Material_Oborudovanie> Material_Oborudovanie { get; set; }
        public DbSet<Ostatok_preparat> Ostatok_preparat { get; set; }
        public DbSet<Postavka> Postavka { get; set; }
        public DbSet<Postavshik> Postavshik { get; set; }
        public DbSet<Preparat> Preparat { get; set; }
        public DbSet<Shopping_history> Shopping_history { get; set; }
        public DbSet<Sklad> Sklad { get; set; }
        public DbSet<Sotrudnik> Sotrudnik { get; set; }
        public DbSet<Zakaz> Zakaz { get; set; }
        public DbSet<Zapis_priem> Zapis_priem { get; set; }
    }
}