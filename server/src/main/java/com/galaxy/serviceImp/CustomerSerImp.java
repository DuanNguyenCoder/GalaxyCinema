package com.galaxy.serviceImp;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.galaxy.entities.Customer;
import com.galaxy.repositories.CustomerRepo;


@Service
public class CustomerSerImp  {

	@Autowired
	CustomerRepo cusRepo;
	
	
	public List<Customer> getAllCustomer() {
	return	cusRepo.GetCustomers();
	}

	
	public Customer getCustomer(int id) {
		return cusRepo.GetCustomerById(id);
		
	}
	
	public Customer getLogin(Customer cus) {
		return cusRepo.Getlogin(cus.getEmail(),cus.getPasswords());	
	}
	
	public void addNewCus(Customer c) {
		cusRepo.save(c);
	}

}
