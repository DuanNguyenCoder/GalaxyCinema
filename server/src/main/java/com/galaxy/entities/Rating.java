package com.galaxy.entities;

import java.sql.Date;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "Rating")
@Data
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"}) 
public class Rating {

	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "RatingID")
	private int RatingID;
	    
		
	   @ManyToOne(fetch = FetchType.LAZY)
	    @JoinColumn(name = "FilmID")
	    private Film FilmID;
	    

		@ManyToOne(fetch = FetchType.LAZY)
	    @JoinColumn(name = "CustomerID")
		
	    private Customer CustomerID;
	    
	    private int Rate;
	    
	    @Column(name = "RateDate")
	    private Date RateDate;
	    
	    private String comment;
	    

}
