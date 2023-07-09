package com.galaxy.repositories;

import java.time.LocalDate;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import com.galaxy.DTO.MovieShowtime;
import com.galaxy.DTO.ratingDTO;
import com.galaxy.entities.Customer;
import com.galaxy.entities.Film;
import com.galaxy.entities.Movie;
import com.galaxy.entities.Rating;
import com.galaxy.entities.test;

public interface RatingRepo extends JpaRepository<Rating, Integer> {
	 
	// lay danh sach danh gia cua user
	 @Query(value = "SELECT * FROM Rating WHERE CustomerID = :userId", nativeQuery = true)
	    List<Rating> findByUserId(@Param("userId") int userId);
	 
	// lay danh sach danh gia theo film
	    @Query(value = "SELECT * FROM Rating WHERE FilmID = :itemId", nativeQuery = true)
	    List<Rating> findByItemId(@Param("itemId") int itemId);
	    
	 // lay danh sach danh gia theo film
	    @Query(value = "SELECT * FROM Rating", nativeQuery = true)
	    List<ratingDTO> getALLRating();
	    
	    
	 // them moi user review
	    @Modifying
	    @Transactional
	    @Query(value = "insert rating(filmID,customerID,Rate,RateDate,comment) values (:filmID,:customerID,:rate,:rateDate,:comment)", nativeQuery = true)
	    void insertNewReview(@Param("filmID") int filmID,@Param("customerID") int customerID,@Param("rate") int rate,@Param("rateDate") LocalDate rateDate,@Param("comment") String comment);
	    
	 // update user review
	    @Modifying
	    @Transactional
	    @Query(value = "update rating set rate = :newRate, comment = :newComment, rateDate = :newRateDate where customerid = :cusID and filmID = :filmID", nativeQuery = true)
	    int updateReview(@Param("cusID") int cusID,@Param("filmID") int filmID,@Param("newRate") int newRate,@Param("newRateDate") LocalDate newRateDate,@Param("newComment") String newComment);
	    
	   
	    
	  // lay ra het cac danh gia cua nguoi dung theo film
	    @Query(value = "SELECT r.customerID,r.ratingID , c.name, r.rate,r.rateDate,r.comment FROM Rating r inner join customer c on r.customerID = c.CustomerID and filmID = :id", nativeQuery = true)
	    List<ratingDTO> getReviewByIdFilm(@Param("id") int id);
	    
	    
	 // lay danh sach danh gia theo film cua khach hang
	    @Query(value = "SELECT * FROM Rating r WHERE r.customerID = :customerAId AND r.filmID IN (SELECT r2.filmID FROM Rating r2 WHERE r2.customerid = :customerBId)", nativeQuery = true)
	    List<Rating> findCommonRatings(@Param("customerAId") int customerAId, @Param("customerBId") int customerBId);
	    
	    
		 // lay ra so diem danh gia phim theo customer
	    @Query(value = "SELECT rate FROM Rating r WHERE r.filmid = :filmId AND r.customerid = :customerId", nativeQuery = true)
	    int findRatingByFilmAndCustomer(@Param("filmId") int filmId, @Param("customerId") int customerId);
	    
	    
	  
	   
	  
		 
}