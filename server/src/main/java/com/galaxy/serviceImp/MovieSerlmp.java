package com.galaxy.serviceImp;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.galaxy.DTO.FilmDTO;
import com.galaxy.DTO.MovieShowtime;
import com.galaxy.entities.Customer;
import com.galaxy.entities.Film;
import com.galaxy.entities.Movie;
import com.galaxy.repositories.CustomerRepo;
import com.galaxy.repositories.MovieRepo;


@Service
public class MovieSerlmp {

	@Autowired
	MovieRepo cusRepo;

	
	public List<Object[]> getMovieByDay(String date) {
	return	cusRepo.GetFilmByDay(date);
	}
	
	
	public List<String> getSeatOrdered(int showtimeID) {
		return	cusRepo.GetSeatOrdered(showtimeID);
	}


	public List<Film> getFilmActive() {
		return	cusRepo.GetFilmActive();
	}
	
	public List<Object[]> GetShowTimeByFilm(String date, int filmID) {
		return	cusRepo.GetShowTimeByFilm(date,filmID);
	}
}
