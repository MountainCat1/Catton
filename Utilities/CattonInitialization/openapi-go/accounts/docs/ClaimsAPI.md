# \ClaimsAPI

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAccountsClaimsGet**](ClaimsAPI.md#ApiAccountsClaimsGet) | **Get** /api/accounts/claims | 



## ApiAccountsClaimsGet

> GetClaimsResponseDto ApiAccountsClaimsGet(ctx).Execute()



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

    configuration := openapiclient.NewConfiguration()
    apiClient := openapiclient.NewAPIClient(configuration)
    resp, r, err := apiClient.ClaimsAPI.ApiAccountsClaimsGet(context.Background()).Execute()
    if err != nil {
        fmt.Fprintf(os.Stderr, "Error when calling `ClaimsAPI.ApiAccountsClaimsGet``: %v\n", err)
        fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
    }
    // response from `ApiAccountsClaimsGet`: GetClaimsResponseDto
    fmt.Fprintf(os.Stdout, "Response from `ClaimsAPI.ApiAccountsClaimsGet`: %v\n", resp)
}
```

### Path Parameters

This endpoint does not need any parameter.

### Other Parameters

Other parameters are passed through a pointer to a apiApiAccountsClaimsGetRequest struct via the builder pattern


### Return type

[**GetClaimsResponseDto**](GetClaimsResponseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

