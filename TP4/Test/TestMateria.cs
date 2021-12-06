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
            Materia arrange1 = new Materia("ingles", ETurno.mañana);
            Materia arrange2 = new Materia("matematica", ETurno.mañana);
            Materia arrange3 = new Materia("matematica", ETurno.tarde);
            Materia arrange4 = new Materia("fisica", ETurno.mañana);
            List <Materia> testLista = new List<Materia>();

            testLista += arrange1;
            testLista += arrange2;
            testLista += arrange3;
            testLista += arrange4;


            // Act 
            int cantidadInicial = testLista.Count;
            int materiasIgualA = Materia.AnalisisSegunMaterias(testLista, "matematica");

            // Assert 
            Assert.AreEqual(materiasIgualA, 2);
        }
    }
}
