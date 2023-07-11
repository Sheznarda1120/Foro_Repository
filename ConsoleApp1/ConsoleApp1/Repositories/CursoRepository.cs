using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class CursoRepository
    {
        private readonly SchoolContext _context = new SchoolContext();

        public async Task guardarCurso()
        {
            Console.WriteLine("Guardar Curso");
            Course course = new Course();

            course.CourseName = "Tercero";
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        public async Task guardarEstudianteCurso()
        {
            Console.WriteLine("Guardar EstudianteCurso");
            StudentCourse stdCourse = new StudentCourse();
            /*
            Student std = new Student();
            std = context.Students.Find(1);

            Course course = new Course();
            course = context.Courses.Find(1);
            */
            stdCourse.CourseId = 3;//course.CourseId;
            stdCourse.StudentId = 3; //std.StudentId;
            /*
            stdCourse.Student = std;
            stdCourse.Course = course;
            */
            _context.StudentCourses.Add(stdCourse);
            await _context.SaveChangesAsync();
        }



        public async Task consultarAlumnosyCursos2()
        {
            Console.WriteLine("Consultar un Alumno y sus cursos");

            Student std = new Student();
            std = _context.Students
                .Single(x => x.StudentId == 3);

            _context.Entry(std)
                .Reference(x => x.StudentAddress)
                .Load();

            _context.Entry(std)
              .Collection(x => x.StudentCourse)
              .Load();

            for (int i = 0; i < 3; i++)
            {
                _context.Entry(std.StudentCourse[i])
                  .Reference(x => x.Course)
                  .Load();
            }


            Console.WriteLine("Cursos del estudiante " + std.StudentId + " " + std.Name);

            foreach (var item in std.StudentCourse)
            {
                Console.WriteLine("Curso: " + item.CourseId + " " + item.Course.CourseName);
            }


        }
        public async Task consultarAlumnosyCursos()
        {
            Console.WriteLine("Consultar un Alumnos y sus cursos con Include");

            List<StudentCourse> std;
            std = _context.StudentCourses
                .Where(x => x.StudentId == 3)
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToList();


            Console.WriteLine("Cursos del estudiante " + std[0].StudentId + " " + std[0].Student.Name);

            foreach (var item in std)
            {
                Console.WriteLine("Curso: " + item.CourseId + " " + item.Course.CourseName);
            }


        }
    }
}
