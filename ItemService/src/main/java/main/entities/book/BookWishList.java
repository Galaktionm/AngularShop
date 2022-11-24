package main.entities.book;

import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;

import lombok.Data;
import main.entities.Item;
import main.entities.WishList;

@Entity
@Data
public class BookWishList extends WishList {
	
	@Column(nullable=true)
	private String title;
	
	@Column(nullable=true)
	private String author;
	
	@Column(nullable=true)
	private String genre;
	
	public BookWishList() {}
	
	public BookWishList(Class<Book> book, String userId, Integer lowPrice, Integer highPrice,
			String title, String author, String genre) {
		super(book, userId, lowPrice, highPrice);
		this.title=title;
		this.author=author;
		this.genre=genre;		
	}
	
	
	

}
