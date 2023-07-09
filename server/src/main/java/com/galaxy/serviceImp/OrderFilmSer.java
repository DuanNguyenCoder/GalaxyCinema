package com.galaxy.serviceImp;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.galaxy.repositories.OrderFilmRepo;

@Service
public class OrderFilmSer {
	
	@Autowired
	OrderFilmRepo orderFilmRepo;
	
	
	public void addOrderFilm(int idShowTime, String seat, int invoiceID) {
		orderFilmRepo.insertOrderFilmToBill(idShowTime,seat,invoiceID);
	}
	
	public void addOrderProduct(int idPro, int idInvoice,int quantity, String detail) {
		orderFilmRepo.insertOrderProductToBill(idPro,idInvoice,quantity,detail);
	}

}
