using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIQLSV.Models;

public partial class StudentManagementContext : DbContext
{
    public StudentManagementContext()
    {
    }

    public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<StuCour> StuCours { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-TGUQGH9P\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__classes__3214EC2704AD966A");

            entity.ToTable("classes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdDepart).HasColumnName("id_depart");
            entity.Property(e => e.NameClass)
                .HasMaxLength(50)
                .HasColumnName("name_class");

            entity.HasOne(d => d.IdDepartNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdDepart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_department");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC278D3197BD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CoursesName)
                .HasMaxLength(50)
                .HasColumnName("courses_name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3214EC27300D0604");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameDepart)
                .HasMaxLength(50)
                .HasColumnName("name_depart");
        });

        modelBuilder.Entity<StuCour>(entity =>
        {
            entity.HasKey(e => new { e.IdStudent, e.IdCourses, e.Number }).HasName("PK__stu_cour__09C75BF2DA47F973");

            entity.ToTable("stu_cour");

            entity.Property(e => e.IdStudent).HasColumnName("id_student");
            entity.Property(e => e.IdCourses).HasColumnName("id_courses");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PointProcess).HasColumnName("point_process");
            entity.Property(e => e.PointTest).HasColumnName("point_test");

            entity.HasOne(d => d.IdCoursesNavigation).WithMany(p => p.StuCours)
                .HasForeignKey(d => d.IdCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stu_cour__id_cou__5BE2A6F2");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.StuCours)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stu_cour__id_stu__5AEE82B9");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3214EC2798BA6E3A");

            entity.ToTable("students");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.IdClasses).HasColumnName("id_classes");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .HasColumnName("student_name");
            entity.Property(e => e.Town)
                .HasMaxLength(50)
                .HasColumnName("town");

            entity.HasOne(d => d.IdClassesNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_classes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
