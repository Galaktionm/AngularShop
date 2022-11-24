package main.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import main.entities.book.Book;


public interface BookRepository extends JpaRepository<Book, Long> {
	
	 @Query(value="select * from Book b where b.price between ?1 and ?2"
	 		+ " and b.author=?3 and b.genre=?4", nativeQuery=true)
     List<Book> booksByPriceAndAuthorAndGenre(Integer lowPrice, Integer highPrice, String author, String genre);
	 
	 @Query(value="select * from Book b where b.price between ?1 and ?2"
		 		+ " and b.genre=?3", nativeQuery=true)
	 List<Book> booksByPriceAndGenre(Integer lowPrice, Integer highPrice, String genre);
	 
	 @Query(value="select * from Book b where b.price between ?1 and ?2"
		 		+ " and b.author=?3", nativeQuery=true)
	 List<Book> booksByPriceAndAuthor(Integer lowPrice, Integer highPrice, String author);
	 
	 @Query(value="select * from Book b where b.price between ?1 and ?2"
		 		+ " and b.title=?3", nativeQuery=true)
	 List<Book> booksByPriceAndTitle(Integer lowPrice, Integer highPrice, String title);
	 
	 @Query(value="select * from Book where b.genre=?1", nativeQuery=true)
	 List<Book> booksByGenre(String genre);
	 
	 @Query(value="select * from Book where b.author=?1", nativeQuery=true)
	 List<Book> booksByAuthor(String author);
	 
	 @Query(value="select * from Book where b.title=?1", nativeQuery=true)
	 List<Book> booksByTitle(String title);
	 
	 List<Book> findByGenre(String genre);
	
}
