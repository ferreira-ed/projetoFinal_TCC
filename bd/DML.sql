Use Chamados

go

Insert into TipoUsuario		(NomeTipoUsuario)
Values						('Suporte'),
							('Manutecao'),
							('Limpeza'),
							('Administrador');
		
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

Insert Into Equipamento (NomeEquipamento,Descicao)
Values					('Switch Cisco 2960', 'Switch de 24 Portas em otimo estado');

go

Insert Into Chamado (IdUsuario,IdInstituicao,Localizacao,Motivo,Descricao,IdReceberChamado)
Values				('C33FCD7E-E822-46AC-B52A-04729E59FF93',1,'3º Andar','Limpeza','Suco no chão, proximo ao bebedouro','E5CB23B7-84D3-4C61-8C17-A187A2772C94');

go