package main.entities.book;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import lombok.Data;
import main.entities.WishList;
import main.repositories.BookRepository;
import main.repositories.ItemRepository;
import main.repositories.WishListRepository;
import main.services.MessagingService;

@Service
public class BookWishListExaminer extends Thread {
	
	private static Random rand=new Random();
	
	@Autowired
	private WishListRepository repo;
	@Autowired
	private BookRepository bookRepo;
	@Autowired
	private MessagingService service;
	
	
	public BookWishListExaminer() {
		
	}

	@Override
	public void run()  {
		
		List<BookWishList> wishList=repo.bookWishLists();
		List<Book> result=new ArrayList<>();
		
		for(BookWishList wish:wishList) {
			bookRepo.findAll().stream().filter(e->e.getAuthor().equalsIgnoreCase(wish.getAuthor()) &&
					e.getTitle().equalsIgnoreCase(wish.getTitle()) && 
					e.getGenre().equalsIgnoreCase(wish.getGenre()) &&
					e.getPrice()>wish.getLowPrice() && e.getPrice()<wish.getHighPrice())
			.collect(Collectors.toList()).forEach(e->result.add(e));
			if(result.size()!=0) {
				service.sendMessage(new BookWishListResult(wish.getUserId()));
			}
		}		
			try {
				Thread.sleep(500);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}	
		}
			
	@Data
    public class BookWishListResult {
		
    private String userId;
    
    public String itemClass="Book";
			
    private String message="Wishlist items are available";
    				
    public BookWishListResult(String userId) {
    	  this.userId=userId;
    }	
		 
	}


}
