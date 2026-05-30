package com.employee.administrator.configuration;

import org.neo4j.driver.Driver;
import org.springframework.ai.embedding.EmbeddingModel;
import org.springframework.ai.vectorstore.neo4j.Neo4jVectorStore;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class VectorConfig {
    @Bean
    public Neo4jVectorStore vectorStore(Driver driver, EmbeddingModel embeddingModel) {
        return Neo4jVectorStore.builder(driver, embeddingModel)
                        .indexName("custom_vector_index")
                        .label("Document")
                        .embeddingProperty("embedding")
                        .embeddingDimension(1536)
                        .build();
    }
}
