/*
Conventions.Api

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

API version: 1.0
*/

// Code generated by OpenAPI Generator (https://openapi-generator.tech); DO NOT EDIT.

package openapi

import (
	"encoding/json"
)

// checks if the TicketCreateDto type satisfies the MappedNullable interface at compile time
var _ MappedNullable = &TicketCreateDto{}

// TicketCreateDto struct for TicketCreateDto
type TicketCreateDto struct {
	TicketTemplateId *string `json:"ticketTemplateId,omitempty"`
}

// NewTicketCreateDto instantiates a new TicketCreateDto object
// This constructor will assign default values to properties that have it defined,
// and makes sure properties required by API are set, but the set of arguments
// will change when the set of required properties is changed
func NewTicketCreateDto() *TicketCreateDto {
	this := TicketCreateDto{}
	return &this
}

// NewTicketCreateDtoWithDefaults instantiates a new TicketCreateDto object
// This constructor will only assign default values to properties that have it defined,
// but it doesn't guarantee that properties required by API are set
func NewTicketCreateDtoWithDefaults() *TicketCreateDto {
	this := TicketCreateDto{}
	return &this
}

// GetTicketTemplateId returns the TicketTemplateId field value if set, zero value otherwise.
func (o *TicketCreateDto) GetTicketTemplateId() string {
	if o == nil || IsNil(o.TicketTemplateId) {
		var ret string
		return ret
	}
	return *o.TicketTemplateId
}

// GetTicketTemplateIdOk returns a tuple with the TicketTemplateId field value if set, nil otherwise
// and a boolean to check if the value has been set.
func (o *TicketCreateDto) GetTicketTemplateIdOk() (*string, bool) {
	if o == nil || IsNil(o.TicketTemplateId) {
		return nil, false
	}
	return o.TicketTemplateId, true
}

// HasTicketTemplateId returns a boolean if a field has been set.
func (o *TicketCreateDto) HasTicketTemplateId() bool {
	if o != nil && !IsNil(o.TicketTemplateId) {
		return true
	}

	return false
}

// SetTicketTemplateId gets a reference to the given string and assigns it to the TicketTemplateId field.
func (o *TicketCreateDto) SetTicketTemplateId(v string) {
	o.TicketTemplateId = &v
}

func (o TicketCreateDto) MarshalJSON() ([]byte, error) {
	toSerialize,err := o.ToMap()
	if err != nil {
		return []byte{}, err
	}
	return json.Marshal(toSerialize)
}

func (o TicketCreateDto) ToMap() (map[string]interface{}, error) {
	toSerialize := map[string]interface{}{}
	if !IsNil(o.TicketTemplateId) {
		toSerialize["ticketTemplateId"] = o.TicketTemplateId
	}
	return toSerialize, nil
}

type NullableTicketCreateDto struct {
	value *TicketCreateDto
	isSet bool
}

func (v NullableTicketCreateDto) Get() *TicketCreateDto {
	return v.value
}

func (v *NullableTicketCreateDto) Set(val *TicketCreateDto) {
	v.value = val
	v.isSet = true
}

func (v NullableTicketCreateDto) IsSet() bool {
	return v.isSet
}

func (v *NullableTicketCreateDto) Unset() {
	v.value = nil
	v.isSet = false
}

func NewNullableTicketCreateDto(val *TicketCreateDto) *NullableTicketCreateDto {
	return &NullableTicketCreateDto{value: val, isSet: true}
}

func (v NullableTicketCreateDto) MarshalJSON() ([]byte, error) {
	return json.Marshal(v.value)
}

func (v *NullableTicketCreateDto) UnmarshalJSON(src []byte) error {
	v.isSet = true
	return json.Unmarshal(src, &v.value)
}


