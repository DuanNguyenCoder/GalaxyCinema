package com.galaxy.entities;

import java.sql.Date;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;

@Entity
@Table(name = "Rating")
public class test {

	    
	  
	    private int FilmID;
	    

		
	    private int CustomerID;
	    
	    private int Rate;
	    
	    private Date RateDate;
	    @Id
	    @GeneratedValue(strategy = GenerationType.IDENTITY)
	    private int RatingID;
	    
	    public test(int ratingID, int filmID, int customerID, int rate, Date rateDate) {
	    	super();
	    	RatingID = ratingID;
	    	FilmID = filmID;
	    	CustomerID = customerID;
	    	Rate = rate;
	    	RateDate = rateDate;
	    }
	    public int getRatingID() {
			return RatingID;
		}

		public void setRatingID(int ratingID) {
			RatingID = ratingID;
		}

		public int getFilmID() {
			return FilmID;
		}

		public void setFilmID(int filmID) {
			FilmID = filmID;
		}

		public int getCustomerID() {
			return CustomerID;
		}

		public void setCustomerID(int customerID) {
			CustomerID = customerID;
		}

		public int getRate() {
			return Rate;
		}

		public void setRate(int rate) {
			Rate = rate;
		}

		public Date getRateDate() {
			return RateDate;
		}

		public void setRateDate(Date rateDate) {
			RateDate = rateDate;
		}

}
