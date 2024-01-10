# TicketApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**apiConventionsConventionIdAttendeesAttendeeIdTicketsGet**](TicketApi.md#apiConventionsConventionIdAttendeesAttendeeIdTicketsGet) | **GET** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets |  |
| [**apiConventionsConventionIdAttendeesAttendeeIdTicketsPost**](TicketApi.md#apiConventionsConventionIdAttendeesAttendeeIdTicketsPost) | **POST** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets |  |
| [**apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete**](TicketApi.md#apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete) | **DELETE** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets/{ticketId} |  |
| [**apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut**](TicketApi.md#apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut) | **PUT** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets/{ticketId} |  |
| [**apiConventionsConventionIdTicketsGet**](TicketApi.md#apiConventionsConventionIdTicketsGet) | **GET** /api/conventions/{conventionId}/tickets |  |
| [**apiConventionsConventionIdTicketsTicketIdGet**](TicketApi.md#apiConventionsConventionIdTicketsTicketIdGet) | **GET** /api/conventions/{conventionId}/tickets/{ticketId} |  |


<a name="apiConventionsConventionIdAttendeesAttendeeIdTicketsGet"></a>
# **apiConventionsConventionIdAttendeesAttendeeIdTicketsGet**
> TicketDto apiConventionsConventionIdAttendeesAttendeeIdTicketsGet(conventionId, attendeeId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **attendeeId** | **UUID**|  | [default to null] |

### Return type

[**TicketDto**](../Models/TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesAttendeeIdTicketsPost"></a>
# **apiConventionsConventionIdAttendeesAttendeeIdTicketsPost**
> TicketDto apiConventionsConventionIdAttendeesAttendeeIdTicketsPost(conventionId, attendeeId, TicketCreateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **attendeeId** | **UUID**|  | [default to null] |
| **TicketCreateDto** | [**TicketCreateDto**](../Models/TicketCreateDto.md)|  | [optional] |

### Return type

[**TicketDto**](../Models/TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete"></a>
# **apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete**
> TicketDto apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete(conventionId, ticketId, attendeeId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **ticketId** | **UUID**|  | [default to null] |
| **attendeeId** | **UUID**|  | [default to null] |

### Return type

[**TicketDto**](../Models/TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut"></a>
# **apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut**
> TicketDto apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut(conventionId, ticketId, attendeeId, body)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **ticketId** | **UUID**|  | [default to null] |
| **attendeeId** | **UUID**|  | [default to null] |
| **body** | **Object**|  | [optional] |

### Return type

[**TicketDto**](../Models/TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdTicketsGet"></a>
# **apiConventionsConventionIdTicketsGet**
> List apiConventionsConventionIdTicketsGet(conventionId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |

### Return type

[**List**](../Models/TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdTicketsTicketIdGet"></a>
# **apiConventionsConventionIdTicketsTicketIdGet**
> TicketDto apiConventionsConventionIdTicketsTicketIdGet(conventionId, ticketId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **ticketId** | **UUID**|  | [default to null] |

### Return type

[**TicketDto**](../Models/TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

