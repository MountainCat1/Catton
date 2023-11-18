# OrganizerDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | Pointer to **string** |  | [optional] 
**ConventionId** | Pointer to **NullableString** |  | [optional] 
**CreatedDate** | Pointer to **time.Time** |  | [optional] 
**Role** | Pointer to [**OrganizerRole**](OrganizerRole.md) |  | [optional] 
**AccountUsername** | Pointer to **NullableString** |  | [optional] 
**AccountAvatarUri** | Pointer to **NullableString** |  | [optional] 

## Methods

### NewOrganizerDto

`func NewOrganizerDto() *OrganizerDto`

NewOrganizerDto instantiates a new OrganizerDto object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewOrganizerDtoWithDefaults

`func NewOrganizerDtoWithDefaults() *OrganizerDto`

NewOrganizerDtoWithDefaults instantiates a new OrganizerDto object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetAccountId

`func (o *OrganizerDto) GetAccountId() string`

GetAccountId returns the AccountId field if non-nil, zero value otherwise.

### GetAccountIdOk

`func (o *OrganizerDto) GetAccountIdOk() (*string, bool)`

GetAccountIdOk returns a tuple with the AccountId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAccountId

`func (o *OrganizerDto) SetAccountId(v string)`

SetAccountId sets AccountId field to given value.

### HasAccountId

`func (o *OrganizerDto) HasAccountId() bool`

HasAccountId returns a boolean if a field has been set.

### GetConventionId

`func (o *OrganizerDto) GetConventionId() string`

GetConventionId returns the ConventionId field if non-nil, zero value otherwise.

### GetConventionIdOk

`func (o *OrganizerDto) GetConventionIdOk() (*string, bool)`

GetConventionIdOk returns a tuple with the ConventionId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetConventionId

`func (o *OrganizerDto) SetConventionId(v string)`

SetConventionId sets ConventionId field to given value.

### HasConventionId

`func (o *OrganizerDto) HasConventionId() bool`

HasConventionId returns a boolean if a field has been set.

### SetConventionIdNil

`func (o *OrganizerDto) SetConventionIdNil(b bool)`

 SetConventionIdNil sets the value for ConventionId to be an explicit nil

### UnsetConventionId
`func (o *OrganizerDto) UnsetConventionId()`

UnsetConventionId ensures that no value is present for ConventionId, not even an explicit nil
### GetCreatedDate

`func (o *OrganizerDto) GetCreatedDate() time.Time`

GetCreatedDate returns the CreatedDate field if non-nil, zero value otherwise.

### GetCreatedDateOk

`func (o *OrganizerDto) GetCreatedDateOk() (*time.Time, bool)`

GetCreatedDateOk returns a tuple with the CreatedDate field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetCreatedDate

`func (o *OrganizerDto) SetCreatedDate(v time.Time)`

SetCreatedDate sets CreatedDate field to given value.

### HasCreatedDate

`func (o *OrganizerDto) HasCreatedDate() bool`

HasCreatedDate returns a boolean if a field has been set.

### GetRole

`func (o *OrganizerDto) GetRole() OrganizerRole`

GetRole returns the Role field if non-nil, zero value otherwise.

### GetRoleOk

`func (o *OrganizerDto) GetRoleOk() (*OrganizerRole, bool)`

GetRoleOk returns a tuple with the Role field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetRole

`func (o *OrganizerDto) SetRole(v OrganizerRole)`

SetRole sets Role field to given value.

### HasRole

`func (o *OrganizerDto) HasRole() bool`

HasRole returns a boolean if a field has been set.

### GetAccountUsername

`func (o *OrganizerDto) GetAccountUsername() string`

GetAccountUsername returns the AccountUsername field if non-nil, zero value otherwise.

### GetAccountUsernameOk

`func (o *OrganizerDto) GetAccountUsernameOk() (*string, bool)`

GetAccountUsernameOk returns a tuple with the AccountUsername field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAccountUsername

`func (o *OrganizerDto) SetAccountUsername(v string)`

SetAccountUsername sets AccountUsername field to given value.

### HasAccountUsername

`func (o *OrganizerDto) HasAccountUsername() bool`

HasAccountUsername returns a boolean if a field has been set.

### SetAccountUsernameNil

`func (o *OrganizerDto) SetAccountUsernameNil(b bool)`

 SetAccountUsernameNil sets the value for AccountUsername to be an explicit nil

### UnsetAccountUsername
`func (o *OrganizerDto) UnsetAccountUsername()`

UnsetAccountUsername ensures that no value is present for AccountUsername, not even an explicit nil
### GetAccountAvatarUri

`func (o *OrganizerDto) GetAccountAvatarUri() string`

GetAccountAvatarUri returns the AccountAvatarUri field if non-nil, zero value otherwise.

### GetAccountAvatarUriOk

`func (o *OrganizerDto) GetAccountAvatarUriOk() (*string, bool)`

GetAccountAvatarUriOk returns a tuple with the AccountAvatarUri field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAccountAvatarUri

`func (o *OrganizerDto) SetAccountAvatarUri(v string)`

SetAccountAvatarUri sets AccountAvatarUri field to given value.

### HasAccountAvatarUri

`func (o *OrganizerDto) HasAccountAvatarUri() bool`

HasAccountAvatarUri returns a boolean if a field has been set.

### SetAccountAvatarUriNil

`func (o *OrganizerDto) SetAccountAvatarUriNil(b bool)`

 SetAccountAvatarUriNil sets the value for AccountAvatarUri to be an explicit nil

### UnsetAccountAvatarUri
`func (o *OrganizerDto) UnsetAccountAvatarUri()`

UnsetAccountAvatarUri ensures that no value is present for AccountAvatarUri, not even an explicit nil

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


