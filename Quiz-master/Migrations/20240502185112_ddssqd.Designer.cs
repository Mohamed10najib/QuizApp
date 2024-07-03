﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz.Data;

#nullable disable

namespace Quiz.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240502185112_ddssqd")]
    partial class ddssqd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quiz.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suggestion1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suggestion2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suggestion3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Quiz.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("NbrQuestion")
                        .HasColumnType("int");

                    b.Property<string>("QuizName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Quiz.Models.Scores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Quiz.Models.StartedQuizStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdStartedQuizTeacher")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("StartedQuizTeacherIdStartedQuizTeacher")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StartedQuizTeacherIdStartedQuizTeacher");

                    b.HasIndex("UserId");

                    b.ToTable("StartedQuizStudents");
                });

            modelBuilder.Entity("Quiz.Models.StartedQuizTeacher", b =>
                {
                    b.Property<int>("IdStartedQuizTeacher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStartedQuizTeacher"));

                    b.Property<string>("CodeQuiz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsStarted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTerminated")
                        .HasColumnType("bit");

                    b.Property<int?>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("IdStartedQuizTeacher");

                    b.HasIndex("QuizId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StartedQuizTeachers");
                });

            modelBuilder.Entity("Quiz.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Quiz.Models.Question", b =>
                {
                    b.HasOne("Quiz.Models.Quiz", "quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quiz");
                });

            modelBuilder.Entity("Quiz.Models.Quiz", b =>
                {
                    b.HasOne("Quiz.Models.User", "user")
                        .WithMany("quizzes")
                        .HasForeignKey("UserId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Quiz.Models.Scores", b =>
                {
                    b.HasOne("Quiz.Models.Quiz", "quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quiz");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Quiz.Models.StartedQuizStudent", b =>
                {
                    b.HasOne("Quiz.Models.StartedQuizTeacher", "StartedQuizTeacher")
                        .WithMany("StartedQuizStudents")
                        .HasForeignKey("StartedQuizTeacherIdStartedQuizTeacher");

                    b.HasOne("Quiz.Models.User", "UserStudent")
                        .WithMany("StartedQuizStudents")
                        .HasForeignKey("UserId");

                    b.Navigation("StartedQuizTeacher");

                    b.Navigation("UserStudent");
                });

            modelBuilder.Entity("Quiz.Models.StartedQuizTeacher", b =>
                {
                    b.HasOne("Quiz.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId");

                    b.HasOne("Quiz.Models.User", "Teacher")
                        .WithMany("StartedQuizTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Quiz.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Quiz.Models.StartedQuizTeacher", b =>
                {
                    b.Navigation("StartedQuizStudents");
                });

            modelBuilder.Entity("Quiz.Models.User", b =>
                {
                    b.Navigation("StartedQuizStudents");

                    b.Navigation("StartedQuizTeachers");

                    b.Navigation("quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
