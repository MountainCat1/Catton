# AttendeeDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | Pointer to **string** |  | [optional] 
**ConventionId** | Pointer to **NullableString** |  | [optional] 
**CreatedDate** | Pointer to **time.Time** |  | [optional] 
**AccountUsername** | Pointer to **NullableString** |  | [optional] 
**AccountAvatarUri** | Pointer to **NullableString** |  | [optional] 

## Methods

### NewAttendeeDto

`func NewAttendeeDto() *AttendeeDto`

NewAttendeeDto instantiates a new AttendeeDto object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewAttendeeDtoWithDefaults

`func NewAttendeeDtoWithDefaults() *AttendeeDto`

NewAttendeeDtoWithDefaults instantiates a new AttendeeDto object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetAccountId

`func (o *AttendeeDto) GetAccountId() string`

GetAccountId returns the AccountId field if non-nil, zero value otherwise.

### GetAccountIdOk

`func (o *AttendeeDto) GetAccountIdOk() (*string, bool)`

GetAccountIdOk returns a tuple with the AccountId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAccountId

`func (o *AttendeeDto) SetAccountId(v string)`

SetAccountId sets AccountId field to given value.

### HasAccountId

`func (o *AttendeeDto) HasAccountId() bool`

HasAccountId returns a boolean if a field has been set.

### GetConventionId

`func (o *AttendeeDto) GetConventionId() string`

GetConventionId returns the ConventionId field if non-nil, zero value otherwise.

### GetConventionIdOk

`func (o *AttendeeDto) GetConventionIdOk() (*string, bool)`

GetConventionIdOk returns a tuple with the ConventionId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetConventionId

`func (o *AttendeeDto) SetConventionId(v string)`

SetConventionId sets ConventionId field to given value.

### HasConventionId

`func (o *AttendeeDto) HasConventionId() bool`

HasConventionId returns a boolean if a field has been set.

### SetConventionIdNil

`func (o *AttendeeDto) SetConventionIdNil(b bool)`

 SetConventionIdNil sets the value for ConventionId to be an explicit nil

### UnsetConventionId
`func (o *AttendeeDto) UnsetConventionId()`

UnsetConventionId ensures that no value is present for ConventionId, not even an explicit nil
### GetCreatedDate

`func (o *AttendeeDto) GetCreatedDate() time.Time`

GetCreatedDate returns the CreatedDate field if non-nil, zero value otherwise.

### GetCreatedDateOk

`func (o *AttendeeDto) GetCreatedDateOk() (*time.Time, bool)`

GetCreatedDateOk returns a tuple with the CreatedDate field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetCreatedDate

`func (o *AttendeeDto) SetCreatedDate(v time.Time)`

SetCreatedDate sets CreatedDate field to given value.

### HasCreatedDate

`func (o *AttendeeDto) HasCreatedDate() bool`

HasCreatedDate returns a boolean if a field has been set.

### GetAccountUsername

`func (o *AttendeeDto) GetAccountUsername() string`

GetAccountUsername returns the AccountUsername field if non-nil, zero value otherwise.

### GetAccountUsernameOk

`func (o *AttendeeDto) GetAccountUsernameOk() (*string, bool)`

GetAccountUsernameOk returns a tuple with the AccountUsername field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAccountUsername

`func (o *AttendeeDto) SetAccountUsername(v string)`

SetAccountUsername sets AccountUsername field to given value.

### HasAccountUsername

`func (o *AttendeeDto) HasAccountUsername() bool`

HasAccountUsername returns a boolean if a field has been set.

### SetAccountUsernameNil

`func (o *AttendeeDto) SetAccountUsernameNil(b bool)`

 SetAccountUsernameNil sets the value for AccountUsername to be an explicit nil

### UnsetAccountUsername
`func (o *AttendeeDto) UnsetAccountUsername()`

UnsetAccountUsername ensures that no value is present for AccountUsername, not even an explicit nil
### GetAccountAvatarUri

`func (o *AttendeeDto) GetAccountAvatarUri() string`

GetAccountAvatarUri returns the AccountAvatarUri field if non-nil, zero value otherwise.

### GetAccountAvatarUriOk

`func (o *AttendeeDto) GetAccountAvatarUriOk() (*string, bool)`

GetAccountAvatarUriOk returns a tuple with the AccountAvatarUri field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAccountAvatarUri

`func (o *AttendeeDto) SetAccountAvatarUri(v string)`

SetAccountAvatarUri sets AccountAvatarUri field to given value.

### HasAccountAvatarUri

`func (o *AttendeeDto) HasAccountAvatarUri() bool`

HasAccountAvatarUri returns a boolean if a field has been set.

### SetAccountAvatarUriNil

`func (o *AttendeeDto) SetAccountAvatarUriNil(b bool)`

 SetAccountAvatarUriNil sets the value for AccountAvatarUri to be an explicit nil

### UnsetAccountAvatarUri
`func (o *AttendeeDto) UnsetAccountAvatarUri()`

UnsetAccountAvatarUri ensures that no value is present for AccountAvatarUri, not even an explicit nil

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


