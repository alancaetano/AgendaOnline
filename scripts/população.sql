use agendaonlinedb
go

insert into usuario (id, nome, email, senha, tipo)
values ('861DB49F-8BA5-4EE6-B1A3-6912539812ED','Professor Fulano', 'professor@email.com', '123', 'P'),
	   ('842677E0-76CD-4551-A4FA-A4DF61B3F907','João da Silva', 'joaodasilva@email.com', '123', 'R'),
	   ('38CE9155-DE44-4840-85F7-99BA3CE39CE0','Pedro Souza', 'pedrosouza@email.com', '123', 'R')

insert into aluno (id, nome, id_usuario_responsavel)
values ('13AD5D40-BB7F-42BC-A29F-AAE4455A7F52', 'Juquinha da Silva', '842677E0-76CD-4551-A4FA-A4DF61B3F907'),
	   ('B5C486CA-9537-4D34-BDC7-8FFFED0DCC2C', 'Luizinho Souza', '38CE9155-DE44-4840-85F7-99BA3CE39CE0')

insert into conversa (id, tipo)
values ('770C15AA-4962-4F19-9580-CD61C1A8E34E', 'C')

insert into usuario_conversa (id_conversa, id_usuario)
values ('770C15AA-4962-4F19-9580-CD61C1A8E34E','861DB49F-8BA5-4EE6-B1A3-6912539812ED'),
	   ('770C15AA-4962-4F19-9580-CD61C1A8E34E','842677E0-76CD-4551-A4FA-A4DF61B3F907')

insert into mensagem (id, id_conversa, id_usuario, texto, dt_envio)
values ('E3AF6C4A-C469-49ED-A93C-8F26E869829C', '770C15AA-4962-4F19-9580-CD61C1A8E34E', '861DB49F-8BA5-4EE6-B1A3-6912539812ED', 'Mensagem do professor', getdate() - 2),
	   ('063412FF-BDE5-4CB4-A3E9-2981DA828D65', '770C15AA-4962-4F19-9580-CD61C1A8E34E', '842677E0-76CD-4551-A4FA-A4DF61B3F907', 'Mensagem do responsável', getdate() - 1),
	   ('3CD119B0-35CE-442F-8AF9-51E80C820BE2', '770C15AA-4962-4F19-9580-CD61C1A8E34E', '842677E0-76CD-4551-A4FA-A4DF61B3F907', 'Mensagem do responsável mensagem comprida pra caramba para testar como o balãozinho estica e faz a quebra de linha  ', getdate())
	   
	   
	   select getdate()
	   select NEWID()

/*
delete from mensagem
delete from usuario_conversa
delete from conversa
delete from aluno
delete from usuario

*/