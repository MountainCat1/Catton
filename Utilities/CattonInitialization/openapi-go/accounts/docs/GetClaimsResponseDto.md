# GetClaimsResponseDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Claims** | Pointer to [**[]ClaimDto**](ClaimDto.md) |  | [optional] 

## Methods

### NewGetClaimsResponseDto

`func NewGetClaimsResponseDto() *GetClaimsResponseDto`

NewGetClaimsResponseDto instantiates a new GetClaimsResponseDto object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewGetClaimsResponseDtoWithDefaults

`func NewGetClaimsResponseDtoWithDefaults() *GetClaimsResponseDto`

NewGetClaimsResponseDtoWithDefaults instantiates a new GetClaimsResponseDto object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetClaims

`func (o *GetClaimsResponseDto) GetClaims() []ClaimDto`

GetClaims returns the Claims field if non-nil, zero value otherwise.

### GetClaimsOk

`func (o *GetClaimsResponseDto) GetClaimsOk() (*[]ClaimDto, bool)`

GetClaimsOk returns a tuple with the Claims field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetClaims

`func (o *GetClaimsResponseDto) SetClaims(v []ClaimDto)`

SetClaims sets Claims field to given value.

### HasClaims

`func (o *GetClaimsResponseDto) HasClaims() bool`

HasClaims returns a boolean if a field has been set.

### SetClaimsNil

`func (o *GetClaimsResponseDto) SetClaimsNil(b bool)`

 SetClaimsNil sets the value for Claims to be an explicit nil

### UnsetClaims
`func (o *GetClaimsResponseDto) UnsetClaims()`

UnsetClaims ensures that no value is present for Claims, not even an explicit nil

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


