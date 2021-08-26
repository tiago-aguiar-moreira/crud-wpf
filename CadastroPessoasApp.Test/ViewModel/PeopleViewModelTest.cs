using CadastroPessoasApp.Model;
using CadastroPessoasApp.Repository.Interface;
using CadastroPessoasApp.ViewModel;
using ExpectedObjects;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace CadastroPessoasApp.Test.ViewModel
{
    public class PeopleViewModelTest
    {
        private PeopleViewModel _peopleViewModel;
        private Mock<IPeopleRepository> _peopleRepository;

        public PeopleViewModelTest()
        {
            _peopleRepository = new Mock<IPeopleRepository>();
        }

        [Fact(DisplayName = "Should reset data successfully")]
        public void Should_Reset_Data_Successfully()
        {
            //Arrange
            _peopleViewModel = new PeopleViewModel(_peopleRepository.Object);
            _peopleViewModel.PeopleRecord.Id = 15;
            _peopleViewModel.PeopleRecord.Nome = "Tiago";
            _peopleViewModel.PeopleRecord.Sobrenome = "Aguiar";
            _peopleViewModel.PeopleRecord.Cpf = "12345679895";
            _peopleViewModel.PeopleRecord.Nascimento = new DateTime(1991,08,03);
            _peopleViewModel.PeopleRecord.Genero = "Masculino";
            _peopleViewModel.PeopleRecord.Logradouro = "Rua Dez";
            _peopleViewModel.PeopleRecord.Numero = "12";
            _peopleViewModel.PeopleRecord.Cidade = "São Paulo";
            _peopleViewModel.PeopleRecord.Estado = "SP";
            _peopleViewModel.PeopleRecord.Complemento = "Caso 2";
            _peopleViewModel.PeopleRecord.Cep = "02998020";

            var newPeopleRecord = new PeopleRecord()
            {
                Id = 0,
                Nome = string.Empty,
                Sobrenome = string.Empty,
                Cpf = string.Empty,
                Nascimento = DateTime.MinValue,
                Genero = string.Empty,
                Logradouro = string.Empty,
                Numero = string.Empty,
                Cidade = string.Empty,
                Estado = string.Empty,
                Complemento = string.Empty,
                Cep = string.Empty,
                PeopleRecords = new ObservableCollection<PeopleRecord>()
            };

            //Act
            _peopleViewModel.ResetData();

            //Assert
            _peopleViewModel.PeopleRecord.ToExpectedObject().ShouldMatch(newPeopleRecord);
        }

        [Fact(DisplayName = "Should prepare to edit data successfully")]
        public void Should_Prepare_To_Edit_Data_Successfully()
        {
            //Arrange
            var idPeople = 15;

            var currentPeople = new PeopleRecord
            {
                Id = idPeople,
                Nome = "Tiago",
                Sobrenome = "Aguiar",
                Cpf = "12345679895",
                Nascimento = new DateTime(1991, 08, 03),
                Genero = "Masculino",
                Logradouro = "Rua Dez",
                Numero = "12",
                Cidade = "São Paulo",
                Estado = "SP",
                Complemento = "Caso 2",
                Cep = "02998020",
                PeopleRecords = new ObservableCollection<PeopleRecord>()
            };

            _peopleRepository.Setup(s => s.Get(It.IsAny<int>())).Returns(currentPeople);
            _peopleViewModel = new PeopleViewModel(_peopleRepository.Object);

            //Act
            _peopleViewModel.PrepareEditData(idPeople);

            //Assert
            _peopleRepository.Verify(p => p.Get(idPeople), Times.Once);
            _peopleViewModel.PeopleRecord.ToExpectedObject().ShouldMatch(currentPeople);
        }

        [Fact(DisplayName = "Should load all records successfully")]
        public void Should_Load_All_Records_Successfully()
        {
            //Arrange
            var getAllReturns = new List<PeopleRecord>
            {
                new PeopleRecord() { Id = 1 },
                new PeopleRecord() { Id = 2 },
                new PeopleRecord() { Id = 3 }
            };

            var LengthRecords = getAllReturns.Count();

            _peopleRepository.Setup(s => s.GetAll()).Returns(getAllReturns);
            
            //Act
            _peopleViewModel = new PeopleViewModel(_peopleRepository.Object);

            //Asert
            _peopleRepository.Verify(p => p.GetAll(), Times.Once);
            _peopleViewModel.PeopleRecord.PeopleRecords.Should().NotBeEmpty()
                .And.HaveCount(LengthRecords);
        }

        [Fact(DisplayName = "Should save data successfully")]
        public void Should_Save_Data_Successfully()
        {
            //Arrange
            _peopleRepository.Setup(s => s.AddPeople(It.IsAny<PeopleRecord>()));
            _peopleViewModel = new PeopleViewModel(_peopleRepository.Object);

            //Act
            var dataSavedSuccessfully = _peopleViewModel.SaveData(out var message);

            //Asert
            dataSavedSuccessfully.Should().BeTrue();
            message.Should().Be("Registro salvo com sucesso.");
            _peopleRepository.Verify(p => p.AddPeople(It.IsAny<PeopleRecord>()), Times.Once);
        }

        [Fact(DisplayName = "Should update data successfully")]
        public void Should_Update_Data_Successfully()
        {
            //Arrange
            var idPeople = 16;
            var currentPeople = new PeopleRecord
            {
                Id = idPeople,
                Nome = "Tiago",
                Sobrenome = "Aguiar",
                Cpf = "12345679895",
                Nascimento = new DateTime(1991, 08, 03),
                Genero = "Masculino",
                Logradouro = "Rua Dez",
                Numero = "12",
                Cidade = "São Paulo",
                Estado = "SP",
                Complemento = "Caso 2",
                Cep = "02998020",
                PeopleRecords = new ObservableCollection<PeopleRecord>()
            };

            _peopleRepository.Setup(s => s.Get(It.IsAny<int>())).Returns(currentPeople);
            _peopleRepository.Setup(s => s.AddPeople(It.IsAny<PeopleRecord>()));
            _peopleViewModel = new PeopleViewModel(_peopleRepository.Object);

            //Act
            _peopleViewModel.PrepareEditData(idPeople);
            var dataUpdatedSuccessfully = _peopleViewModel.SaveData(out var message);

            //Asert
            dataUpdatedSuccessfully.Should().BeTrue();
            message.Should().Be("Registro alterado com sucesso.");
            _peopleRepository.Verify(p => p.UpdatePeople(It.IsAny<PeopleRecord>()), Times.Once);
        }

        [Fact(DisplayName = "Should removes data successfully")]
        public void Should_Removes_Data_Successfully()
        {
            //Arrange
            var idPeople = 16;

            _peopleViewModel = new PeopleViewModel(_peopleRepository.Object);

            //Act
            var dataRemovesSuccessfully = _peopleViewModel.RemovePeople(idPeople, out var message);

            //Asert
            dataRemovesSuccessfully.Should().BeTrue();
            message.Should().Be("Registro removido com sucesso.");
            _peopleRepository.Verify(p => p.RemovePeople(It.IsAny<int>()), Times.Once);
        }
    }
}