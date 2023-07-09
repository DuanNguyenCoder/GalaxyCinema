package com.galaxy.entities;

import java.time.LocalTime;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Table(name = "Film")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"}) 
@Data
public class Film {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int FilmID;
	private Byte[] film;
	private String name;
	
	@Column(name = "TypeFilm")
	private String typefilm;
	private LocalTime time;
	private int active;
	private String description;
	private String link;
	
	@Column(name = "AgeLimited")
	private int AgeLimited;
	
	
	@Column(name = "image", columnDefinition = "image")
	private byte[] image;
	
	@JsonIgnore
	 @OneToMany(mappedBy = "FilmID", cascade = CascadeType.ALL, orphanRemoval = true)
	 private List<Movie> showtimes;

	@JsonIgnore
	  @OneToMany(mappedBy = "FilmID" , cascade = CascadeType.ALL, orphanRemoval = true)
	    private List<Rating> rating;

	
}
