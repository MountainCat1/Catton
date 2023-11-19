/*
Accounts.Api

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

API version: 1.0
*/

// Code generated by OpenAPI Generator (https://openapi-generator.tech); DO NOT EDIT.

package openapi

import (
	"encoding/json"
)

// checks if the GetClaimsResponseDto type satisfies the MappedNullable interface at compile time
var _ MappedNullable = &GetClaimsResponseDto{}

// GetClaimsResponseDto struct for GetClaimsResponseDto
type GetClaimsResponseDto struct {
	Claims []ClaimDto `json:"claims,omitempty"`
}

// NewGetClaimsResponseDto instantiates a new GetClaimsResponseDto object
// This constructor will assign default values to properties that have it defined,
// and makes sure properties required by API are set, but the set of arguments
// will change when the set of required properties is changed
func NewGetClaimsResponseDto() *GetClaimsResponseDto {
	this := GetClaimsResponseDto{}
	return &this
}

// NewGetClaimsResponseDtoWithDefaults instantiates a new GetClaimsResponseDto object
// This constructor will only assign default values to properties that have it defined,
// but it doesn't guarantee that properties required by API are set
func NewGetClaimsResponseDtoWithDefaults() *GetClaimsResponseDto {
	this := GetClaimsResponseDto{}
	return &this
}

// GetClaims returns the Claims field value if set, zero value otherwise (both if not set or set to explicit null).
func (o *GetClaimsResponseDto) GetClaims() []ClaimDto {
	if o == nil {
		var ret []ClaimDto
		return ret
	}
	return o.Claims
}

// GetClaimsOk returns a tuple with the Claims field value if set, nil otherwise
// and a boolean to check if the value has been set.
// NOTE: If the value is an explicit nil, `nil, true` will be returned
func (o *GetClaimsResponseDto) GetClaimsOk() ([]ClaimDto, bool) {
	if o == nil || IsNil(o.Claims) {
		return nil, false
	}
	return o.Claims, true
}

// HasClaims returns a boolean if a field has been set.
func (o *GetClaimsResponseDto) HasClaims() bool {
	if o != nil && IsNil(o.Claims) {
		return true
	}

	return false
}

// SetClaims gets a reference to the given []ClaimDto and assigns it to the Claims field.
func (o *GetClaimsResponseDto) SetClaims(v []ClaimDto) {
	o.Claims = v
}

func (o GetClaimsResponseDto) MarshalJSON() ([]byte, error) {
	toSerialize,err := o.ToMap()
	if err != nil {
		return []byte{}, err
	}
	return json.Marshal(toSerialize)
}

func (o GetClaimsResponseDto) ToMap() (map[string]interface{}, error) {
	toSerialize := map[string]interface{}{}
	if o.Claims != nil {
		toSerialize["claims"] = o.Claims
	}
	return toSerialize, nil
}

type NullableGetClaimsResponseDto struct {
	value *GetClaimsResponseDto
	isSet bool
}

func (v NullableGetClaimsResponseDto) Get() *GetClaimsResponseDto {
	return v.value
}

func (v *NullableGetClaimsResponseDto) Set(val *GetClaimsResponseDto) {
	v.value = val
	v.isSet = true
}

func (v NullableGetClaimsResponseDto) IsSet() bool {
	return v.isSet
}

func (v *NullableGetClaimsResponseDto) Unset() {
	v.value = nil
	v.isSet = false
}

func NewNullableGetClaimsResponseDto(val *GetClaimsResponseDto) *NullableGetClaimsResponseDto {
	return &NullableGetClaimsResponseDto{value: val, isSet: true}
}

func (v NullableGetClaimsResponseDto) MarshalJSON() ([]byte, error) {
	return json.Marshal(v.value)
}

func (v *NullableGetClaimsResponseDto) UnmarshalJSON(src []byte) error {
	v.isSet = true
	return json.Unmarshal(src, &v.value)
}

