package com.galaxy.serviceImp;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.galaxy.entities.Invoice;
import com.galaxy.repositories.InvoiceRepo;

@Service
public class InvoiceSer {
	
	@Autowired
	InvoiceRepo invoiceRepo;
	
	
	public List<Invoice> insertInvoice(int cusID,String date, long total) {
	return	invoiceRepo.insertInvoice( cusID,date,total);
	}
	

}
