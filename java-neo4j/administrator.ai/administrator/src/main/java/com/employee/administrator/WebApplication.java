package com.employee.administrator;
import org.springframework.ai.chat.client.ChatClient;
import org.springframework.ai.embedding.EmbeddingResponse;
import org.springframework.ai.chat.model.ChatResponse;
import org.springframework.ai.ollama.OllamaEmbeddingModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.core.env.Environment;

import java.net.InetAddress;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;
import java.util.Arrays;

@SpringBootApplication
public class WebApplication implements CommandLineRunner {
    //private final log =  (WebApplication.class);

    @Autowired
    Environment environment;

    @Autowired
    private ChatClient chatClient;

    // Port via annotation
    @Value("${server.port}")
    int aPort;

    @Autowired
    private OllamaEmbeddingModel embeddingModel;

    public static void main(String[] args) {
        SpringApplication.run(WebApplication.class, args);
    }

    @Override
    public void run(String... args) {
        try {
            // Port
            System.out.println("--- Server Port ---");
            System.out.println(environment.getProperty("server.port"));
            System.out.println("-------------------");

            // Local address
            System.out.println("--- Local address ---");
            System.out.println(InetAddress.getLocalHost().getHostAddress());
            System.out.println(InetAddress.getLocalHost().getHostName());
            System.out.println("-------------------");

            // Remote address
            System.out.println("--- Remote address ---");
            System.out.println(InetAddress.getLoopbackAddress().getHostAddress());
            System.out.println(InetAddress.getLoopbackAddress().getHostName());
            System.out.println("-------------------");

            String text = "Spring AI makes AI integration easy in Spring Boot.";

            // Generate embeddings
            EmbeddingResponse response = embeddingModel.embedForResponse(text.lines().toList());

            // Convert vector to readable string
//            String readableVector = response.getResults().get(0).getOutput()
//                    .map(num -> String.format("%.4f", num)) // format to 4 decimal places
//                    .collect(Collectors.joining(", "));

             String context = response.getResults().stream()
                     .map(value -> Arrays.toString(value.getOutput()))
                     .collect(Collectors.joining("\n\n"));

            // 3. Ask the AI to summarize or respond naturally
            ChatResponse ctResponse = chatClient.prompt()
//                    .user("Based on the following context, answer the question:\n\n" + context +
//                            "\n\nQuestion: " + query)
                    .user("Based on the following context, answer the question:\n\n" + context +
                            "\n\nQuestion: " + text)
                    .call()
                    .chatResponse();

            System.out.println(ctResponse.getResult().getOutput().getText());

            //System.out.println(readableVector);

            System.out.println(response.getMetadata().getModel());
            //System.out.println(String.join("\n", response.getMetadata().keySet()));

            // Retrieve the vector
            float[] vec = response.getResults().getFirst().getOutput();

            List<Float> vector = IntStream.range(0, vec.length)
                    .mapToObj(i -> vec[i])
                    .toList();

            System.out.println("Embedding vector size: " + vector.size());
            System.out.println("vValues: " + vector.subList(0, vector.size()));

            //System.out.println("First 5 values: " + vector.subList(0, Math.min(5, vector.size())));

            System.out.println("Exit Web Application manually, in case, you want to do it");
            Thread.currentThread().join();
        } catch (Exception e) {
            System.err.println("Error generating embedding: " + e.getMessage());
        }
    }
}
