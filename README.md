# Store Management System 🛒

[![Java Version](https://img.shields.io/badge/Java-17-blue.svg)](https://openjdk.org/)
[![Spring Boot](https://img.shields.io/badge/Spring_Boot-3.2.5-brightgreen.svg)](https://spring.io/projects/spring-boot)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A comprehensive inventory and order management system built with Spring Boot. Manage products, track inventory, and process orders through RESTful APIs.

## ✨ Features
- **Product Management**: Create, read, update, and delete products
- **Inventory Control**: Track stock levels in real-time
- **Order Processing**: Handle customer orders with status tracking
- **Database Flexibility**: H2 in-memory DB (development), PostgreSQL ready (production)
- **RESTful APIs**: Fully documented endpoints for integration

## 🛠️ Technology Stack
- **Backend**: Java 17, Spring Boot 3.2.5
- **Database**: H2 (Development), PostgreSQL (Production)
- **Tools**:
  - Spring Data JPA
  - Lombok
  - Maven
  - Spring Web
- **Architecture**: MVC Pattern with Service Layer

## 📚 API Documentation

Product Endpoints
Method	Endpoint	Description
POST	/products	Create new product
GET	/products	List all products
GET	/products/{id}	Get product by ID
PUT	/products/{id}	Update product
DELETE	/products/{id}	Delete product
Order Endpoints
Method	Endpoint	Description
POST	/orders	Create new order
GET	/orders	List all orders
GET	/orders/{id}	Get order by ID
PUT	/orders/{id}/status	Update order status

## 🗄️ Database Schema
CREATE TABLE product (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL
);

CREATE TABLE orders (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(20) DEFAULT 'PENDING'
);

CREATE TABLE order_item (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    order_id BIGINT REFERENCES orders(id),
    product_id BIGINT REFERENCES product(id),
    quantity INT NOT NULL
);
## 🧪 Testing the API
Use these sample curl commands:

Create Product:
curl -X POST http://localhost:8080/products \
  -H "Content-Type: application/json" \
  -d '{
        "name": "Laptop",
        "price": 999.99,
        "stock": 10
      }'

Create Order:
curl -X POST http://localhost:8080/orders \
  -H "Content-Type: application/json" \
  -d '{
        "items": [
          {"productId": 1, "quantity": 2}
        ]
      }'

## 🤝 Contributing
Contributions are welcome! Please follow these steps:

Fork the repository
Create your feature branch (git checkout -b feature/amazing-feature)
Commit your changes (git commit -m 'Add some amazing feature')
Push to the branch (git push origin feature/amazing-feature)
Open a pull request


## 🚀 Getting Started

### Prerequisites
- Java 17+
- Maven 3.6+
- (Optional) PostgreSQL 15+

### Installation
```bash
# Clone repository
git clone https://github.com/Elham7899/Store.git

# Navigate to project
cd Store

# Build and run
mvn spring-boot:run
Access H2 Database Console
URL: http://localhost:8080/h2-console

JDBC URL: jdbc:h2:mem:testdb

Username: ("")
Password: ("")
