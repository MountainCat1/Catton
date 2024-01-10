# Documentation for Accounts.Api

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://localhost*

| Class | Method | HTTP request | Description |
|------------ | ------------- | ------------- | -------------|
| *AccountApi* | [**apiAccountsIdGet**](Apis/AccountApi.md#apiaccountsidget) | **GET** /api/accounts/{id} |  |
|*AccountApi* | [**apiAccountsLoginPost**](Apis/AccountApi.md#apiaccountsloginpost) | **POST** /api/accounts/login |  |
|*AccountApi* | [**apiAccountsMeGet**](Apis/AccountApi.md#apiaccountsmeget) | **GET** /api/accounts/me |  |
|*AccountApi* | [**apiAccountsPost**](Apis/AccountApi.md#apiaccountspost) | **POST** /api/accounts |  |
| *ClaimsApi* | [**apiAccountsClaimsGet**](Apis/ClaimsApi.md#apiaccountsclaimsget) | **GET** /api/accounts/claims |  |


<a name="documentation-for-models"></a>
## Documentation for Models

 - [AccountDto](./Models/AccountDto.md)
 - [AuthTokenResponseContract](./Models/AuthTokenResponseContract.md)
 - [AuthViaPasswordRequestContract](./Models/AuthViaPasswordRequestContract.md)
 - [ClaimDto](./Models/ClaimDto.md)
 - [CreatePasswordAccountRequestContract](./Models/CreatePasswordAccountRequestContract.md)
 - [ErrorResponse](./Models/ErrorResponse.md)
 - [GetClaimsResponseDto](./Models/GetClaimsResponseDto.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="Bearer"></a>
### Bearer

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

