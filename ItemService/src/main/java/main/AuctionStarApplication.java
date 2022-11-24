package main;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Random;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.CorsConfigurationSource;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;

import main.entities.Item;
import main.entities.Laptop;
import main.entities.WishList;
import main.entities.book.Book;
import main.entities.book.BookWishList;
import main.repositories.BookRepository;
import main.repositories.ItemRepository;
import main.repositories.WishListRepository;
import main.services.MessagingService;
import main.services.WishListService;

@SpringBootApplication
@ComponentScan
public class AuctionStarApplication {
	
	@Autowired
	private EntityManagerFactory emf;	
	@Autowired
	private ItemRepository itemRepo;
	@Autowired
	private BookRepository bookRepo;
	@Autowired
	private MessagingService service;
	@Autowired
	private WishListRepository repo;
	@Autowired
	private WishListService wlService;
	
	private static Random rand=new Random();

	public static void main(String[] args) {
		SpringApplication.run(AuctionStarApplication.class, args);
	}
	
	

	@Bean
	CommandLineRunner sendMessages() {
		return args->{
			wlService.executePool();
		};
	}
	
	@Bean
    CorsConfigurationSource corsConfigurationSource()
    {
        CorsConfiguration configuration = new CorsConfiguration();
        configuration.setAllowedOrigins(Arrays.asList("*"));
        configuration.setAllowedHeaders(Arrays.asList("Origin", "Content-Type", "Accept","Authorization"));
        configuration.setAllowedMethods(Arrays.asList("GET","POST"));
        UrlBasedCorsConfigurationSource source = new    UrlBasedCorsConfigurationSource();
        source.registerCorsConfiguration("/**", configuration);
        return source;
    }
	
	@Bean
	CorsConfiguration configureCors() {
		CorsConfiguration conf=new CorsConfiguration();
		conf.applyPermitDefaultValues();
		return conf;
	}
	
	
	


}
