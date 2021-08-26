using CadastroPessoasApp.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CadastroPessoasApp.Model
{
    public class PeopleRecord : ViewModelBase
    {
		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		private string _nome;
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				_nome = value;
				OnPropertyChanged(nameof(Nome));
			}
		}

		private string _sobrenome;
		public string Sobrenome
		{
			get
			{
				return _sobrenome;
			}
			set
			{
				_sobrenome = value;
				OnPropertyChanged(nameof(Sobrenome));
			}
		}

		private string _cpf;
		public string Cpf
		{
			get
			{
				return _cpf;
			}
			set
			{
				_cpf = value;
				OnPropertyChanged(nameof(Cpf));
			}
		}

		private DateTime _nascimento;
		public DateTime Nascimento
		{
			get
			{
				return _nascimento;
			}
			set
			{
				_nascimento = value;
				OnPropertyChanged(nameof(Nascimento));
			}
		}

		private string _genero;
		public string Genero
		{
			get
			{
				return _genero;
			}
			set
			{
				_genero = value;
				OnPropertyChanged(nameof(Genero));
			}
		}

		private string _logradouro;
		public string Logradouro
		{
			get
			{
				return _logradouro;
			}
			set
			{
				_logradouro = value;
				OnPropertyChanged(nameof(Logradouro));
			}
		}

		private string _numbero;
		public string Numero
		{
			get
			{
				return _numbero;
			}
			set
			{
				_numbero = value;
				OnPropertyChanged(nameof(Numero));
			}
		}

		private string _cidade;
		public string Cidade
		{
			get
			{
				return _cidade;
			}
			set
			{
				_cidade = value;
				OnPropertyChanged(nameof(Cidade));
			}
		}

		private string _estado;
		public string Estado
		{
			get
			{
				return _estado;
			}
			set
			{
				_estado = value;
				OnPropertyChanged(nameof(Estado));
			}
		}

		private string _complemento;
		public string Complemento
		{
			get
			{
				return _complemento;
			}
			set
			{
				_complemento = value;
				OnPropertyChanged(nameof(Complemento));
			}
		}

		private string _cep;
		public string Cep
		{
			get
			{
				return _cep;
			}
			set
			{
				_cep = value;
				OnPropertyChanged(nameof(Cep));
			}
		}

		private ObservableCollection<PeopleRecord> _peopleRecords;
		public ObservableCollection<PeopleRecord> PeopleRecords
		{
			get
			{
				return _peopleRecords;
			}
			set
			{
				_peopleRecords = value;
				OnPropertyChanged(nameof(PeopleRecords));
			}
		}

		private void PeopleModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged(nameof(PeopleRecords));
		}
	}
}
