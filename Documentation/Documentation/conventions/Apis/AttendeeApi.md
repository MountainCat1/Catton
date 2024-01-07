# AttendeeApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**apiConventionsConventionIdAttendeesAccountIdDelete**](AttendeeApi.md#apiConventionsConventionIdAttendeesAccountIdDelete) | **DELETE** /api/conventions/{conventionId}/attendees/{accountId} |  |
| [**apiConventionsConventionIdAttendeesAccountIdGet**](AttendeeApi.md#apiConventionsConventionIdAttendeesAccountIdGet) | **GET** /api/conventions/{conventionId}/attendees/{accountId} |  |
| [**apiConventionsConventionIdAttendeesGet**](AttendeeApi.md#apiConventionsConventionIdAttendeesGet) | **GET** /api/conventions/{conventionId}/attendees |  |
| [**apiConventionsConventionIdAttendeesMePost**](AttendeeApi.md#apiConventionsConventionIdAttendeesMePost) | **POST** /api/conventions/{conventionId}/attendees/me |  |
| [**apiConventionsConventionIdAttendeesPost**](AttendeeApi.md#apiConventionsConventionIdAttendeesPost) | **POST** /api/conventions/{conventionId}/attendees |  |


<a name="apiConventionsConventionIdAttendeesAccountIdDelete"></a>
# **apiConventionsConventionIdAttendeesAccountIdDelete**
> AttendeeDto apiConventionsConventionIdAttendeesAccountIdDelete(conventionId, accountId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **accountId** | **UUID**|  | [default to null] |

### Return type

[**AttendeeDto**](../Models/AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesAccountIdGet"></a>
# **apiConventionsConventionIdAttendeesAccountIdGet**
> AttendeeDto apiConventionsConventionIdAttendeesAccountIdGet(conventionId, accountId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **accountId** | **UUID**|  | [default to null] |

### Return type

[**AttendeeDto**](../Models/AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesGet"></a>
# **apiConventionsConventionIdAttendeesGet**
> List apiConventionsConventionIdAttendeesGet(conventionId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |

### Return type

[**List**](../Models/AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesMePost"></a>
# **apiConventionsConventionIdAttendeesMePost**
> AttendeeDto apiConventionsConventionIdAttendeesMePost(conventionId)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |

### Return type

[**AttendeeDto**](../Models/AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiConventionsConventionIdAttendeesPost"></a>
# **apiConventionsConventionIdAttendeesPost**
> AttendeeDto apiConventionsConventionIdAttendeesPost(conventionId, AttendeeCreateDto)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **conventionId** | **String**|  | [default to null] |
| **AttendeeCreateDto** | [**AttendeeCreateDto**](../Models/AttendeeCreateDto.md)|  | [optional] |

### Return type

[**AttendeeDto**](../Models/AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

