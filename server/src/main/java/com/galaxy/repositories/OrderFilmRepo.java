package com.galaxy.repositories;

import java.time.LocalDate;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import com.galaxy.entities.orderFilm;

public interface OrderFilmRepo extends JpaRepository<orderFilm, Integer> {

	
	
	/// them suat chieu
	 @Modifying
	 @Transactional
	 @Query(value = "insert orderFilm(ShowTimeID,seat,ticketType,invoiceID) values(:showTimeID,:seat,'Gstar',:invoiceID)", nativeQuery = true)
	 void insertOrderFilmToBill( @Param("showTimeID") int showTimeID,  @Param("seat") String seat,@Param("invoiceID") int invoiceID);
	
	
	
	 
	 //// them  san pham vao bill
    @Modifying
    @Transactional
    @Query(value = "EXEC InsertAndUpdateQuantity @idPro = :idPro, @idInvoice = :idInvoice,  @quantity = :quantity,  @details = :details", nativeQuery = true)
    void insertOrderProductToBill(@Param("idPro") int idPro,  @Param("idInvoice") int idInvoice,@Param("quantity") int quantity,@Param("details") String details);
    
	
	
}
