# \TicketTemplateAPI

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiConventionsConventionIdTicketTemplatesGet**](TicketTemplateAPI.md#ApiConventionsConventionIdTicketTemplatesGet) | **Get** /api/conventions/{conventionId}/ticket-templates | 
[**ApiConventionsConventionIdTicketTemplatesPost**](TicketTemplateAPI.md#ApiConventionsConventionIdTicketTemplatesPost) | **Post** /api/conventions/{conventionId}/ticket-templates | 
[**ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete**](TicketTemplateAPI.md#ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete) | **Delete** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} | 
[**ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet**](TicketTemplateAPI.md#ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet) | **Get** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} | 
[**ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut**](TicketTemplateAPI.md#ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut) | **Put** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} | 



## ApiConventionsConventionIdTicketTemplatesGet

> []TicketTemplateDto ApiConventionsConventionIdTicketTemplatesGet(ctx, conventionId).Execute()



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
    resp, r, err := apiClient.TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesGet(context.Background(), conventionId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketTemplatesGet`: []TicketTemplateDto
    fmt.Fprintf(os.Stdout, "Response from `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketTemplatesGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


### Return type

[**[]TicketTemplateDto**](TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdTicketTemplatesPost

> TicketTemplateDto ApiConventionsConventionIdTicketTemplatesPost(ctx, conventionId).TicketTemplateCreateDto(ticketTemplateCreateDto).Execute()



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
    ticketTemplateCreateDto := *openapiclient.NewTicketTemplateCreateDto() // TicketTemplateCreateDto |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesPost(context.Background(), conventionId).TicketTemplateCreateDto(ticketTemplateCreateDto).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesPost``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketTemplatesPost`: TicketTemplateDto
    fmt.Fprintf(os.Stdout, "Response from `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesPost`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketTemplatesPostRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------

 **ticketTemplateCreateDto** | [**TicketTemplateCreateDto**](TicketTemplateCreateDto.md) |  | 

### Return type

[**TicketTemplateDto**](TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete

> TicketTemplateDto ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete(ctx, conventionId, ticketTemplateId).Execute()



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
    ticketTemplateId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete(context.Background(), conventionId, ticketTemplateId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete`: TicketTemplateDto
    fmt.Fprintf(os.Stdout, "Response from `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**ticketTemplateId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**TicketTemplateDto**](TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet

> TicketTemplateDto ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet(ctx, conventionId, ticketTemplateId).Execute()



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
    ticketTemplateId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet(context.Background(), conventionId, ticketTemplateId).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet`: TicketTemplateDto
    fmt.Fprintf(os.Stdout, "Response from `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**ticketTemplateId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------



### Return type

[**TicketTemplateDto**](TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut

> TicketTemplateDto ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut(ctx, conventionId, ticketTemplateId).TicketTemplateUpdateDto(ticketTemplateUpdateDto).Execute()



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
    ticketTemplateId := "38400000-8cf0-11bd-b23e-10b96e4ef00d" // string | 
    ticketTemplateUpdateDto := *openapiclient.NewTicketTemplateUpdateDto() // TicketTemplateUpdateDto |  (optional)

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut(context.Background(), conventionId, ticketTemplateId).TicketTemplateUpdateDto(ticketTemplateUpdateDto).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut`: TicketTemplateDto
    fmt.Fprintf(os.Stdout, "Response from `TicketTemplateAPI.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut`: %v\n", resp)
}
```

### Path Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**ctx** | **context.Context** | context for authentication, logging, cancellation, deadlines, tracing, etc.
**conventionId** | **string** |  | 
**ticketTemplateId** | **string** |  | 

### Other Parameters

Other parameters are passed through a pointer to a apiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------


 **ticketTemplateUpdateDto** | [**TicketTemplateUpdateDto**](TicketTemplateUpdateDto.md) |  | 

### Return type

[**TicketTemplateDto**](TicketTemplateDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

