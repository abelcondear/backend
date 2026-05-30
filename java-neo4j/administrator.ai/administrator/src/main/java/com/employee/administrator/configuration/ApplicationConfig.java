package com.employee.administrator.configuration;

import org.neo4j.driver.AuthTokens;
import org.neo4j.driver.Driver;
import org.neo4j.driver.GraphDatabase;
import org.springframework.ai.embedding.EmbeddingModel;
import org.springframework.ai.embedding.TokenCountBatchingStrategy;
import org.springframework.ai.vectorstore.VectorStore;
import org.springframework.ai.vectorstore.neo4j.Neo4jVectorStore;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class ApplicationConfig {
    @Bean
    public Driver driver() {
        return GraphDatabase.driver(
                "neo4j://127.0.0.1:7687",
                AuthTokens.basic(
                        "neo4j",
                        "neo4jroot0"
                )
        );
    }
        
    @Bean
    public VectorStore vectorStore(Driver driver, EmbeddingModel embeddingModel) {
        return Neo4jVectorStore.builder(driver, embeddingModel)
            .databaseName("neo4j")                // Optional: defaults to "neo4j"
            .distanceType(Neo4jVectorStore.Neo4jDistanceType.COSINE) // Optional: defaults to COSINE
            .embeddingDimension(1536)                      // Optional: defaults to 1536
            .label("Document")                     // Optional: defaults to "Document"
            .embeddingProperty("embedding")        // Optional: defaults to "embedding"
            .indexName("custom-index")             // Optional: defaults to "spring-ai-document-index"
            .initializeSchema(true)                // Optional: defaults to false
            .batchingStrategy(new TokenCountBatchingStrategy()) // Optional: defaults to TokenCountBatchingStrategy
            .build();
    }
}
