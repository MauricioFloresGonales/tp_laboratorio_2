using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades;

namespace Test
{
    [TestClass]
    public class TesMaterias
    {
        [TestMethod]
        public void TestCantidadDeMateriasIguales()
        {
            // Arrange
            Materia arrange1 = new Materia("TesIingles", ETurno.mañana);
            Materia arrange2 = new Materia("TestMatematica", ETurno.mañana);
            Materia arrange3 = new Materia("TestMatematica", ETurno.tarde);
            Materia arrange4 = new Materia("TestFisica", ETurno.mañana);

            SistemaDeDatos.AgregarMateria(arrange1);
            SistemaDeDatos.AgregarMateria(arrange2);
            SistemaDeDatos.AgregarMateria(arrange3);
            SistemaDeDatos.AgregarMateria(arrange4);
            
            // Act 
            int materiasIgualA = Materia.AnalisisSegunMaterias(SistemaDeDatos.ListaDeMaterias, "TestMatematica");

            // Assert 
            Assert.AreEqual(materiasIgualA, 2);
        }
    }
}
