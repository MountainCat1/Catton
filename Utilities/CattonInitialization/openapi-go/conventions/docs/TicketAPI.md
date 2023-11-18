# \TicketAPI

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet**](TicketAPI.md#ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet) | **Get** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets | 
[**ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost**](TicketAPI.md#ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost) | **Post** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets | 
[**ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete**](TicketAPI.md#ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete) | **Delete** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets/{ticketId} | 
[**ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut**](TicketAPI.md#ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut) | **Put** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets/{ticketId} | 
[**ApiConventionsConventionIdTicketsGet**](TicketAPI.md#ApiConventionsConventionIdTicketsGet) | **Get** /api/conventions/{conventionId}/tickets | 
[**ApiConventionsConventionIdTicketsTicketIdGet**](TicketAPI.md#ApiConventionsConventionIdTicketsTicketIdGet) | **Get** /api/conventions/{conventionId}/tickets/{ticketId} | 



## ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet

> TicketDto ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet(ctx, conventionId, attendeeId).Execute()



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
    attendeeId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet(context.Background(), conventionId, attendeeId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet`: TicketDto
    fmt.Fprintf(os.Stdout, "Response from `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**attendeeId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesAttendeeIdTicketsGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**TicketDto**](TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost

> TicketDto ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost(ctx, conventionId, attendeeId).TicketCreateDto(ticketCreateDto).Execute()



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
    attendeeId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 
    ticketCreateDto := *openapiclient.NewTicketCreateDto() // TicketCreateDto |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost(context.Background(), conventionId, attendeeId).TicketCreateDto(ticketCreateDto).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost`: TicketDto
    fmt.Fprintf(os.Stdout, "Response from `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsPost`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**attendeeId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesAttendeeIdTicketsPostRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


 **ticketCreateDto** | [**TicketCreateDto**](TicketCreateDto.md) |  | 

### Return type

[**TicketDto**](TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete

> TicketDto ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete(ctx, conventionId, ticketId, attendeeId).Execute()



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
    ticketId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 
    attendeeId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete(context.Background(), conventionId, ticketId, attendeeId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete`: TicketDto
    fmt.Fprintf(os.Stdout, "Response from `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**ticketId** | **string** |  | 
**attendeeId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDeleteRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------




### Return type

[**TicketDto**](TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut

> TicketDto ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut(ctx, conventionId, ticketId, attendeeId).Body(body).Execute()



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
    ticketId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 
    attendeeId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 
    body := map[string]interface{}{ ... } // map[string]interface{} |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut(context.Background(), conventionId, ticketId, attendeeId).Body(body).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut`: TicketDto
    fmt.Fprintf(os.Stdout, "Response from `TicketAPI.ApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**ticketId** | **string** |  | 
**attendeeId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPutRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



 **body** | **map[string]interface{}** |  | 

### Return type

[**TicketDto**](TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdTicketsGet

> []TicketDto ApiConventionsConventionIdTicketsGet(ctx, conventionId).Execute()



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
    resp, r, err := apiClient.TicketAPI.ApiConventionsConventionIdTicketsGet(context.Background(), conventionId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketAPI.ApiConventionsConventionIdTicketsGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketsGet`: []TicketDto
    fmt.Fprintf(os.Stdout, "Response from `TicketAPI.ApiConventionsConventionIdTicketsGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketsGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


### Return type

[**[]TicketDto**](TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdTicketsTicketIdGet

> TicketDto ApiConventionsConventionIdTicketsTicketIdGet(ctx, conventionId, ticketId).Execute()



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
    ticketId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketAPI.ApiConventionsConventionIdTicketsTicketIdGet(context.Background(), conventionId, ticketId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketAPI.ApiConventionsConventionIdTicketsTicketIdGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketsTicketIdGet`: TicketDto
    fmt.Fprintf(os.Stdout, "Response from `TicketAPI.ApiConventionsConventionIdTicketsTicketIdGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**ticketId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketsTicketIdGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**TicketDto**](TicketDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

