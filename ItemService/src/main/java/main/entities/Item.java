package main.entities;

import java.time.Duration;
import java.time.LocalDateTime;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

import com.fasterxml.jackson.annotation.JsonIgnore;

import lombok.Data;
import lombok.Getter;
import lombok.Setter;


@Entity
@Getter
@Setter
@Inheritance(strategy = InheritanceType.TABLE_PER_CLASS)
public abstract class Item {
	
	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE)
	@JsonIgnore
	private Long id;
	
	private Integer price;

	private String ownerId;
	
	private Integer available;
	
	@JsonIgnore
	private LocalDateTime createdAt;
	
	public Item() {
		this.createdAt=LocalDateTime.now();
	}
	
	public Item(Integer price, Integer available) {
		this.price=price;
		this.createdAt=LocalDateTime.now();
		this.available=available;
	}
	
	

}
