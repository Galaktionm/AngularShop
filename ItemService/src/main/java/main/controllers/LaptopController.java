package main.controllers;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import javax.persistence.EntityManagerFactory;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import main.entities.Laptop;
import main.entities.Item;
import main.helpers.AddBookResult;
import main.repositories.LaptopRepository;

@RestController
@RequestMapping("api/Laptops")
public class LaptopController {
	
	@Autowired
	private LaptopRepository laptopRepo;
	
	
	@GetMapping("/All")
	public List<Laptop> getAllLaptops(){
		List<Laptop> laptops=laptopRepo.findAll();
		return laptops;
	}
	
	@GetMapping("/Starter")
	public List<Laptop> getStarterLaptops(){
		List<Laptop> laptops=laptopRepo.findAll().stream().limit(20).sorted(new Comparator<Item>() {
			@Override
			public int compare(Item o1, Item o2) {
				if(o1.getCreatedAt().isBefore(o2.getCreatedAt())) {
					return -1;
				} else if(o2.getCreatedAt().isBefore(o1.getCreatedAt())){
					return 1;
				} else {
					return 0;
				}
			}						
		}).collect(Collectors.toList());
		return laptops;
	}
	
	@PostMapping("/Add/{userId}")
	public ResponseEntity<AddBookResult> addLaptopToUser(@RequestBody Laptop Laptop, @PathVariable("userId") String userId) {
				
	 System.out.println(userId);
	  if(userId!=null) {
		Laptop.setOwnerId(userId);
	  }
		
	  Laptop savedLaptop=laptopRepo.save(Laptop);
	  
	  if(savedLaptop!=null) {
		  AddBookResult result=new AddBookResult(savedLaptop.getId(), userId);
		  return new ResponseEntity<AddBookResult>(result, HttpStatus.OK);
	  }	  
		return new ResponseEntity<>(null, HttpStatus.BAD_REQUEST);	
	}
	
	

}
