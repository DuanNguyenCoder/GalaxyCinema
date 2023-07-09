package com.galaxy.DTO;

import java.time.LocalTime;

import lombok.AllArgsConstructor;
import lombok.Data;


@Data
@AllArgsConstructor
public class FilmDTO {

	private int FilmID;
	private Byte[] film;
	private String name;
	private String typefilm;
	private LocalTime time;
	private String description;
	private String link;
	private int AgeLimited;
	private Byte[] image;
	private int active;
	
	
	
}
	
	