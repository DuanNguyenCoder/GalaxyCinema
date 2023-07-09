package com.galaxy.controllers;


import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import com.galaxy.DTO.FilmDTO;
import com.galaxy.DTO.FilmDTO;
import com.galaxy.DTO.MovieShowtime;
import com.galaxy.DTO.ShowtimeRequestDTO;
import com.galaxy.entities.Customer;
import com.galaxy.entities.Film;
import com.galaxy.entities.Movie;
import com.galaxy.serviceImp.CustomerSerImp;
import com.galaxy.serviceImp.MovieSerlmp;

@RestController
@RequestMapping("api/movie")
public class MovieController {
	
	@Autowired
	MovieSerlmp movieSerlmp;
	
	@GetMapping("")
	public List<MovieShowtime> getMovieByDay(@RequestParam("day") int day,@RequestParam("month") String month,@RequestParam("year") String year) {
		
//		List<Object[]> list = movieSerlmp.getMovieByDay("2022-07-02");
		
		String date = year + "-"+ month+"-" + day; 
		System.out.println(date);
		List<Object[]> list = movieSerlmp.getMovieByDay(date);
		 List<MovieShowtime> result = new ArrayList<>();
		for(Object[] obj : list){
		   int showTimeId = (int) obj[0];
		   int filmId = (int) obj[1];
		   String name = (String) obj[2];
	   byte[] image = (byte[]) obj[3];
		   int age = (int) obj[4];
		   String time = (String) obj[6];
		   String screen = (String) obj[5];
		   
		   MovieShowtime m = new MovieShowtime(showTimeId, filmId, name, image, age, time,screen);
		   result.add(m);
		   
		}
		
		return result;
	}
	
	@GetMapping("/{showtimeID}")
	public List<String> getSeatOrdered(@PathVariable int showtimeID) {
		
		return movieSerlmp.getSeatOrdered(showtimeID);
	}
	
	
	@PostMapping("/showTime")
	public List<Object[]> getFilmActive(@RequestBody ShowtimeRequestDTO movie) {
		System.out.println(movie.getDate());
		System.out.println(movie.getFilmID());
		
		    return  movieSerlmp.GetShowTimeByFilm(movie.getDate(),movie.getFilmID());
		
	}
	
	@GetMapping("/active")
	public List<Film> getFilmActive() {
		    return  movieSerlmp.getFilmActive();
		
	}
}
