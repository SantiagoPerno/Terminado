﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tesis.Models;

#nullable disable

namespace Tesis.Migrations
{
    [DbContext(typeof(DbtesisContext))]
    [Migration("20250306171038_ActClaseAsistenciaCascade")]
    partial class ActClaseAsistenciaCascade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tesis.Models.Asistencias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AusenteInjustificado")
                        .HasColumnType("bit");

                    b.Property<bool>("AusenteJustificado")
                        .HasColumnType("bit");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int>("FaltasConsecutivas")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Presente")
                        .HasColumnType("bit");

                    b.Property<bool>("TardanzaMedia")
                        .HasColumnType("bit");

                    b.Property<bool>("TardanzaUncuarto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("Tesis.Models.Cursos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Tesis.Models.Estudiantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Antitetanica")
                        .HasColumnType("datetime2");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupoSanguineo")
                        .HasColumnType("int");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoTutor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Tesis.Models.Asistencias", b =>
                {
                    b.HasOne("Tesis.Models.Cursos", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesis.Models.Estudiantes", "Estudiante")
                        .WithMany("Asistencias")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("Tesis.Models.Estudiantes", b =>
                {
                    b.HasOne("Tesis.Models.Cursos", "Curso")
                        .WithMany("Estudiantes")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Tesis.Models.Cursos", b =>
                {
                    b.Navigation("Estudiantes");
                });

            modelBuilder.Entity("Tesis.Models.Estudiantes", b =>
                {
                    b.Navigation("Asistencias");
                });
#pragma warning restore 612, 618
        }
    }
}
