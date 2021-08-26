using CadastroPessoasApp.Command;
using CadastroPessoasApp.Model;
using CadastroPessoasApp.Repository.Interface;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CadastroPessoasApp.ViewModel
{
    public class PeopleViewModel
    {
		private ICommand _saveCommand;
		private ICommand _resetCommand;
		private ICommand _editCommand;
		private ICommand _deleteCommand;
		private IPeopleRepository _repository;
		private PeopleRecord _peopleEntity = null;
		public PeopleRecord PeopleRecord { get; set; }

		public ICommand ResetCommand
		{
			get
			{
				if (_resetCommand == null)
					_resetCommand = new RelayCommand(param => ResetData(), null);

				return _resetCommand;
			}
		}

		public ICommand SaveCommand
		{
			get
			{
				if (_saveCommand == null)
					_saveCommand = new RelayCommand(param => SaveData(), null);

				return _saveCommand;
			}
		}

		public ICommand EditCommand
		{
			get
			{
				if (_editCommand == null)
					_editCommand = new RelayCommand(param => EditData((int)param), null);

				return _editCommand;
			}
		}

		public ICommand DeleteCommand
		{
			get
			{
				if (_deleteCommand == null)
					_deleteCommand = new RelayCommand(param => DeleteStudent((int)param), null);

				return _deleteCommand;
			}
		}

		public PeopleViewModel(IPeopleRepository repository)
		{
            _peopleEntity = new PeopleRecord();
            _repository = repository;
			PeopleRecord = new PeopleRecord();
			GetAll();
		}

		public void ResetData()
		{
			PeopleRecord.Id = 0;
			PeopleRecord.Nome = string.Empty;
			PeopleRecord.Sobrenome = string.Empty;
			PeopleRecord.Cpf = string.Empty;
			PeopleRecord.Nascimento = DateTime.Now;
			PeopleRecord.Genero = string.Empty;
			PeopleRecord.Logradouro = string.Empty;
			PeopleRecord.Numero = string.Empty;
			PeopleRecord.Cidade = string.Empty;
			PeopleRecord.Estado = string.Empty;
			PeopleRecord.Complemento = string.Empty;
			PeopleRecord.Cep = string.Empty;
		}

		public void DeleteStudent(int id)
		{
			if (MessageBox.Show("Deseja remover este registro?", "Pessoa", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					_repository.RemovePeople(id);
					MessageBox.Show("Registro removido com sucesso.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ocorreu um erro durante o processamento da sua solicitação. " + ex.InnerException);
				}
				finally
				{
					GetAll();
				}
			}
		}

		public void SaveData()
		{
			if (PeopleRecord != null)
			{
				_peopleEntity.Id = PeopleRecord.Id;
				_peopleEntity.Nome = PeopleRecord.Nome;
				_peopleEntity.Sobrenome = PeopleRecord.Sobrenome;
				_peopleEntity.Cpf = PeopleRecord.Cpf;
				_peopleEntity.Nascimento = PeopleRecord.Nascimento;
				_peopleEntity.Genero = PeopleRecord.Genero;
				_peopleEntity.Logradouro = PeopleRecord.Logradouro;
				_peopleEntity.Numero = PeopleRecord.Numero;
				_peopleEntity.Cidade = PeopleRecord.Cidade;
				_peopleEntity.Estado = PeopleRecord.Estado;
				_peopleEntity.Complemento = PeopleRecord.Complemento;
				_peopleEntity.Cep = PeopleRecord.Cep;

				try
				{
					if (PeopleRecord.Id <= 0)
					{
						_repository.AddPeople(_peopleEntity);
						MessageBox.Show("Registro salvo com sucesso.");
					}
					else
					{
						_peopleEntity.Id = PeopleRecord.Id;
						_repository.UpdatePeople(_peopleEntity);
						MessageBox.Show("Registro alterado com sucesso.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ocorreu um erro durante o processamento da sua solicitação. " + ex.InnerException);
				}
				finally
				{
					GetAll();
					ResetData();
				}
			}
		}

		public void EditData(int id)
		{
			var model = _repository.Get(id);

			PeopleRecord.Id = model.Id;
			PeopleRecord.Nome = model.Nome;
			PeopleRecord.Sobrenome = model.Sobrenome;
			PeopleRecord.Cpf = model.Cpf;
			PeopleRecord.Nascimento = model.Nascimento;
			PeopleRecord.Genero = model.Genero;
			PeopleRecord.Logradouro = model.Logradouro;
			PeopleRecord.Numero = model.Numero;
			PeopleRecord.Cidade = model.Cidade;
			PeopleRecord.Estado = model.Estado;
			PeopleRecord.Complemento = model.Complemento;
			PeopleRecord.Cep = model.Cep;
		}

		public void GetAll()
		{
			PeopleRecord.PeopleRecords = new ObservableCollection<PeopleRecord>();

			var peoples = _repository.GetAll();

            foreach (var data in peoples)
            {
				PeopleRecord.PeopleRecords.Add(new PeopleRecord()
				{
					Id = data.Id,
					Nome = data.Nome,
					Sobrenome = data.Sobrenome,
					Cpf = data.Cpf,
					Nascimento = data.Nascimento,
					Genero = data.Genero,
					Logradouro = data.Logradouro,
					Numero = data.Numero,
					Cidade = data.Cidade,
					Estado = data.Estado,
					Complemento = data.Complemento,
					Cep = data.Cep
				});
			}
		}
	}
}