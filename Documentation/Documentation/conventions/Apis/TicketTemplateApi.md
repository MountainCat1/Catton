# TicketTemplateApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**apiConventionsConventionIdTicketTemplatesGet**](TicketTemplateApi.md#apiConventionsConventionIdTicketTemplatesGet) | **GET** /api/conventions/{conventionId}/ticket-templates |  |
| [**apiConventionsConventionIdTicketTemplatesPost**](TicketTemplateApi.md#apiConventionsConventionIdTicketTemplatesPost) | **POST** /api/conventions/{conventionId}/ticket-templates |  |
| [**apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete**](TicketTemplateApi.md#apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete) | **DELETE** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} |  |
| [**apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet**](TicketTemplateApi.md#apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet) | **GET** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} |  |
| [**apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut**](TicketTemplateApi.md#apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut) | **PUT** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} |  |


<a name="apiConventionsConventionIdTicketTemplatesGet"></a>
# **apiConventionsConventionIdTicketTemplatesGet**
> List apiConventionsConventionIdTicketTemplatesGet(conventionId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |

### Return type

[**List**](../Models/TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdTicketTemplatesPost"></a>
# **apiConventionsConventionIdTicketTemplatesPost**
> TicketTemplateDto apiConventionsConventionIdTicketTemplatesPost(conventionId, TicketTemplateCreateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **TicketTemplateCreateDto** | [**TicketTemplateCreateDto**](../Models/TicketTemplateCreateDto.md)|  | [optional] |

### Return type

[**TicketTemplateDto**](../Models/TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete"></a>
# **apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete**
> TicketTemplateDto apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete(conventionId, ticketTemplateId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **ticketTemplateId** | **UUID**|  | [default to null] |

### Return type

[**TicketTemplateDto**](../Models/TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet"></a>
# **apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet**
> TicketTemplateDto apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet(conventionId, ticketTemplateId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **ticketTemplateId** | **UUID**|  | [default to null] |

### Return type

[**TicketTemplateDto**](../Models/TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut"></a>
# **apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut**
> TicketTemplateDto apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut(conventionId, ticketTemplateId, TicketTemplateUpdateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **ticketTemplateId** | **UUID**|  | [default to null] |
| **TicketTemplateUpdateDto** | [**TicketTemplateUpdateDto**](../Models/TicketTemplateUpdateDto.md)|  | [optional] |

### Return type

[**TicketTemplateDto**](../Models/TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

