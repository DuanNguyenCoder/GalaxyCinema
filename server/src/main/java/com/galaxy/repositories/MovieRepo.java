package com.galaxy.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;

import com.galaxy.DTO.FilmDTO;
import com.galaxy.DTO.MovieShowtime;
import com.galaxy.entities.Customer;
import com.galaxy.entities.Film;
import com.galaxy.entities.Movie;

public interface MovieRepo extends JpaRepository<Film, Integer> {

	 
	 @Query(value  = "EXEC GetFilmByDay  @date = :date",nativeQuery = true)
	 List<Object[]> GetFilmByDay(@Param("date") String id);
	 
	 
	 @Query(value  = "select seat from orderFilm where showTimeID = :id",nativeQuery = true)
	 List<String> GetSeatOrdered(@Param("id") int id);
	 
	 
	 @Query(value  = "select * from film where active = 1",nativeQuery = true)
	 List<Film> GetFilmActive();
	 

				
	@Query(value  = "exec  GetShowTimeByFilm  @date = :date, @idFilm = :filmID",nativeQuery = true)
	 List<Object[]> GetShowTimeByFilm(@Param("date") String date,@Param("filmID") int filmID);
	 
	 
	
	 
	
}