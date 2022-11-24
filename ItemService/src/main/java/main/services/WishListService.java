package main.services;

import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import main.entities.book.BookWishList;
import main.entities.book.BookWishListExaminer;
import main.repositories.BookRepository;
import main.repositories.WishListRepository;

@Service
public class WishListService {
		
	@Autowired
	private BookWishListExaminer examiner;
		
	public WishListService() {
		
	}
	
	public void executePool() throws InterruptedException {
		ExecutorService executor=Executors.newCachedThreadPool();
	while(true) {
		executor.execute(examiner);
		System.out.println("Execution started");
		Thread.sleep(10000);
	}
	}

	
	
}
