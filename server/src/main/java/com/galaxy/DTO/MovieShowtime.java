package com.galaxy.DTO;

import lombok.Data;

@Data
public class MovieShowtime {

	private int ShowTimeID;
	private int FilmID;
	private String name;
	private byte[] image;
	private int AgeLimited;
	private String time;
	private String screen;
	public MovieShowtime(int showTimeID, int filmID, String name, byte[] image, int ageLimited, String time,String screen) {
		super();
		ShowTimeID = showTimeID;
		FilmID = filmID;
		this.name = name;
		this.image = image;
		AgeLimited = ageLimited;
		this.time = time;
		this.screen = screen;
	}
	
	
	
	
}
