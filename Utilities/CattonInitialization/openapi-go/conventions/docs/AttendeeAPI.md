# \AttendeeAPI

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiConventionsConventionIdAttendeesAccountIdDelete**](AttendeeAPI.md#ApiConventionsConventionIdAttendeesAccountIdDelete) | **Delete** /api/conventions/{conventionId}/attendees/{accountId} | 
[**ApiConventionsConventionIdAttendeesAccountIdGet**](AttendeeAPI.md#ApiConventionsConventionIdAttendeesAccountIdGet) | **Get** /api/conventions/{conventionId}/attendees/{accountId} | 
[**ApiConventionsConventionIdAttendeesGet**](AttendeeAPI.md#ApiConventionsConventionIdAttendeesGet) | **Get** /api/conventions/{conventionId}/attendees | 
[**ApiConventionsConventionIdAttendeesMePost**](AttendeeAPI.md#ApiConventionsConventionIdAttendeesMePost) | **Post** /api/conventions/{conventionId}/attendees/me | 
[**ApiConventionsConventionIdAttendeesPost**](AttendeeAPI.md#ApiConventionsConventionIdAttendeesPost) | **Post** /api/conventions/{conventionId}/attendees | 



## ApiConventionsConventionIdAttendeesAccountIdDelete

> AttendeeDto ApiConventionsConventionIdAttendeesAccountIdDelete(ctx, conventionId, accountId).Execute()



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
    accountId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.AttendeeAPI.ApiConventionsConventionIdAttendeesAccountIdDelete(context.Background(), conventionId, accountId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `AttendeeAPI.ApiConventionsConventionIdAttendeesAccountIdDelete``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesAccountIdDelete`: AttendeeDto
    fmt.Fprintf(os.Stdout, "Response from `AttendeeAPI.ApiConventionsConventionIdAttendeesAccountIdDelete`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**accountId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesAccountIdDeleteRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**AttendeeDto**](AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesAccountIdGet

> AttendeeDto ApiConventionsConventionIdAttendeesAccountIdGet(ctx, conventionId, accountId).Execute()



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
    accountId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.AttendeeAPI.ApiConventionsConventionIdAttendeesAccountIdGet(context.Background(), conventionId, accountId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `AttendeeAPI.ApiConventionsConventionIdAttendeesAccountIdGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesAccountIdGet`: AttendeeDto
    fmt.Fprintf(os.Stdout, "Response from `AttendeeAPI.ApiConventionsConventionIdAttendeesAccountIdGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**accountId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesAccountIdGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**AttendeeDto**](AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesGet

> []AttendeeDto ApiConventionsConventionIdAttendeesGet(ctx, conventionId).Execute()



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
    resp, r, err := apiClient.AttendeeAPI.ApiConventionsConventionIdAttendeesGet(context.Background(), conventionId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `AttendeeAPI.ApiConventionsConventionIdAttendeesGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesGet`: []AttendeeDto
    fmt.Fprintf(os.Stdout, "Response from `AttendeeAPI.ApiConventionsConventionIdAttendeesGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


### Return type

[**[]AttendeeDto**](AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesMePost

> AttendeeDto ApiConventionsConventionIdAttendeesMePost(ctx, conventionId).Execute()



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
    resp, r, err := apiClient.AttendeeAPI.ApiConventionsConventionIdAttendeesMePost(context.Background(), conventionId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `AttendeeAPI.ApiConventionsConventionIdAttendeesMePost``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesMePost`: AttendeeDto
    fmt.Fprintf(os.Stdout, "Response from `AttendeeAPI.ApiConventionsConventionIdAttendeesMePost`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesMePostRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


### Return type

[**AttendeeDto**](AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesPost

> AttendeeDto ApiConventionsConventionIdAttendeesPost(ctx, conventionId).AttendeeCreateDto(attendeeCreateDto).Execute()



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
    attendeeCreateDto := *openapiclient.NewAttendeeCreateDto() // AttendeeCreateDto |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.AttendeeAPI.ApiConventionsConventionIdAttendeesPost(context.Background(), conventionId).AttendeeCreateDto(attendeeCreateDto).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `AttendeeAPI.ApiConventionsConventionIdAttendeesPost``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesPost`: AttendeeDto
    fmt.Fprintf(os.Stdout, "Response from `AttendeeAPI.ApiConventionsConventionIdAttendeesPost`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesPostRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------

 **attendeeCreateDto** | [**AttendeeCreateDto**](AttendeeCreateDto.md) |  | 

### Return type

[**AttendeeDto**](AttendeeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

