package com.employee.administrator.configuration;

import org.springframework.ai.chat.client.ChatClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.ai.openai.OpenAiChatModel;
import org.springframework.core.env.Environment;

//@Configuration
//public class ChatClientConfig {
//    @Bean
//    public ChatClient chatClient(ChatClient.Builder builder) {
//        return builder.defaultSystem("You are a helpful assistant.")
//                .build();
//    }
//}

@Configuration
public class ChatClientConfig {

    @Autowired
    Environment environment;

    //@Bean
    //public OpenAiChatModel openAiClient() {
    //    return new OpenAiChatModel
    //    (
    //    )

        //return new OpenAiChatModel(
        //        environment.getProperty("spring.ai.api.key"),
        //        environment.getProperty("spring.ai.endpoint")
        //);
    //}
}