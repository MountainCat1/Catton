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

// checks if the AuthTokenResponseContract type satisfies the MappedNullable interface at compile time
var _ MappedNullable = &AuthTokenResponseContract{}

// AuthTokenResponseContract struct for AuthTokenResponseContract
type AuthTokenResponseContract struct {
	AuthToken NullableString `json:"authToken,omitempty"`
}

// NewAuthTokenResponseContract instantiates a new AuthTokenResponseContract object
// This constructor will assign default values to properties that have it defined,
// and makes sure properties required by API are set, but the set of arguments
// will change when the set of required properties is changed
func NewAuthTokenResponseContract() *AuthTokenResponseContract {
	this := AuthTokenResponseContract{}
	return &this
}

// NewAuthTokenResponseContractWithDefaults instantiates a new AuthTokenResponseContract object
// This constructor will only assign default values to properties that have it defined,
// but it doesn't guarantee that properties required by API are set
func NewAuthTokenResponseContractWithDefaults() *AuthTokenResponseContract {
	this := AuthTokenResponseContract{}
	return &this
}

// GetAuthToken returns the AuthToken field value if set, zero value otherwise (both if not set or set to explicit null).
func (o *AuthTokenResponseContract) GetAuthToken() string {
	if o == nil || IsNil(o.AuthToken.Get()) {
		var ret string
		return ret
	}
	return *o.AuthToken.Get()
}

// GetAuthTokenOk returns a tuple with the AuthToken field value if set, nil otherwise
// and a boolean to check if the value has been set.
// NOTE: If the value is an explicit nil, `nil, true` will be returned
func (o *AuthTokenResponseContract) GetAuthTokenOk() (*string, bool) {
	if o == nil {
		return nil, false
	}
	return o.AuthToken.Get(), o.AuthToken.IsSet()
}

// HasAuthToken returns a boolean if a field has been set.
func (o *AuthTokenResponseContract) HasAuthToken() bool {
	if o != nil && o.AuthToken.IsSet() {
		return true
	}

	return false
}

// SetAuthToken gets a reference to the given NullableString and assigns it to the AuthToken field.
func (o *AuthTokenResponseContract) SetAuthToken(v string) {
	o.AuthToken.Set(&v)
}
// SetAuthTokenNil sets the value for AuthToken to be an explicit nil
func (o *AuthTokenResponseContract) SetAuthTokenNil() {
	o.AuthToken.Set(nil)
}

// UnsetAuthToken ensures that no value is present for AuthToken, not even an explicit nil
func (o *AuthTokenResponseContract) UnsetAuthToken() {
	o.AuthToken.Unset()
}

func (o AuthTokenResponseContract) MarshalJSON() ([]byte, error) {
	toSerialize,err := o.ToMap()
	if err != nil {
		return []byte{}, err
	}
	return json.Marshal(toSerialize)
}

func (o AuthTokenResponseContract) ToMap() (map[string]interface{}, error) {
	toSerialize := map[string]interface{}{}
	if o.AuthToken.IsSet() {
		toSerialize["authToken"] = o.AuthToken.Get()
	}
	return toSerialize, nil
}

type NullableAuthTokenResponseContract struct {
	value *AuthTokenResponseContract
	isSet bool
}

func (v NullableAuthTokenResponseContract) Get() *AuthTokenResponseContract {
	return v.value
}

func (v *NullableAuthTokenResponseContract) Set(val *AuthTokenResponseContract) {
	v.value = val
	v.isSet = true
}

func (v NullableAuthTokenResponseContract) IsSet() bool {
	return v.isSet
}

func (v *NullableAuthTokenResponseContract) Unset() {
	v.value = nil
	v.isSet = false
}

func NewNullableAuthTokenResponseContract(val *AuthTokenResponseContract) *NullableAuthTokenResponseContract {
	return &NullableAuthTokenResponseContract{value: val, isSet: true}
}

func (v NullableAuthTokenResponseContract) MarshalJSON() ([]byte, error) {
	return json.Marshal(v.value)
}

func (v *NullableAuthTokenResponseContract) UnmarshalJSON(src []byte) error {
	v.isSet = true
	return json.Unmarshal(src, &v.value)
}


