package com.galaxy.entities;

import java.sql.Date;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

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
@Table
@Data
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"}) 
public class Invoice {

	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int InvoiceID;
	
//	@ManyToOne(fetch = FetchType.LAZY)
//	@JoinColumn(name = "CustomerID", nullable = false)
//	private Customer CustomerID;
//	
//	private int discount;
//	private int total;
//	private int TypeofPayment;
//	private Date endShow;
	
	
}
