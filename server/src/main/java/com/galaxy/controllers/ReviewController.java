package com.galaxy.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.galaxy.DTO.ReviewRequestDTO;
import com.galaxy.DTO.ratingDTO;
import com.galaxy.entities.Rating;
import com.galaxy.serviceImp.RatingSerImp;

@RestController
@RequestMapping("api/review")
public class ReviewController {
	
	@Autowired
	RatingSerImp ratingSerImp;
	
	@GetMapping("/{id}")
	public List<ratingDTO> getReviewByFilmID(@PathVariable int id) {
		
		return ratingSerImp.getRatingByFilm(id);
	}
	
	@PostMapping("/addNew")
	public void addNewReview(@RequestBody ReviewRequestDTO review ) {
		System.err.println(review.getFilmID());
		System.err.println( review.getCustomerID());
		System.err.println(review.getComment());
		System.err.println(review.getRate());
		System.err.println(review.getRateDate());
		
		ratingSerImp.insertUserReview(review.getFilmID(), review.getCustomerID(), review.getRateDate(), review.getRate(), review.getComment());
		
	}
	
	@PostMapping("/update")
	public int updateReview(@RequestBody ReviewRequestDTO review ) {
		System.err.println(review.getFilmID());
		System.err.println( review.getCustomerID());
		System.err.println(review.getComment());
		System.err.println(review.getRate());
		System.err.println(review.getRateDate());
		
	return	ratingSerImp.updateUserReview(review.getFilmID(), review.getCustomerID(), review.getRateDate(), review.getRate(), review.getComment());
		
		
	}
	
	

}
