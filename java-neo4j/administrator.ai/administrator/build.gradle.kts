import org.gradle.kotlin.dsl.implementation

plugins {
	java
	id("org.springframework.boot") version "4.0.5"
	id("io.spring.dependency-management") version "1.1.7"
}

group = "com.employee"
version = "0.0.1-SNAPSHOT"

java {
	toolchain {
		languageVersion = JavaLanguageVersion.of(25)
	}
}

//repositories {
//    maven { url 'https://repo.spring.io/milestone' }
//    maven { url 'https://repo.spring.io/snapshot' }
//}

repositories {
	mavenCentral()
}

extra["springAiVersion"] = "2.0.0-M3"

dependencies {
    // development ------------
    // neo4j
	implementation("org.springframework.boot:spring-boot-starter-data-neo4j")
	implementation("org.springframework.ai:spring-ai-starter-vector-store-neo4j")
	implementation("org.springframework.ai:spring-ai-neo4j-store")

    // openai
    implementation("org.springframework.ai:spring-ai-starter-model-openai")

    implementation("org.springframework.ai:spring-ai-openai")
    implementation("org.springframework.ai:spring-ai-openai-spring-boot-starter")

    //implementation("org.springframework.ai:spring-ai-spring-boot-autoconfigure")
    //implementation("org.springframework.ai:spring-boot-starter")
    //implementation("org.springframework.ai:spring-ai-openai-spring-boot-starter:1.0.0-M6")

    // implementation platform("io.springboot.ai:spring-ai-bom:1.0.3")
    //implementation("io.springboot.ai:spring-ai-ollama-spring-boot-starter:1.0.3")

    // ollama
    implementation("org.springframework.ai:spring-ai-ollama")
    implementation("org.springframework.ai:spring-ai-starter-model-ollama")

    // chat-client
    implementation("org.springframework.ai:spring-ai-autoconfigure-model-chat-client:1.1.0-M3")
    // end:development ------------

    // testing ------------
	testImplementation("org.springframework.boot:spring-boot-starter-data-neo4j-test")
	testRuntimeOnly("org.junit.platform:junit-platform-launcher")
    // end: testing ------------
}

dependencyManagement {
	imports {
		mavenBom("org.springframework.ai:spring-ai-bom:${property("springAiVersion")}")
        //mavenBom("io.springboot.ai:spring-ai-bom:1.0.3")
	}
}

tasks.withType<Test> {
	useJUnitPlatform()
}
