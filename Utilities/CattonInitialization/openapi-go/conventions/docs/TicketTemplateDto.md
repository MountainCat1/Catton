# TicketTemplateDto

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | Pointer to **string** |  | [optional] 
**Name** | Pointer to **NullableString** |  | [optional] 
**Description** | Pointer to **NullableString** |  | [optional] 
**Price** | Pointer to **float64** |  | [optional] 
**Avaliable** | Pointer to **bool** |  | [optional] 
**CreateDate** | Pointer to **time.Time** |  | [optional] 
**ConvetionId** | Pointer to **NullableString** |  | [optional] 
**LastEditAuthorId** | Pointer to **NullableString** |  | [optional] 
**AuthorId** | Pointer to **string** |  | [optional] 

## Methods

### NewTicketTemplateDto

`func NewTicketTemplateDto() *TicketTemplateDto`

NewTicketTemplateDto instantiates a new TicketTemplateDto object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewTicketTemplateDtoWithDefaults

`func NewTicketTemplateDtoWithDefaults() *TicketTemplateDto`

NewTicketTemplateDtoWithDefaults instantiates a new TicketTemplateDto object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetId

`func (o *TicketTemplateDto) GetId() string`

GetId returns the Id field if non-nil, zero value otherwise.

### GetIdOk

`func (o *TicketTemplateDto) GetIdOk() (*string, bool)`

GetIdOk returns a tuple with the Id field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetId

`func (o *TicketTemplateDto) SetId(v string)`

SetId sets Id field to given value.

### HasId

`func (o *TicketTemplateDto) HasId() bool`

HasId returns a boolean if a field has been set.

### GetName

`func (o *TicketTemplateDto) GetName() string`

GetName returns the Name field if non-nil, zero value otherwise.

### GetNameOk

`func (o *TicketTemplateDto) GetNameOk() (*string, bool)`

GetNameOk returns a tuple with the Name field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetName

`func (o *TicketTemplateDto) SetName(v string)`

SetName sets Name field to given value.

### HasName

`func (o *TicketTemplateDto) HasName() bool`

HasName returns a boolean if a field has been set.

### SetNameNil

`func (o *TicketTemplateDto) SetNameNil(b bool)`

 SetNameNil sets the value for Name to be an explicit nil

### UnsetName
`func (o *TicketTemplateDto) UnsetName()`

UnsetName ensures that no value is present for Name, not even an explicit nil
### GetDescription

`func (o *TicketTemplateDto) GetDescription() string`

GetDescription returns the Description field if non-nil, zero value otherwise.

### GetDescriptionOk

`func (o *TicketTemplateDto) GetDescriptionOk() (*string, bool)`

GetDescriptionOk returns a tuple with the Description field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetDescription

`func (o *TicketTemplateDto) SetDescription(v string)`

SetDescription sets Description field to given value.

### HasDescription

`func (o *TicketTemplateDto) HasDescription() bool`

HasDescription returns a boolean if a field has been set.

### SetDescriptionNil

`func (o *TicketTemplateDto) SetDescriptionNil(b bool)`

 SetDescriptionNil sets the value for Description to be an explicit nil

### UnsetDescription
`func (o *TicketTemplateDto) UnsetDescription()`

UnsetDescription ensures that no value is present for Description, not even an explicit nil
### GetPrice

`func (o *TicketTemplateDto) GetPrice() float64`

GetPrice returns the Price field if non-nil, zero value otherwise.

### GetPriceOk

`func (o *TicketTemplateDto) GetPriceOk() (*float64, bool)`

GetPriceOk returns a tuple with the Price field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetPrice

`func (o *TicketTemplateDto) SetPrice(v float64)`

SetPrice sets Price field to given value.

### HasPrice

`func (o *TicketTemplateDto) HasPrice() bool`

HasPrice returns a boolean if a field has been set.

### GetAvaliable

`func (o *TicketTemplateDto) GetAvaliable() bool`

GetAvaliable returns the Avaliable field if non-nil, zero value otherwise.

