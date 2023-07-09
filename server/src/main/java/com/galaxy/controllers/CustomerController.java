package com.galaxy.controllers;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import com.galaxy.entities.Customer;
import com.galaxy.serviceImp.CustomerSerImp;

@RestController
@RequestMapping("api/customer")

public class CustomerController {
	
	@Autowired
	CustomerSerImp cusSerImp;
	
	@GetMapping("")
	public List<Customer> getCustomer() {
		return cusSerImp.getAllCustomer();
	}
	
	@GetMapping("/{id}")
	public Customer getCustomerById(@PathVariable int id) {
		return cusSerImp.getCustomer(id);
	}
	
	@PostMapping("/login")
	public Customer getLogin(@RequestBody Customer cus) {
		System.out.println(cus.getEmail());
		System.out.println(cus.getPasswords());
		return cusSerImp.getLogin(cus);
	}
	
	@PostMapping("/create")
	public void createCustomer(@RequestBody Customer customer) {
		System.out.println(customer.getEmail());
		System.out.println(customer.getPasswords());
		System.out.println(customer.getName());
		System.out.println(customer.getSex());
		System.out.println(customer.getPhone());
		System.out.println(customer.getAddress());
		System.out.println(customer.getBirthday());
		
		System.out.println(customer.getPoint());
		this.cusSerImp.addNewCus(customer);
	}

}
