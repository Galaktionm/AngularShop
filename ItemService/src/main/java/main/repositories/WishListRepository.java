package main.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import main.entities.WishList;
import main.entities.book.BookWishList;

@Repository
public interface WishListRepository extends JpaRepository<WishList, Long> {
	
	@Query(value="select * from BookWishList", nativeQuery=true)
	List<BookWishList> bookWishLists();

}
