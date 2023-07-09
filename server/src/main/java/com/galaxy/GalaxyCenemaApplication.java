package com.galaxy;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.CustomAutowireConfigurer;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;

import com.galaxy.entities.Customer;
import com.galaxy.repositories.CustomerRepo;

@SpringBootApplication
public class GalaxyCenemaApplication implements CommandLineRunner {

	@Autowired
	private CustomerRepo cusRepo;
	
	public static void main(String[] args) {
		SpringApplication.run(GalaxyCenemaApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		System.out.println("run complete");
		
//	List<Customer> customers = 	cusRepo.findAll();
//	for (Customer cus : customers) {
//		System.out.println(cus.getName());
//	}
	}

}
