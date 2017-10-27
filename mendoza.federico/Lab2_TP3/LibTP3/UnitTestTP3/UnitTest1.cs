using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using Clases_Instanciables;
using Clases_Abstractas;

namespace UnitTestTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException),"alumno con nacionalidad incorrecta fue permitido ingresar")]
        public void NacInvalidoCatchAlumno()
        {      
            Alumno alumno = new Alumno(1, "juan", "perez", "35413025", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);                               
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException), "profesor con nacionalidad incorrecta fue permitido ingresar")]
        public void NacInvalidoCatchProfesor()
        {            
            Profesor profesor = new Profesor(1, "juan", "perez", "35413025", Persona.ENacionalidad.Extranjero);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException), "longitud de DNI incorrecta deja crear alumno")]
        public void DniInvalidoPorNumeroIncorrecto()
        {
            Alumno alumno = new Alumno(1, "juan", "perez", "354130250", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        [TestMethod]        
        public void atributosNotNull()
        {
            Alumno alumno = new Alumno(1, "juan", "perez", "35413025", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,Alumno.EEstadoCuenta.Becado);           
            if (string.IsNullOrEmpty(alumno.Apellido.ToString()) || string.IsNullOrEmpty(alumno.Nombre.ToString()) || string.IsNullOrEmpty(alumno.Nacionalidad.ToString()) || string.IsNullOrEmpty(alumno.DNI.ToString()))
            {
                Assert.Fail();
            }     
        }

    }
}
