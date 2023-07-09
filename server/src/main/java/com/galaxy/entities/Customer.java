package com.galaxy.entities;

import java.sql.Date;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Table
@Data
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"}) 
public class Customer {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int CustomerID;
	private String Name;
	private String Address;
	private String Phone;
	private String email;
	private String passwords;
	private Date Birthday;
	private int sex;
	
	private int point;
	
	@JsonIgnore
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "CustomerID")
	private List<Rating> rating;

}
