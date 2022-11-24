package main.configurations;

import javax.sound.midi.Receiver;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Queue;
import org.springframework.amqp.rabbit.connection.ConnectionFactory;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.amqp.rabbit.listener.SimpleMessageListenerContainer;
import org.springframework.amqp.rabbit.listener.adapter.MessageListenerAdapter;
import org.springframework.amqp.support.converter.Jackson2JsonMessageConverter;
import org.springframework.amqp.support.converter.MessageConverter;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MessagingConfiguration {
	
	private static final String userItemExchange="userItemExchange";
	private static final String userItemQueue="userItemQueue";
	private static final String userItemRoutingKey="userItemRountingKey";
	
	
	@Bean
	public DirectExchange userItemExchange() {
		return new DirectExchange(userItemExchange);
	}
	
	@Bean
	public Queue userItemQueue() {
		return new Queue(userItemQueue);
	}
	
	@Bean
	public Binding userItemBinding() {
		return BindingBuilder.bind(userItemQueue()).to(userItemExchange()).with(userItemRoutingKey);
	}
	
	 @Bean
	 public MessageConverter converter() {
		 return new Jackson2JsonMessageConverter();
	 }
	 
}
