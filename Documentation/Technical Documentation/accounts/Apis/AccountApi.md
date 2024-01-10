# AccountApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|------------- | ------------- | -------------|
| [**apiAccountsIdGet**](AccountApi.md#apiAccountsIdGet) | **GET** /api/accounts/{id} |  |
| [**apiAccountsLoginPost**](AccountApi.md#apiAccountsLoginPost) | **POST** /api/accounts/login |  |
| [**apiAccountsMeGet**](AccountApi.md#apiAccountsMeGet) | **GET** /api/accounts/me |  |
| [**apiAccountsPost**](AccountApi.md#apiAccountsPost) | **POST** /api/accounts |  |


<a name="apiAccountsIdGet"></a>
# **apiAccountsIdGet**
> AccountDto apiAccountsIdGet(id)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **id** | **UUID**|  | [default to null] |

### Return type

[**AccountDto**](../Models/AccountDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiAccountsLoginPost"></a>
# **apiAccountsLoginPost**
> AuthTokenResponseContract apiAccountsLoginPost(AuthViaPasswordRequestContract)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **AuthViaPasswordRequestContract** | [**AuthViaPasswordRequestContract**](../Models/AuthViaPasswordRequestContract.md)|  | [optional] |

### Return type

[**AuthTokenResponseContract**](../Models/AuthTokenResponseContract.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

<a name="apiAccountsMeGet"></a>
# **apiAccountsMeGet**
> AccountDto apiAccountsMeGet()



### Parameters
This endpoint does not need any parameter.

### Return type

[**AccountDto**](../Models/AccountDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

<a name="apiAccountsPost"></a>
# **apiAccountsPost**
> apiAccountsPost(CreatePasswordAccountRequestContract)



### Parameters

|Name | Type | Description  | Notes |
|------------- | ------------- | ------------- | -------------|
| **CreatePasswordAccountRequestContract** | [**CreatePasswordAccountRequestContract**](../Models/CreatePasswordAccountRequestContract.md)|  | [optional] |

### Return type

null (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

