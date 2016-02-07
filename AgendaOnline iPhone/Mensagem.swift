//
//  Mensagem.swift
//  AgendaOnline
//
//  Created by João Fabio Lourenço dos Santos on 07/02/16.
//  Copyright © 2016 Agenda Online. All rights reserved.
//

import Foundation

class Mensagem {
	
	var Id:Int!
	var IdUsuario:Int!
	var IdConversa:Int!
	var Texto:String!
	var DtEnvio:datum!
	
	init (Id:Int, IdUsuario:Int, IdConversa:Int, Texto:String, DtEnvio:datum){
		self.Id = Id
		self.IdUsuario = IdUsuario
		self.IdConversa = IdConversa
		self.Texto = Texto
		self.DtEnvio = DtEnvio
	}
}