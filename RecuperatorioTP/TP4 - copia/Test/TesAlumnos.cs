using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades;

namespace Test
{
    [TestClass]
    public class TesAlumnos
    {
        [TestMethod]
        public void TestCrearUsuario()
        {
            // Arrange
            List<Alumnos> testLista = new List<Alumnos>() { new Alumnos("test1", 11, "femenino") };
            int cantidadInicial = testLista.Count;
            Alumnos nuevoAlumno = new Alumnos("test2", 21, "masculino");

            // Act 
            testLista += nuevoAlumno;

            // Assert 
            Assert.AreNotEqual(cantidadInicial, testLista.Count);
        }
    }
}
