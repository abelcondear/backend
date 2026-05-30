package com.employee.administrator.service;

import org.springframework.ai.document.Document;
import org.springframework.ai.vectorstore.VectorStore;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class VectorService {
    private final VectorStore vectorStore;

    public VectorService(VectorStore vectorStore) {
        this.vectorStore = vectorStore;
    }

    public void ingestData(List<Document> docs) {
        vectorStore.add(docs); // Embeds and stores in Neo4j
    }

    public List<Document> search(String query) {
        return vectorStore.similaritySearch(query); // Converts query to vector and retrieves matches
    }
}
