﻿// <auto-generated />
using ListaTarefasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListaTarefasAPI.Migrations
{
    [DbContext(typeof(ListaTarefasContext))]
    partial class ListaTarefasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ListaTarefasAPI.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarefaId"));

                    b.Property<bool>("Concluida")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoTarefaId")
                        .HasColumnType("int");

                    b.HasKey("TarefaId");

                    b.HasIndex("TipoTarefaId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("ListaTarefasAPI.Models.TipoTarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposTarefa");
                });

            modelBuilder.Entity("ListaTarefasAPI.Models.Tarefa", b =>
                {
                    b.HasOne("ListaTarefasAPI.Models.TipoTarefa", "TipoTarefa")
                        .WithMany()
                        .HasForeignKey("TipoTarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTarefa");
                });
#pragma warning restore 612, 618
        }
    }
}
