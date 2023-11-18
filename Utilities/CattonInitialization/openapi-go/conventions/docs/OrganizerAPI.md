# \OrganizerAPI

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiConventionsConventionIdOrganizersGet**](OrganizerAPI.md#ApiConventionsConventionIdOrganizersGet) | **Get** /api/conventions/{conventionId}/organizers | 
[**ApiConventionsConventionIdOrganizersOrganizerIdDelete**](OrganizerAPI.md#ApiConventionsConventionIdOrganizersOrganizerIdDelete) | **Delete** /api/conventions/{conventionId}/organizers/{organizerId} | 
[**ApiConventionsConventionIdOrganizersOrganizerIdGet**](OrganizerAPI.md#ApiConventionsConventionIdOrganizersOrganizerIdGet) | **Get** /api/conventions/{conventionId}/organizers/{organizerId} | 
[**ApiConventionsConventionIdOrganizersOrganizerIdPut**](OrganizerAPI.md#ApiConventionsConventionIdOrganizersOrganizerIdPut) | **Put** /api/conventions/{conventionId}/organizers/{organizerId} | 
[**ApiConventionsConventionIdOrganizersPost**](OrganizerAPI.md#ApiConventionsConventionIdOrganizersPost) | **Post** /api/conventions/{conventionId}/organizers | 



## ApiConventionsConventionIdOrganizersGet

> []OrganizerDto ApiConventionsConventionIdOrganizersGet(ctx, conventionId).Execute()



### Example

```go
package main

import (
    "context"
    "fmt"
    "os"
    openapiclient "github.com/GIT_USER_ID/GIT_REPO_ID"
)

func main() {
    conventionId := "conventionId_example" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.OrganizerAPI.ApiConventionsConventionIdOrganizersGet(context.Background(), conventionId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `OrganizerAPI.ApiConventionsConventionIdOrganizersGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdOrganizersGet`: []OrganizerDto
    fmt.Fprintf(os.Stdout, "Response from `OrganizerAPI.ApiConventionsConventionIdOrganizersGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdOrganizersGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


### Return type

[**[]OrganizerDto**](OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdOrganizersOrganizerIdDelete

> OrganizerDto ApiConventionsConventionIdOrganizersOrganizerIdDelete(ctx, conventionId, organizerId).Execute()



### Example

```go
package main

import (
    "context"
    "fmt"
    "os"
    openapiclient "github.com/GIT_USER_ID/GIT_REPO_ID"
)

func main() {
    conventionId := "conventionId_example" // string | 
    organizerId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdDelete(context.Background(), conventionId, organizerId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdDelete``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdOrganizersOrganizerIdDelete`: OrganizerDto
    fmt.Fprintf(os.Stdout, "Response from `OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdDelete`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**organizerId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdOrganizersOrganizerIdDeleteRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**OrganizerDto**](OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdOrganizersOrganizerIdGet

> OrganizerDto ApiConventionsConventionIdOrganizersOrganizerIdGet(ctx, conventionId, organizerId).Execute()



### Example

```go
package main

import (
    "context"
    "fmt"
    "os"
    openapiclient "github.com/GIT_USER_ID/GIT_REPO_ID"
)

func main() {
    conventionId := "conventionId_example" // string | 
    organizerId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdGet(context.Background(), conventionId, organizerId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdOrganizersOrganizerIdGet`: OrganizerDto
    fmt.Fprintf(os.Stdout, "Response from `OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**organizerId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdOrganizersOrganizerIdGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**OrganizerDto**](OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdOrganizersOrganizerIdPut

> OrganizerDto ApiConventionsConventionIdOrganizersOrganizerIdPut(ctx, conventionId, organizerId).OrganizerUpdateDto(organizerUpdateDto).Execute()



### Example

```go
package main

import (
    "context"
    "fmt"
    "os"
    openapiclient "github.com/GIT_USER_ID/GIT_REPO_ID"
)

func main() {
    conventionId := "conventionId_example" // string | 
    organizerId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 
    organizerUpdateDto := *openapiclient.NewOrganizerUpdateDto() // OrganizerUpdateDto |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdPut(context.Background(), conventionId, organizerId).OrganizerUpdateDto(organizerUpdateDto).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdPut``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdOrganizersOrganizerIdPut`: OrganizerDto
    fmt.Fprintf(os.Stdout, "Response from `OrganizerAPI.ApiConventionsConventionIdOrganizersOrganizerIdPut`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**organizerId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdOrganizersOrganizerIdPutRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


 **organizerUpdateDto** | [**OrganizerUpdateDto**](OrganizerUpdateDto.md) |  | 

### Return type

[**OrganizerDto**](OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdOrganizersPost

> OrganizerDto ApiConventionsConventionIdOrganizersPost(ctx, conventionId).OrganizerCreateDto(organizerCreateDto).Execute()



### Example

```go
package main

import (
    "context"
    "fmt"
    "os"
    openapiclient "github.com/GIT_USER_ID/GIT_REPO_ID"
)

func main() {
    conventionId := "conventionId_example" // string | 
    organizerCreateDto := *openapiclient.NewOrganizerCreateDto() // OrganizerCreateDto |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.OrganizerAPI.ApiConventionsConventionIdOrganizersPost(context.Background(), conventionId).OrganizerCreateDto(organizerCreateDto).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `OrganizerAPI.ApiConventionsConventionIdOrganizersPost``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdOrganizersPost`: OrganizerDto
    fmt.Fprintf(os.Stdout, "Response from `OrganizerAPI.ApiConventionsConventionIdOrganizersPost`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdOrganizersPostRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------

 **organizerCreateDto** | [**OrganizerCreateDto**](OrganizerCreateDto.md) |  | 

### Return type

[**OrganizerDto**](OrganizerDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

