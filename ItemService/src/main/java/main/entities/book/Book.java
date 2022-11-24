package main.entities.book;

import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonProperty.Access;
import com.fasterxml.jackson.databind.annotation.JsonSerialize;

import lombok.Getter;
import lombok.Setter;
import main.entities.Item;
import main.services.CustomBookSerializer;

@Entity
@Getter
@Setter
//@JsonSerialize(using=CustomBookSerializer.class)
public class Book extends Item {
	
	private String title;
	
	private String author;
	
	private String genre;
	
	
	public Book() {}

	public Book(Integer price, Integer available, String title, String author, String genre) {
		super(price, available);
		this.title=title;
		this.author=author;
		this.genre=genre;
	}

	
	@Override
	public String toString() {
		return title+", "+author+" ";
	}
}
