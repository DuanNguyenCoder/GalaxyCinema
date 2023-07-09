package com.galaxy.DTO;

import java.util.Arrays;
import java.util.List;

public class BillReqDTO {

private int	filmID;
private int	  showTimeID;
private String	  seat[];
private long total;
private int customerID;
private List<ProductBillDTO> product;
private String mail;

public String getMail() {
	return mail;
}

public void setMail(String mail) {
	this.mail = mail;
}

public long getTotal() {
	return total;
}

public int getCustomerID() {
	return customerID;
}

public void setCustomerID(int customerID) {
	this.customerID = customerID;
}

public void setTotal(long total) {
	this.total = total;
}


public int getFilmID() {
	return filmID;
}

public void setFilmID(int filmID) {
	this.filmID = filmID;
}

public int getShowTimeID() {
	return showTimeID;
}

public void setShowTimeID(int showTimeID) {
	this.showTimeID = showTimeID;
}

public String[] getSeat() {
	return seat;
}

public void setSeat(String[] seat) {
	this.seat = seat;
}

public List<ProductBillDTO> getProduct() {
	return product;
}

public void setProduct(List<ProductBillDTO> product) {
	this.product = product;
}

@Override
public String toString() {
    return "Bill{" +
    		 "cusID=" + customerID +
            "filmID=" + filmID +
            ", showTimeID=" + showTimeID +
            ", seat=" + Arrays.toString(seat) +
            ", product=" + product +
             ", total=" + total +
            '}';
}
}
