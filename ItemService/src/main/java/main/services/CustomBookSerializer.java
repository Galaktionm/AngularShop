package main.services;

import java.io.IOException;

import com.fasterxml.jackson.core.JsonGenerator;
import com.fasterxml.jackson.databind.JsonSerializer;
import com.fasterxml.jackson.databind.SerializerProvider;

import main.entities.book.Book;


public class CustomBookSerializer extends JsonSerializer<Book> {

	@Override
	public void serialize(Book book, JsonGenerator gen, SerializerProvider serializers) throws IOException {
		
		gen.writeStartObject();
		gen.writeStringField("author", book.getAuthor());
        gen.writeStringField("title", book.getTitle());
        gen.writeStringField("genre", book.getGenre());
       
        gen.writeEndObject();
		
	}
	
	

}
