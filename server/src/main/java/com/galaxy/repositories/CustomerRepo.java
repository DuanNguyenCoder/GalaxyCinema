package com.galaxy.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;

import com.galaxy.entities.Customer;

public interface CustomerRepo extends JpaRepository<Customer, Integer> {

	 @Query(value  = "EXEC sp_GetCustomers",nativeQuery = true)
	    List<Customer> GetCustomers();
	 
	 @Query(value  = "EXEC sp_GetCustomerByID  @CustomerID = :id",nativeQuery = true)
	    Customer GetCustomerById(@Param("id") int id);
	 
	 @Query(value  = "select * from customer where email = :e and passwords = :p ",nativeQuery = true)
	    Customer Getlogin(@Param("e") String email, @Param("p") String pass );
	 
	 @Query(value  ="SELECT * FROM Customer  WHERE customerId <> :customerId",nativeQuery = true)
	    List<Customer> findAllExceptCustomer(@Param("customerId") int customerId);
}


