# Exception Handling in eg-shop-api

## Overview
This document explains the implementation of global exception handling in the `eg-shop-api` project.

## What Was Added
A global exception filter was introduced to catch and handle unhandled exceptions across all API controllers. This ensures that any unexpected errors are logged and a consistent error response is returned to the client.

### Files Added/Modified
- **WebApi/Filters/GlobalExceptionFilter.cs**: Implements a global exception filter using `IExceptionFilter`.
- **Program.cs**: Registers the global exception filter for all controllers.

## How It Works
- The `GlobalExceptionFilter` logs any unhandled exception and returns a generic error message with HTTP 500 status code.
- The filter is registered globally, so it applies to all API endpoints automatically.

## Example Error Response
```
{
  "Message": "An unexpected error occurred. Please try again later.",
  "Details": "<exception message>"
}
```

## Benefits
- Centralized error handling
- Consistent error responses
- Improved logging for debugging

## References
- [ASP.NET Core Exception Filters](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters#exception-filters)
