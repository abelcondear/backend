package com.employee.administrator.controller;
import org.neo4j.driver.types.Entity;
import org.springframework.ai.chat.client.ResponseEntity;

import com.employee.administrator.service.EmbeddingService;
import org.springframework.ai.embedding.EmbeddingResponse;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/embeddings")
public class EmbeddingController {
    private final EmbeddingService embeddingService;

    public EmbeddingController(EmbeddingService embeddingService) {
        this.embeddingService = embeddingService;
    }

    // need to fix post method
    // need to fix ResponseEntity usage
    //@PostMapping("/api/embeddings")
    @GetMapping("/api/embeddings")
    public String generateEmbedding(@RequestBody String input) {
    //public ResponseEntity<EmbeddingResponse, Entity> generateEmbedding(@RequestBody String input) {
    //public EmbeddingResponse generateEmbedding(@RequestBody String input) {
        return input;
        //return embeddingService.generateEmbedding(input);

        // EmbeddingResponse response = embeddingService.generateEmbedding(input);

//        return new ResponseEntity<>(
//                response,
//                (
//                        new ResponseEntity<>
//                        (
//                            response,response
//                        )
//                ).getEntity()
//        );

        //return ResponseEntity.ok(response);
    }
}


//package com.example.demo.controller;
//
//import org.springframework.http.HttpStatus;
//import org.springframework.http.ResponseEntity;
//import org.springframework.web.bind.annotation.*;
//
//import java.util.HashMap;
//import java.util.Map;
//
//@RestController
//@RequestMapping("/api")
//public class UserController {
//
//    // Example endpoint returning two parameters in JSON
//    @GetMapping("/user")
//    public ResponseEntity<Map<String, Object>> getUser() {
//        // Create a response map with two parameters
//        Map<String, Object> response = new HashMap<>();
//        response.put("name", "John Doe");
//        response.put("age", 30);
//
//        // Return ResponseEntity with body and status
//        return new ResponseEntity<>(response, HttpStatus.OK);
//    }
//
//    // Example endpoint receiving two parameters from request
//    @PostMapping("/user")
//    public ResponseEntity<Map<String, Object>> createUser(
//            @RequestParam String name,
//            @RequestParam int age) {
//
//        Map<String, Object> response = new HashMap<>();
//        response.put("message", "User created successfully");
//        response.put("name", name);
//        response.put("age", age);
//
//        return ResponseEntity.status(HttpStatus.CREATED).body(response);
//    }
//}
