# System Diagram for eg-shop

This diagram illustrates the main components of the eg-shop system and their interactions.

```mermaid
graph TD
  Frontend[Frontend Angular App]
  APIControllers[API Controllers]
  AppServices[Application Services]
  DomainEntities[Domain Entities]
  Repository[InMemory Grocery Repository]

  Frontend -->|HTTP Requests| APIControllers
  APIControllers -->|Calls| AppServices
  AppServices -->|Uses| DomainEntities
  AppServices -->|Calls| Repository
  Repository -->|Manages| DomainEntities

  subgraph Backend API
    APIControllers
    AppServices
    DomainEntities
    Repository
  end

  APIControllers --> GroceryController[GroceryController]
  APIControllers --> OrderController[OrderController]

  AppServices --> GroceryService[GroceryService]
  AppServices --> OrderService[OrderService]
  AppServices --> InventoryService[InventoryService]
  AppServices --> PaymentService[PaymentService]
  AppServices --> ShippingService[ShippingService]

  DomainEntities --> Grocery[Grocery]
  DomainEntities --> Order[Order]
  DomainEntities --> Invoice[Invoice]
```

- **Frontend Angular App**: The client application that interacts with the backend API.
- **API Controllers**: Expose REST endpoints (e.g., GroceryController, OrderController).
- **Application Services**: Contain business logic (e.g., GroceryService, OrderService, InventoryService, PaymentService, ShippingService).
- **Domain Entities**: Core data models (e.g., Grocery, Order, Invoice).
- **Repository**: Data access layer, currently implemented as an in-memory repository for groceries.

