package com.galaxy.entities;

import java.sql.Date;

import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(name = "ShowTime")
public class Movie {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int ShowTimeID;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "FilmID", nullable = false)
	private Film FilmID;
	private Date startShow;
	private Date endShow;
	private String screen;
	
	
	
}
