package com.galaxy.DTO;

public class ProductBillDTO {

private int	productID;
private int	  quantity;
private String details;
public int getProductID() {
	return productID;
}
public void setProductID(int productID) {
	this.productID = productID;
}
public int getQuantity() {
	return quantity;
}
public void setQuantity(int quantity) {
	this.quantity = quantity;
}
public String getDetails() {
	return details;
}
public void setDetails(String details) {
	this.details = details;
}

public String show() {
	return this.productID +"_" +this.quantity+ "_" + this.details;
}


}
