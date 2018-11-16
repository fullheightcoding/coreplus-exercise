using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadJsonForPractitionerReturnsList()
        {
            //Arrange
            FileReader fileReader = new FileReader();
            List<Practitioner> practitioners = new List<Practitioner>();

            //Act
            practitioners = fileReader.LoadJsonForPractitioner();

            //Assert
            Assert.IsTrue(practitioners.Count > 0);
        }

        [TestMethod]
        public void LoadJsonForAppointmentReturnsList()
        {
            //Arrange
            FileReader fileReader = new FileReader();
            List<Appointment> appointments = new List<Appointment>();

            //Act
            appointments = fileReader.LoadJsonForAppointment();

            //Assert
            Assert.IsTrue(appointments.Count > 0);
        }

        [TestMethod]
        public void PractitionerRepoGetAllReturnsCorrectCount()
        {
            //Arrange
            PractitionerRepository repository = new PractitionerRepository();

            //Act
            var practitioners = repository.GetAll();

            //Assert
            Assert.IsTrue(practitioners.Count == 10);
        }

        [TestMethod]
        public void PractitionerRepoGetByIdOneReturnsValueVandaKirman()
        {
            //Arrange
            PractitionerRepository repository = new PractitionerRepository();
            var id = 1;

            //Act
            var practitioner = repository.GetById(id);

            //Assert
            Assert.IsTrue(practitioner.Name == "Vanda Kirman");
        }

        [TestMethod]
        public void PractitionerRepoGetByIdTenReturnsValueJacinthePhippard()
        {
            //Arrange
            PractitionerRepository repository = new PractitionerRepository();
            var id = 10;

            //Act
            var practitioner = repository.GetById(id);

            //Assert
            Assert.IsTrue(practitioner.Name == "Jacinthe Phippard");
        }

        [TestMethod]
        public void AppointmentRepoGetByIdOneReturnsClientNameMorieSimner()
        {
            //Arrange
            AppointmentRepository repository = new AppointmentRepository();
            var id = 1;

            //Act
            var appointment = repository.GetById(id);

            //Assert
            Assert.IsTrue(appointment.client_name == "Morie Simner");
        }

        [TestMethod]
        public void AppointmentRepoGetByIdOneThousandReturnsClientNameBriggsPharo()
        {
            //Arrange
            AppointmentRepository repository = new AppointmentRepository();
            var id = 1000;

            //Act
            var appointment = repository.GetById(id);

            //Assert
            Assert.IsTrue(appointment.client_name == "Briggs Pharo");
        }

        [TestMethod]
        public void AppointmentRepoGetByIdPractitionerThreeReturnsSomeValues()
        {
            //Arrange
            AppointmentRepository repository = new AppointmentRepository();
            var id = 3;
            var start = new DateTime(2018, 11, 1);
            var end = new DateTime(2018, 11, 30);

            //Act
            //var appointments = repository.GetByPractitionerIdAndDateRange(id, start, end);

            //Assert
            //Assert.IsTrue(appointments.Count > 0);
        }

    }
}
