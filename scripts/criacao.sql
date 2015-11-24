create database agendaonlinedb
go
use agendaonlinedb
go
create table usuario(
id uniqueidentifier primary key,
nome varchar(50),
email varchar(50),
senha varchar(50),
tipo char(1) -- R = responsável e P = professor
)

create table aluno(
id uniqueidentifier primary key,
nome varchar(50),
id_usuario_responsavel uniqueidentifier FOREIGN KEY REFERENCES usuario(id)
)

create table conversa(
id uniqueidentifier primary key,
tipo char(1) -- A = aviso e C = conversa
)

create table usuario_conversa(
id_usuario uniqueidentifier FOREIGN KEY REFERENCES usuario(id),
id_conversa uniqueidentifier FOREIGN KEY REFERENCES conversa(id),
PRIMARY KEY (id_usuario, id_conversa)
)

create table mensagem(
id uniqueidentifier primary key,
id_usuario uniqueidentifier FOREIGN KEY REFERENCES usuario(id),
id_conversa uniqueidentifier FOREIGN KEY REFERENCES conversa(id),
texto varchar(200),
dt_envio datetime
)
