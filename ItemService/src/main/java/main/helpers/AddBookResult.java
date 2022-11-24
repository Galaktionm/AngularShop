package main.helpers;

public class AddBookResult {
	
	public Long bookId;
	
	public String userId;
	
	public AddBookResult() {}
	
	public AddBookResult(Long bookId, String userId) {
		this.bookId=bookId;
		this.userId=userId;
	}

}
