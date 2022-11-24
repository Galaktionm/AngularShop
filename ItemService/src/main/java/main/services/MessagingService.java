package main.services;

import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Queue;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MessagingService {
	
	@Autowired
	private DirectExchange exchange;
	
	@Autowired
	private Queue queue;
	
	@Autowired
	private RabbitTemplate rabbit;
	
	public void sendMessage(Object obj) {
		rabbit.convertAndSend(exchange.getName(), "userItemRoutingKey", obj);
	}

	
	
	

}
