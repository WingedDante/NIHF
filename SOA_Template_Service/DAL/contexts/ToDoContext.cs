using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CarPartsService.DAL.Models;

namespace CarPartsService.DAL.Contexts
{    
    public class CarPartContext : DbContext
    {
        
        public CarPartContext(){

        }

        public CarPartContext(DbContextOptions<CarPartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarPart> CarParts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=CarPart.db");
            }
        }

    }
}

