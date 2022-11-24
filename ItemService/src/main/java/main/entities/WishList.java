package main.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.Data;

@Entity
@Data
@Inheritance(strategy=InheritanceType.TABLE_PER_CLASS)
public class WishList {
	
	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE)
	private Long id;
	
	@JsonIgnore
	private Class<? extends Item> itemClass;
	
	public String userId;
	
	private Integer lowPrice=0;
	
	private Integer highPrice=Integer.MAX_VALUE;
	
	public WishList() {}
	
	public WishList(Class<? extends Item> item, String userId, Integer lowPrice, Integer highPrice) {
		this.itemClass=item;
		this.userId=userId;
		this.lowPrice=lowPrice;
		this.highPrice=highPrice;
	}

}
