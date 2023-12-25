﻿// <auto-generated />
using System;
using Hackeru_Student_Teacher.API.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackeru_Student_Teacher.API.Migrations
{
    [DbContext(typeof(DbStudentTeacher))]
    partial class DbStudentTeacherModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hours")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRandomAnswers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Minutes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer4")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChoosenAnswer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GradeTheQuestionEqual")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AvgGrade")
                        .HasColumnType("REAL");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsTeacher")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsTeacher")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Exam", b =>
                {
                    b.HasOne("Hackeru_Student_Teacher.API.Models_API.Student", null)
                        .WithMany("Exams")
                        .HasForeignKey("StudentId");

                    b.HasOne("Hackeru_Student_Teacher.API.Models_API.Teacher", null)
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Question", b =>
                {
                    b.HasOne("Hackeru_Student_Teacher.API.Models_API.Exam", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Student", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Hackeru_Student_Teacher.API.Models_API.Teacher", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
