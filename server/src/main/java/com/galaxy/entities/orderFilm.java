package com.galaxy.entities;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"}) 
public class orderFilm {

	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int orderFilmID;
	

}
