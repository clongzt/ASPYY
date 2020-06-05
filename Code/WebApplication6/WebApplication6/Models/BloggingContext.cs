using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=testEntities")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<user> Users { get; set; }

        public virtual DbSet<MemCard> MemCards { get; set; }

        public virtual DbSet<MemcardSale> MemcardSales { get; set; }

        public virtual DbSet<ScoreOnline> ScoreOnlines { get; set; }

        public virtual DbSet<GoodsStorage> GoodsStorages { get; set; }

        public virtual DbSet<PrescriptionInfo> prescriptionInfo { get; set; }

        public virtual DbSet<PrescriptionDetail> prescriptionDetail { get; set; }

        public virtual DbSet<OrderInfo> OrderInfos { get; set; }

        public virtual DbSet<DeliveryInfo> DeliveryInfos { get; set; }

        public virtual DbSet<InvoiceInfo> InvoiceInfos { get; set; }

        public virtual DbSet<PrescriptionState> PrescriptionStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}