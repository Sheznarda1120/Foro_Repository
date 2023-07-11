using ConsoleApp1.Models;
using ConsoleApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

class Program
{
    static async Task Main(string[] args)
    {
        ////ESTUDIANTES 
        //await guardarEstudianteAsync();
        //await consultarEstudiantesAsync();
        //await consultarEstudiante();
        //await modificarEstudiante();
        //await eliminarEstudiante();
        
        ////DIRECCION
        //await guardarEstudianteYdireccion();
        //await consultarDirecciones();
        //await consultarDireccion();
        
        ////CURSO 
        //await guardarCurso();
        //await guardarEstudianteCurso();
        //await consultarAlumnosyCursos();
    }

    private static async Task consultarAlumnosyCursos()
    {
        CursoRepository cursoRepository = new CursoRepository();
        await cursoRepository.consultarAlumnosyCursos();

    }

    private static async Task guardarEstudianteCurso()
    {
        CursoRepository cursoRepository = new CursoRepository();
        await cursoRepository.guardarEstudianteCurso();

    }

    private static async Task guardarCurso()
    {
        CursoRepository cursoRepository = new CursoRepository();
        await cursoRepository.guardarCurso();

    }

    private static async Task consultarDireccion()
    {
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.consultarDireccion();

    }

    private static async Task consultarDirecciones()
    {
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.consultarDirecciones();
    }

    private static async Task guardarEstudianteYdireccion()
    {
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.guardarEstudianteYdireccion();
    }

    public static async Task guardarEstudianteAsync()
    {

        Console.WriteLine("Guardar Estudiantes desde la clase Repository");

        EstudianteRepository estudianteRepository = new EstudianteRepository();
        Student std = new Student();
        std.Name = "Lola";
        std.LastName = "Perez";
        await estudianteRepository.guardarEstudiante(std);
    }

    public static async Task consultarEstudiantesAsync()
    {
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.consultarEstudiantes();
    }

    public static async Task consultarEstudiante()
    {
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.consultarEstudiante();
    }

    public static async Task eliminarEstudiante()
    {
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.eliminarEstudiante();
    }
    public static async Task modificarEstudiante()
    {
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.modificarEstudiante();
    }


}
