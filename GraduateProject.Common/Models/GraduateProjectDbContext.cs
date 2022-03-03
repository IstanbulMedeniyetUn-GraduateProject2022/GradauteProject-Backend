using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GraduateProject.Common.Models
{
    public partial class GraduateProjectDbContext : IdentityDbContext<ApplicationUser>
    {
        public GraduateProjectDbContext()
        {
        }

        public GraduateProjectDbContext(DbContextOptions<GraduateProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorLog> DoctorLogs { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelLog> HotelLogs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MedicalCenter> MedicalCenters { get; set; }
        public virtual DbSet<MedicalCenterLog> MedicalCenterLogs { get; set; }
        public virtual DbSet<PlaceToVisit> PlaceToVisits { get; set; }
        public virtual DbSet<PlaceToVisitLog> PlaceToVisitLogs { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OEAMO4J;Database=GraduateProject;Trusted_Connection=True;");
            }
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.UserFirstName).IsUnicode(false);

                entity.Property(e => e.UserLastName).IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Comments_Doctor_DoctorID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Comments_Hotel_HotelID");

                entity.HasOne(d => d.MedicalCenter)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MedicalCenterId)
                    .HasConstraintName("FK_Comments_MedicalCenter_MedicalCenterID");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK_Comments_PlaceToVisit_PlaceID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);

                entity.Property(e => e.WorkingPlace).IsUnicode(false);

                entity.Property(e => e.WorkingTime).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DoctorLog>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK_DoctorLog_DoctorID");

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.DoctorAddress).IsUnicode(false);

                entity.Property(e => e.DoctorLocation).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MedicalCenterName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);

                entity.Property(e => e.WorkingPlace).IsUnicode(false);

                entity.Property(e => e.WorkingTime).IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DoctorLogs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.LogoPath).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);
            });

            modelBuilder.Entity<HotelLog>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PK_HotelLog_HotelID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.LogoPath).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Language1).IsUnicode(false);

                entity.Property(e => e.LanguageCode).IsUnicode(false);
            });

            modelBuilder.Entity<MedicalCenter>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ClosingTime).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.OpeningTime).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);
            });

            modelBuilder.Entity<MedicalCenterLog>(entity =>
            {
                entity.HasKey(e => e.MedicalCenterId)
                    .HasName("PK_MedicalCenterLog_MedicalCenterID");

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ClosingTime).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.MedicalCenterAddress).IsUnicode(false);

                entity.Property(e => e.MedicalCenterDescription).IsUnicode(false);

                entity.Property(e => e.MedicalCenterLocation).IsUnicode(false);

                entity.Property(e => e.MedicalCenterName).IsUnicode(false);

                entity.Property(e => e.OpeningTime).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);
            });

            modelBuilder.Entity<PlaceToVisit>(entity =>
            {
                entity.HasKey(e => e.PlaceId)
                    .HasName("PK_Place_PlaceID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ClosingTime).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.OpeningTime).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);
            });

            modelBuilder.Entity<PlaceToVisitLog>(entity =>
            {
                entity.HasKey(e => e.PlaceId)
                    .HasName("PK_PlaceLog_PlaceID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ClosingTime).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.OpeningTime).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.WebSiteLink).IsUnicode(false);

                entity.Property(e => e.WhatappNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.UserFirstName).IsUnicode(false);

                entity.Property(e => e.UserLastName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }*/

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
