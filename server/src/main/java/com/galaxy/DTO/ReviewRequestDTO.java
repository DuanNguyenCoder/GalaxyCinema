package com.galaxy.DTO;

import java.time.LocalDate;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class ReviewRequestDTO {
	
	int filmID;
	int customerID;
	LocalDate rateDate; 
	int rate;
	String comment;

}
