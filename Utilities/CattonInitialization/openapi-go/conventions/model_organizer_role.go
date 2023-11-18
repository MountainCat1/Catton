/*
Conventions.Api

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

API version: 1.0
*/

// Code generated by OpenAPI Generator (https://openapi-generator.tech); DO NOT EDIT.

package openapi

import (
	"encoding/json"
	"fmt"
)

// OrganizerRole the model 'OrganizerRole'
type OrganizerRole string

// List of OrganizerRole
const (
	GUEST OrganizerRole = "Guest"
	OWNER OrganizerRole = "Owner"
	ADMINISTRATOR OrganizerRole = "Administrator"
	MODERATOR OrganizerRole = "Moderator"
	ANNOUNCER OrganizerRole = "Announcer"
	HELPER OrganizerRole = "Helper"
)

// All allowed values of OrganizerRole enum
var AllowedOrganizerRoleEnumValues = []OrganizerRole{
	"Guest",
	"Owner",
	"Administrator",
	"Moderator",
	"Announcer",
	"Helper",
}

func (v *OrganizerRole) UnmarshalJSON(src []byte) error {
	var value string
	err := json.Unmarshal(src, &value)
	if err != nil {
		return err
	}
	enumTypeValue := OrganizerRole(value)
	for _, existing := range AllowedOrganizerRoleEnumValues {
		if existing == enumTypeValue {
			*v = enumTypeValue
			return nil
		}
	}

	return fmt.Errorf("%+v is not a valid OrganizerRole", value)
}

// NewOrganizerRoleFromValue returns a pointer to a valid OrganizerRole
// for the value passed as argument, or an error if the value passed is not allowed by the enum
func NewOrganizerRoleFromValue(v string) (*OrganizerRole, error) {
	ev := OrganizerRole(v)
	if ev.IsValid() {
		return &ev, nil
	} else {
		return nil, fmt.Errorf("invalid value '%v' for OrganizerRole: valid values are %v", v, AllowedOrganizerRoleEnumValues)
	}
}

// IsValid return true if the value is valid for the enum, false otherwise
func (v OrganizerRole) IsValid() bool {
	for _, existing := range AllowedOrganizerRoleEnumValues {
		if existing == v {
			return true
		}
	}
	return false
}

// Ptr returns reference to OrganizerRole value
func (v OrganizerRole) Ptr() *OrganizerRole {
	return &v
}

type NullableOrganizerRole struct {
	value *OrganizerRole
	isSet bool
}

func (v NullableOrganizerRole) Get() *OrganizerRole {
	return v.value
}

func (v *NullableOrganizerRole) Set(val *OrganizerRole) {
	v.value = val
	v.isSet = true
}

func (v NullableOrganizerRole) IsSet() bool {
	return v.isSet
}

func (v *NullableOrganizerRole) Unset() {
	v.value = nil
	v.isSet = false
}

func NewNullableOrganizerRole(val *OrganizerRole) *NullableOrganizerRole {
	return &NullableOrganizerRole{value: val, isSet: true}
}

func (v NullableOrganizerRole) MarshalJSON() ([]byte, error) {
	return json.Marshal(v.value)
}

func (v *NullableOrganizerRole) UnmarshalJSON(src []byte) error {
	v.isSet = true
	return json.Unmarshal(src, &v.value)
}

