package com.galaxy.controllers;



import java.util.ArrayList;
import java.util.List;
import java.util.Set;

import org.apache.tomcat.util.bcel.Const;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.servlet.mvc.method.annotation.ResponseBodyEmitter;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import com.galaxy.DTO.AlgorithmAndDataRes;
import com.galaxy.DTO.MovieShowtime;
import com.galaxy.DTO.ratingDTO;
import com.galaxy.entities.Customer;
import com.galaxy.entities.Film;
import com.galaxy.entities.Movie;
import com.galaxy.entities.Rating;
import com.galaxy.repositories.RatingRepo;
import com.galaxy.serviceImp.CustomerSerImp;
import com.galaxy.serviceImp.MovieSerlmp;
import com.galaxy.serviceImp.RatingSerImp;

@RestController
@RequestMapping("api/recommend")
public class RecommendController {
	
	@Autowired
	MovieSerlmp movieSerlmp;
	
	@Autowired
	RatingSerImp ratingSerImp;
	
	@Autowired
	CustomerSerImp customerSerImp;
	
	@Autowired
	RatingRepo ratingRepo;
	

	@GetMapping("{id}")
	public List<Film> getRecommendations(@PathVariable int id) {
		
		return ratingSerImp.recommendFilmsForCustomer(id);
	}
	
	@GetMapping("a/{id}")
	public ResponseEntity<AlgorithmAndDataRes> test(@PathVariable int id) {
		
	//Customer customer =	customerSerImp.getCustomer(id);
		
		System.out.println("id" + id);

		
		AlgorithmAndDataRes dataRes = ratingSerImp.rec(id);
		System.out.println(dataRes.getNameCus().size());
		System.out.println(dataRes.getNameItem().size());
		dataRes.formatSimilarMatrix();
		
		
	return	ResponseEntity.ok(dataRes);
//		ratingSerImp.recommendMovies(id,5);
		
		
		
		
		
		
	}
	
	 
}
