using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class EstudianteRepository
    {
        private readonly SchoolContext _context= new SchoolContext();

        
        public async Task guardarEstudiante(Student student)
        {
                       
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
 
        }


        public async Task consultarEstudiantes()
        {
            Console.WriteLine("Metodo consultar estudiantes");
            List<Student> listEstudiantes = _context.Students.ToList();

            foreach (var item in listEstudiantes)
            {
                Console.WriteLine("Codigo: " + item.StudentId + " Nombre: " + item.Name);
            }

        }

        public async Task consultarEstudiante()
        {
            Console.WriteLine("Metodo consultar estudiante por Id");
            SchoolContext context = new SchoolContext();
            Student std = new Student();
            std = context.Students.Find(11);

            Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

        }

        public async Task modificarEstudiante()
        {
            Console.WriteLine("Metodo modificar estudiante");
            SchoolContext context = new SchoolContext();
            Student std = new Student();
            std = context.Students.Find(1);

            std.Name = "Anahi";
            context.SaveChanges();
            Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

        }

        public async Task eliminarEstudiante()
        {
            Console.WriteLine("Metodo eliminar estudiante");
            SchoolContext context = new SchoolContext();
            Student std = new Student();
            std = context.Students.Find(5);
            context.Remove(std);
            context.SaveChanges();
            Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

        }
        public async Task consultarEstudiantesFunciones()
        {
            Console.WriteLine("Metodo consultar estudiantes con el uso de funciones");
            SchoolContext context = new SchoolContext();
            List<Student> listEstudiantes;

            Console.WriteLine("Cantidad de registros: " + context.Students.Count());
            Student std = context.Students.First();

            Console.WriteLine("Primer elemento de la tabla:" + std.StudentId + "-" + std.Name);

            //listEstudiantes = context.Students.Where(s => s.StudentId > 2 && s.Name == "Anita").ToList();

            //listEstudiantes = context.Students.Where(s => s.Name == "Patty" || s.Name == "Anita").ToList();

            listEstudiantes = context.Students.Where(s => s.Name.StartsWith("A")).ToList();

            foreach (var item in listEstudiantes)
            {
                Console.WriteLine("Codigo: " + item.StudentId + " Nombre: " + item.Name);
            }


            /*
            var query = context.Students.GroupBy( s => s.Name) 
            .Select(g => new
            {
                Nombre = g.Key,
                Cantidad = g.Count()
            }). ToList();

            foreach (var result in query)
            {
                Console.WriteLine($"Nombre: {result.Nombre}, Cantidad: {result.Cantidad}");
            }
            */
        }
    }
}
