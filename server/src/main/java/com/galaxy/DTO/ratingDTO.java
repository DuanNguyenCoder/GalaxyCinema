package com.galaxy.DTO;

import java.sql.Date;
import java.time.LocalDate;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import lombok.Data;


//@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"}) 
public interface ratingDTO {
	
	
	int getCustomerID();
	 int getRatingID();
	 String getName();
	 int getRate();
	 LocalDate getRateDate();
	 String getComment();


	

}
