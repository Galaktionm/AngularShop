package main.entities;

import java.time.Duration;
import java.util.Date;

import javax.persistence.Entity;

import lombok.Getter;
import lombok.Setter;

@Entity
@Getter
@Setter
public class Laptop extends Item {
	
	private String brand;
	
	private String model;
	
	private Integer ram;
	
	public Laptop() {
		
	}
	
	public Laptop(Integer price, Integer available, String brand, String model, Integer ram) {
		super(price, available);
		this.brand=brand;
		this.model=model;
		this.ram=ram;
	}

}
