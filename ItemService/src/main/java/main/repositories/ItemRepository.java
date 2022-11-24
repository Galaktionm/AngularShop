package main.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import main.entities.Item;
import main.entities.book.Book;

@Repository
public interface ItemRepository extends JpaRepository<Item, Long> {
	
	 
}