### GetAvaliableOk

`func (o *TicketTemplateDto) GetAvaliableOk() (*bool, bool)`

GetAvaliableOk returns a tuple with the Avaliable field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAvaliable

`func (o *TicketTemplateDto) SetAvaliable(v bool)`

SetAvaliable sets Avaliable field to given value.

### HasAvaliable

`func (o *TicketTemplateDto) HasAvaliable() bool`

HasAvaliable returns a boolean if a field has been set.

### GetCreateDate

`func (o *TicketTemplateDto) GetCreateDate() time.Time`

GetCreateDate returns the CreateDate field if non-nil, zero value otherwise.

### GetCreateDateOk

`func (o *TicketTemplateDto) GetCreateDateOk() (*time.Time, bool)`

GetCreateDateOk returns a tuple with the CreateDate field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetCreateDate

`func (o *TicketTemplateDto) SetCreateDate(v time.Time)`

SetCreateDate sets CreateDate field to given value.

### HasCreateDate

`func (o *TicketTemplateDto) HasCreateDate() bool`

HasCreateDate returns a boolean if a field has been set.

### GetConvetionId

`func (o *TicketTemplateDto) GetConvetionId() string`

GetConvetionId returns the ConvetionId field if non-nil, zero value otherwise.

### GetConvetionIdOk

`func (o *TicketTemplateDto) GetConvetionIdOk() (*string, bool)`

GetConvetionIdOk returns a tuple with the ConvetionId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetConvetionId

`func (o *TicketTemplateDto) SetConvetionId(v string)`

SetConvetionId sets ConvetionId field to given value.

### HasConvetionId

`func (o *TicketTemplateDto) HasConvetionId() bool`

HasConvetionId returns a boolean if a field has been set.

### SetConvetionIdNil

`func (o *TicketTemplateDto) SetConvetionIdNil(b bool)`

 SetConvetionIdNil sets the value for ConvetionId to be an explicit nil

### UnsetConvetionId
`func (o *TicketTemplateDto) UnsetConvetionId()`

UnsetConvetionId ensures that no value is present for ConvetionId, not even an explicit nil
### GetLastEditAuthorId

`func (o *TicketTemplateDto) GetLastEditAuthorId() string`

GetLastEditAuthorId returns the LastEditAuthorId field if non-nil, zero value otherwise.

### GetLastEditAuthorIdOk

`func (o *TicketTemplateDto) GetLastEditAuthorIdOk() (*string, bool)`

GetLastEditAuthorIdOk returns a tuple with the LastEditAuthorId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetLastEditAuthorId

`func (o *TicketTemplateDto) SetLastEditAuthorId(v string)`

SetLastEditAuthorId sets LastEditAuthorId field to given value.

### HasLastEditAuthorId

`func (o *TicketTemplateDto) HasLastEditAuthorId() bool`

HasLastEditAuthorId returns a boolean if a field has been set.

### SetLastEditAuthorIdNil

`func (o *TicketTemplateDto) SetLastEditAuthorIdNil(b bool)`

 SetLastEditAuthorIdNil sets the value for LastEditAuthorId to be an explicit nil

### UnsetLastEditAuthorId
`func (o *TicketTemplateDto) UnsetLastEditAuthorId()`

UnsetLastEditAuthorId ensures that no value is present for LastEditAuthorId, not even an explicit nil
### GetAuthorId

`func (o *TicketTemplateDto) GetAuthorId() string`

GetAuthorId returns the AuthorId field if non-nil, zero value otherwise.

### GetAuthorIdOk

`func (o *TicketTemplateDto) GetAuthorIdOk() (*string, bool)`

GetAuthorIdOk returns a tuple with the AuthorId field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetAuthorId

`func (o *TicketTemplateDto) SetAuthorId(v string)`

SetAuthorId sets AuthorId field to given value.

### HasAuthorId

`func (o *TicketTemplateDto) HasAuthorId() bool`

HasAuthorId returns a boolean if a field has been set.


[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


