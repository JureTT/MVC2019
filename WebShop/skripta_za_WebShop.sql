use WebShop
go

create table MjereProizvoda
(
Id	smallint primary key identity(1,1),
Naziv	nvarchar(10) not null
)
go

create table Proizvodi
(
Id	int primary key identity(1,1),
MjeraProizvodaId smallint foreign key references MjereProizvoda(Id) not null,
VrijemeKreiranja datetime not null,
Naziv	varchar(50) not null,
Cijena decimal(18,2) not null,
Dostupan bit not null
)
go

create table Korisnici
(
Id	int primary key identity(1,1),
Ime nvarchar(50) not null,
Prezime nvarchar(50) not null,
Email varchar(50) not null,
AdresaDostave nvarchar(250) not null,
Kontakt varchar(50) not null,
Napomena nvarchar(max) not null,
)
go

create table Narudzbe
(
Id	int primary key identity(1,1),
KorisnikId int foreign key references Korisnici(Id) not null,
Prezime nvarchar(50) not null,
Email varchar(50) not null,
DatumKreiranja datetime not null,
DatumVrijemeDostave datetime not null,
JeDostavljeno bit not null,
)
go

create table NarudzbeDetalji
(
Id	int primary key identity(1,1),
NarudzbaId int foreign key references Narudzbe(Id) not null,
ProizvodId int foreign key references Proizvodi(Id) not null,
Kolicina decimal (18,2) not null,
JedCijena decimal (18,2) not null,
)
go

create table Kategorije
(
Id	int primary key identity(1,1),
Naziv nvarchar(50) not null,
Opis nvarchar(500) null,
)
go

create table KategorijeProizvodi
(
Id	int primary key identity(1,1),
ProizvodId int foreign key references Proizvodi(Id) not null,
KategorijaId int foreign key references Kategorije(Id) not null,
)
go
