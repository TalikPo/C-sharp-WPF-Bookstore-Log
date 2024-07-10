using DAL.DALModels;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.DALContext
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("name=BookStoreContext") { }
        public DbSet<DALAuthorModel> Authors { get; set; }
        public DbSet<DALPublishmentModel> Publishments { get; set; }
        public DbSet<DALUserModel> Users { get; set; }
        public DbSet<DALBookModel> Books { get; set; }
    }
}