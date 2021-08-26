## Script SQL to initialize database

```sql
create database PlayStore
GO

use PlayStore
GO

create table Pessoa
(
    id int primary key identity,
    nome VARCHAR(30) NOT NULL,
    sobrenome VARCHAR(30) NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    Nascimento DATE NOT NULL,
    Genero VARCHAR(50),
    Logradouro VARCHAR(100) NOT NULL,
    Numero VARCHAR(5) NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Estado VARCHAR(2) NOT NULL,
    Complemento VARCHAR(100),
    CEP VARCHAR(8) NOT NULL
)
```