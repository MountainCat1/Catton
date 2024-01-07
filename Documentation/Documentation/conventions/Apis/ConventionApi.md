# ConventionApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**apiConventionsGet**](ConventionApi.md#apiConventionsGet) | **GET** /api/conventions |  |
| [**apiConventionsIdGet**](ConventionApi.md#apiConventionsIdGet) | **GET** /api/conventions/{id} |  |
| [**apiConventionsIdPut**](ConventionApi.md#apiConventionsIdPut) | **PUT** /api/conventions/{id} |  |
| [**apiConventionsPost**](ConventionApi.md#apiConventionsPost) | **POST** /api/conventions |  |


<a name="apiConventionsGet"></a>
# **apiConventionsGet**
> List apiConventionsGet()



### Parameters
This endpoint does not need any parameter.

### Return type

[**List**](../Models/ConventionDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsIdGet"></a>
# **apiConventionsIdGet**
> ConventionDto apiConventionsIdGet(id)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **id** | **String**|  | [default to null] |

### Return type

[**ConventionDto**](../Models/ConventionDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsIdPut"></a>
# **apiConventionsIdPut**
> apiConventionsIdPut(id, ConventionUpdateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **id** | **String**|  | [default to null] |
| **ConventionUpdateDto** | [**ConventionUpdateDto**](../Models/ConventionUpdateDto.md)|  | [optional] |

### Return type

null (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsPost"></a>
# **apiConventionsPost**
> ConventionDto apiConventionsPost(ConventionCreateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **ConventionCreateDto** | [**ConventionCreateDto**](../Models/ConventionCreateDto.md)|  | [optional] |

### Return type

[**ConventionDto**](../Models/ConventionDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

