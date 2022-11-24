package main.controllers;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import main.entities.Item;
import main.entities.WishList;
import main.entities.book.Book;
import main.entities.book.BookWishList;
import main.helpers.AddBookResult;
import main.repositories.BookRepository;
import main.repositories.WishListRepository;

@RestController
@RequestMapping("api/Books")
@CrossOrigin
public class BookController {

	@Autowired
	private BookRepository bookRepo;
	@Autowired
	private WishListRepository repo;
	
	@GetMapping("/{id}")
	public ResponseEntity<Book> getBookById(@PathVariable Long id) {
		Optional<Book> book=bookRepo.findById(id);
		if(book.get()!=null) {
			return new ResponseEntity<Book>(book.get(), HttpStatus.OK);
		}
		
		return new ResponseEntity<>(null, HttpStatus.BAD_REQUEST);
	}
	
	@GetMapping("/All")
	public List<Book> getAllBooks(){
		List<Book> books=bookRepo.findAll();
		return books;
	}
	
	@GetMapping("/Starter")
	public List<Book> getStarterBooks(){
		System.out.println("Starter Executed");
		List<Book> books=bookRepo.findAll().stream().sorted(new Comparator<Item>() {
			@Override
			public int compare(Item o1, Item o2) {
				if(o1.getCreatedAt().isBefore(o2.getCreatedAt())) {
					return 1;
				} else if(o2.getCreatedAt().isBefore(o1.getCreatedAt())){
					return -1;
				} else {
					return 0;
				}
			}						
		}).limit(20).collect(Collectors.toList());
		return books;
	}
	
	@PostMapping("/Add/{userId}")
	public ResponseEntity<AddBookResult> addBookToUser(@RequestBody Book book, @PathVariable("userId") String userId) {
				
	 System.out.println(userId);
	  if(userId!=null) {
		book.setOwnerId(userId);
	  }
		
	  Book savedBook=bookRepo.save(book);
	  
	  if(savedBook!=null) {
		  AddBookResult result=new AddBookResult(savedBook.getId(), userId);
		  return new ResponseEntity<AddBookResult>(result, HttpStatus.OK);
	  }	  
		return new ResponseEntity<>(null, HttpStatus.BAD_REQUEST);	
	}
	
	@GetMapping("/WishList/{userId}")
	public ResponseEntity<List<Book>> getWishListBooks(@PathVariable("userId") String userId){
		
		
		List<BookWishList> list=repo.bookWishLists().stream().filter(e->e.getUserId().equals(userId))
				.collect(Collectors.toList());
		
		List<Book> result=new ArrayList<>();
		
		for(BookWishList wish:list) {
			bookRepo.findAll().stream().filter(e->e.getGenre().contentEquals(wish.getGenre()))
			.collect(Collectors.toList()).forEach(e->result.add(e));					
		}
		
		if(result.size()!=0) {
			return new ResponseEntity<List<Book>>(result, HttpStatus.OK);
		}
		
		return new ResponseEntity<>(null, HttpStatus.I_AM_A_TEAPOT);
		
	}
	
	@PostMapping("/Add/WishList")
	public ResponseEntity<String> addWish(@RequestBody BookWishList wish){
		
		wish.setItemClass(Book.class);
		repo.save(wish);
		
		return new ResponseEntity<String>("Success", HttpStatus.OK);
		
	}
	
	
	
	

}
