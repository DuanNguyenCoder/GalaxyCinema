package com.galaxy.DTO;

import java.io.Serializable;

import lombok.Getter;


public class PaymentResDTO implements Serializable {

	private String status;
	private String message;
	private String url;
	
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public String getMessage() {
		return message;
	}
	public void setMessage(String message) {
		this.message = message;
	}
	public String getUrl() {
		return url;
	}
	public void setUrl(String url) {
		this.url = url;
	}
	
	public PaymentResDTO() {
		super();
	}
	
}
