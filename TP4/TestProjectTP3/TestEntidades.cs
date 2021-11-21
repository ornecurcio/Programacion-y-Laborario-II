using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; 
namespace TestProjectTP3
{
    [TestClass]
    public class TestEntidades
    {
        [TestMethod]
        public void VerificarIgualdadPacientes_Ok()
        {
            //Arrange
            Paciente p1 = new Paciente("Martin", "Redrado", 14234678,42, new List<EPatologia>()); 
            Paciente p2 = new Paciente("Martin", "Redrado", 14234678,42, new List<EPatologia>());

            //Act
            bool rta = p1 == p2;

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void VerificarIgualdadPacientes_Falla()
        {
            //Arrange
            Paciente p1 = new Paciente("Martin", "Redrado", 14234678,42, new List<EPatologia>());
            Paciente p2 = new Paciente("Martin", "Martinez", 13234678,42, new List<EPatologia>());

            //Act
            bool rta = p1 == p2;

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void VerificarIgualdadPacientesNulos()
        {
            //Arrange
            Paciente p1 = null;
            Paciente p2 = null;

            //Act
            bool rta = p1 == p2;

            //Assert
            Assert.IsTrue(rta);
        }
        [TestMethod]
        public void VerificarIgualdadCirujanos_Ok()
        {
            //Arrange
            Cirujano c1 = new Cirujano("Ornela", "Curcio", 34707599,31, ERol.Cirujano);
            Cirujano c2 = new Cirujano("Ornela", "Curcio", 34707599,31, ERol.Cirujano);

            //Act
            bool rta = c1 == c2;

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void VerificarIgualdadCirujanos_Falla()
        {
            //Arrange
            Cirujano c1 = new Cirujano("Ornela", "Curcio", 34707599,31, ERol.Cirujano);
            Cirujano c2 = new Cirujano("Ornela", "Curcio", 34707599,31, ERol.Ayudante);

            //Act
            bool rta = c1 == c2;

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void VerificarIgualdadCirujanosNulos()
        {
            //Arrange
            Paciente c1 = null;
            Paciente c2 = null;

            //Act
            bool rta = c1 == c2;

            //Assert
            Assert.IsTrue(rta);
        }
        [TestMethod]
        public void ValidarInstanciaCirugia()
        {
            //Arrange
            Cirugia c = new Cirugia(new Paciente("Martin", "Redrado", 14234678,42, new List<EPatologia>()),
                                    System.DateTime.Now,
                                    new Cirujano("Ornela", "Curcio", 34707599,31, ERol.Cirujano),
                                    EPatologia.Columna, EProcedimiento.Artrodecis);

            //Act
            
            //Assert
            Assert.IsNotNull(c);
        }
        [TestMethod]
        [ExpectedException(typeof(SerializacionException))]
        public void ValidarExcepcion()
        {
            //Arrange
            string ruta = null;
            object algo = null;
            //Act
            SerializacionAJason.SerializarAJason(ruta, algo); 

            //Assert
        }
        [TestMethod]
        public void ValidarMetodoCargarCirujano_NodebeAgregarlo()
        {
            //Arrange
            Cirujano c1 = new Cirujano("Ornela", "Curcio", 34707599,31, ERol.Cirujano);

            //Act
            bool rta = Hospital.CargarCirujanos(c1);

            //Assert
            Assert.IsFalse(rta);
        }
        //[TestMethod]
        //public void ValidarMetodoActualizarPaciente_DebeDarFalse()
        //{
        //    //Arrange
        //    Paciente p1 = new Paciente("Martin", "Redrado", 14234678,42, new List<EPatologia>());

        //    //Act
        //    bool rta = Hospital.ActualizarPacientePatologia(p1); 

        //    //Assert
        //    Assert.IsFalse(rta);
        //}
        [TestMethod]
        public void ValidarConexionBaseDatos_DebeDarTrue()
        {
            //Arrange
            AccesoDatos datos = new AccesoDatos(); 

            //Act
            bool rta = datos.ProbarConexion();

            //Assert
            Assert.IsTrue(rta);
        }
    }
}

