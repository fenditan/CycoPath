using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycoPath.Models;
using System.Data.Entity;

namespace CycoPath.DAL
{
    public class CycoPathContext : DbContext
    {
        public CycoPathContext() : base("CycoPathDB")
        {

        }
        public DbSet<Park> Park { get; set; }
        public DbSet<Path> Path { get; set; }
    }
}