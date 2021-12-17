Use Chamados;

go

Insert into TipoUsuario		(NomeTipoUsuario)
Values						('Suporte'),
							('Manutecao'),
							('Limpeza'),
							('Administrador'),
							('Comum');
		
go

Insert into Usuario (IdTipoUsuario,EmailUsuario,SenhaUsuario)
Values				(1,'suporte@suporte.com','suporte123'),
					(2,'manutecao@manutecao.com','manutecao123'),
					(3,'limpeza@limpeza.com','limpeza123'),
					(4,'adm@adm.com','adm123');

go

Insert Into Instituicao (NomeInstituicao,CNPJ,CEP,Pais,Estado,Cidade,Bairro,Numero,Endereco,Telefone)
Values					('Senai','03774819000102','01202001','Brasil','São Paulo','São Paulo','Santa Cecilia','539','Alameda Barão de Limeira','00000000000');

go

Insert Into Equipamento (IdInstituicao,Marca,TipoEquipamento,NumeroPatrimonio,Quantidade)
Values					(1,'Dell', 'Notebook', '1', '200');

go

Insert Into Chamado (IdUsuario,IdInstituicao,Data,TipoProblema,TipoServico,Classe,Andar,Sala,Descricao,Situacao,Prioridade)
Values				('F920A5CB-BE19-4631-A855-2FB689461AD5',1,'29/10/2021','Redes','Manutenção','Cabeamento de redes','2º andar','Sala 13','Cabo danificado na sala','Em atendimento', 'Alta Prioridade');

go


Insert into Usuario (IdTipoUsuario,EmailUsuario,SenhaUsuario)
Values				(5,'usuario2@usuario.com','usuario123');


				

Insert into TipoUsuario		(NomeTipoUsuario)
Values						('Comum');
	
SELECT*FROM TipoUsuario

SELECT*FROM Usuario

SELECT*FROM Instituicao

SELECT*FROM Equipamento

SELECT*FROM Chamado


DELETE FROM Chamado
WHERE IdChamado = 3;
