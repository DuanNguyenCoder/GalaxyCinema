package com.galaxy.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.galaxy.entities.Invoice;
import com.galaxy.entities.Rating;

public interface InvoiceRepo extends JpaRepository<Invoice, Long> {

	
	// lay danh sach danh gia cua user
	 @Query(value = "insert invoice(CustomerID,OrderDate,discount,total,TypeofPayment) values (:cusID,:date, '0',:total,'2') "
	 		+ "SELECT SCOPE_IDENTITY() AS invoiceID", nativeQuery = true)
	    List<Invoice> insertInvoice(@Param("cusID") int cusID, @Param("date") String date,  @Param("total") long total );
	 
}
