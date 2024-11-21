# BookExchange API

The BookExchange API is designed to facilitate the exchange of books between users. It allows users to create, update, and retrieve exchange requests, as well as look up various related data such as delivery methods, payment methods, and statuses. The API supports the following functionalities:

- **Creating Exchange Requests:** Users can create new exchange requests by specifying details such as the books to be exchanged, the users involved, the delivery method, the exchange duration, the payment method, and the status of the request.
- **Retrieving Exchange Requests:** Users can retrieve specific exchange requests by their ID or get a list of all exchange requests associated with a particular user.
- **Updating Exchange Requests:** Users can update existing exchange requests with new information.
- **Lookup Data:** The API provides endpoints to retrieve lookup data for delivery methods, payment methods, and statuses, which can be used to populate dropdowns or other UI elements in client applications.

This API is built using ASP.NET Core and targets .NET 8, ensuring modern and efficient performance.


## Table of Contents

- [Endpoints](#endpoints)
  - [LookupController](#lookupcontroller)
    - [GET /api/lookup/delivery-methods](#get-apilookupdelivery-methods)
    - [GET /api/lookup/payment-methods](#get-apilookuppayment-methods)
    - [GET /api/lookup/statuses](#get-apilookupstatuses)
  - [ExchangeRequestsController](#exchangerequestscontroller)
    - [POST /api/exchange-requests](#post-apiexchange-requests)
    - [GET /api/exchange-requests/{requestId}](#get-apiexchange-requestsrequestid)
    - [GET /api/exchange-requests](#get-apiexchange-requests)
    - [PUT /api/exchange-requests/{requestId}](#put-apiexchange-requestsrequestid)
- [Models](#models)
  - [CreateExchangeRequest](#createexchangerequest)
  - [UpdateExchangeRequest](#updateexchangerequest)
  - [ExchangeRequest](#exchangerequest)
  - [Lookup](#lookup)

## Endpoints

### LookupController

#### GET /api/lookup/delivery-methods

- **Request Model:** None
- **Response Model:**
  - `List<Lookup>`
    - `int Id`
    - `string Name`

#### GET /api/lookup/payment-methods

- **Request Model:** None
- **Response Model:**
  - `List<Lookup>`
    - `int Id`
    - `string Name`

#### GET /api/lookup/statuses

- **Request Model:** None
- **Response Model:**
  - `List<Lookup>`
    - `int Id`
    - `string Name`

### ExchangeRequestsController

#### POST /api/exchange-requests

- **Request Model:**
  - `CreateExchangeRequest`
    - `int RequestTypeId`
    - `string SenderBookId`
    - `string ReceiverBookId`
    - `string SenderUserId`
    - `string ReceiverUserId`
    - `int DeliveryMethodId`
    - `int ExchangeDuration`
    - `int PaymentMethodId`
    - `int StatusId`
- **Response Model:**
  - `ExchangeRequest`
    - `int RequestId`
    - `int RequestTypeId`
    - `string SenderBookId`
    - `string ReceiverBookId`
    - `string SenderUserId`
    - `string ReceiverUserId`
    - `int DeliveryMethodId`
    - `int ExchangeDuration`
    - `int PaymentMethodId`
    - `int StatusId`

#### GET /api/exchange-requests/{requestId}

- **Request Model:** None
- **Response Model:**
  - `ExchangeRequest`
    - `int RequestId`
    - `int RequestTypeId`
    - `string SenderBookId`
    - `string ReceiverBookId`
    - `string SenderUserId`
    - `string ReceiverUserId`
    - `int DeliveryMethodId`
    - `int ExchangeDuration`
    - `int PaymentMethodId`
    - `int StatusId`

#### GET /api/exchange-requests

- **Request Model:**
  - `int userId` (query parameter)
- **Response Model:**
  - `List<ExchangeRequest>`
    - `int RequestId`
    - `int RequestTypeId`
    - `string SenderBookId`
    - `string ReceiverBookId`
    - `string SenderUserId`
    - `string ReceiverUserId`
    - `int DeliveryMethodId`
    - `int ExchangeDuration`
    - `int PaymentMethodId`
    - `int StatusId`

#### PUT /api/exchange-requests/{requestId}

- **Request Model:**
  - `UpdateExchangeRequest`
    - `int RequestTypeId`
    - `string SenderBookId`
    - `string ReceiverBookId`
    - `string SenderUserId`
    - `string ReceiverUserId`
    - `int DeliveryMethodId`
    - `int ExchangeDuration`
    - `int PaymentMethodId`
    - `int StatusId`
- **Response Model:** None (No Content)

## Models

### CreateExchangeRequest

- `int RequestTypeId`
- `string SenderBookId`
- `string ReceiverBookId`
- `string SenderUserId`
- `string ReceiverUserId`
- `int DeliveryMethodId`
- `int ExchangeDuration`
- `int PaymentMethodId`
- `int StatusId`

### UpdateExchangeRequest

- Inherits from `CreateExchangeRequest`

### ExchangeRequest

- `int RequestId`
- `int RequestTypeId`
- `string SenderBookId`
- `string ReceiverBookId`
- `string SenderUserId`
- `string ReceiverUserId`
- `int DeliveryMethodId`
- `int ExchangeDuration`
- `int PaymentMethodId`
- `int StatusId`

### Lookup

- `int Id`
- `string Name`
