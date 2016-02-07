//
//  Conversa.swift
//  AgendaOnline
//
//  Created by João Fabio Lourenço dos Santos on 07/02/16.
//  Copyright © 2016 Agenda Online. All rights reserved.
//

import Foundation

class Conversa: NSObject {
	
	var Id:Int!
	var Tipo:String!
	
	init(Id:Int, Tipo:String) {
		self.Id = Id
		self.Tipo = Tipo
	}
}