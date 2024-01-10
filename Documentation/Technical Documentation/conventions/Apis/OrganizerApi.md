# OrganizerApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**apiConventionsConventionIdOrganizersGet**](OrganizerApi.md#apiConventionsConventionIdOrganizersGet) | **GET** /api/conventions/{conventionId}/organizers |  |
| [**apiConventionsConventionIdOrganizersOrganizerIdDelete**](OrganizerApi.md#apiConventionsConventionIdOrganizersOrganizerIdDelete) | **DELETE** /api/conventions/{conventionId}/organizers/{organizerId} |  |
| [**apiConventionsConventionIdOrganizersOrganizerIdGet**](OrganizerApi.md#apiConventionsConventionIdOrganizersOrganizerIdGet) | **GET** /api/conventions/{conventionId}/organizers/{organizerId} |  |
| [**apiConventionsConventionIdOrganizersOrganizerIdPut**](OrganizerApi.md#apiConventionsConventionIdOrganizersOrganizerIdPut) | **PUT** /api/conventions/{conventionId}/organizers/{organizerId} |  |
| [**apiConventionsConventionIdOrganizersPost**](OrganizerApi.md#apiConventionsConventionIdOrganizersPost) | **POST** /api/conventions/{conventionId}/organizers |  |


<a name="apiConventionsConventionIdOrganizersGet"></a>
# **apiConventionsConventionIdOrganizersGet**
> List apiConventionsConventionIdOrganizersGet(conventionId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |

### Return type

[**List**](../Models/OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdOrganizersOrganizerIdDelete"></a>
# **apiConventionsConventionIdOrganizersOrganizerIdDelete**
> OrganizerDto apiConventionsConventionIdOrganizersOrganizerIdDelete(conventionId, organizerId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **organizerId** | **UUID**|  | [default to null] |

### Return type

[**OrganizerDto**](../Models/OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdOrganizersOrganizerIdGet"></a>
# **apiConventionsConventionIdOrganizersOrganizerIdGet**
> OrganizerDto apiConventionsConventionIdOrganizersOrganizerIdGet(conventionId, organizerId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **organizerId** | **UUID**|  | [default to null] |

### Return type

[**OrganizerDto**](../Models/OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdOrganizersOrganizerIdPut"></a>
# **apiConventionsConventionIdOrganizersOrganizerIdPut**
> OrganizerDto apiConventionsConventionIdOrganizersOrganizerIdPut(conventionId, organizerId, OrganizerUpdateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **organizerId** | **UUID**|  | [default to null] |
| **OrganizerUpdateDto** | [**OrganizerUpdateDto**](../Models/OrganizerUpdateDto.md)|  | [optional] |

### Return type

[**OrganizerDto**](../Models/OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdOrganizersPost"></a>
# **apiConventionsConventionIdOrganizersPost**
> OrganizerDto apiConventionsConventionIdOrganizersPost(conventionId, OrganizerCreateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **OrganizerCreateDto** | [**OrganizerCreateDto**](../Models/OrganizerCreateDto.md)|  | [optional] |

### Return type

[**OrganizerDto**](../Models/OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

