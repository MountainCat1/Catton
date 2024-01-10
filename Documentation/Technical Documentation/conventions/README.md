# Documentation for Conventions.Api

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://localhost*

| Class | Method | HTTP request | Description |
|------------ | ------------- | ------------- | -------------|
| *AttendeeApi* | [**apiConventionsConventionIdAttendeesAccountIdDelete**](Apis/AttendeeApi.md#apiconventionsconventionidattendeesaccountiddelete) | **DELETE** /api/conventions/{conventionId}/attendees/{accountId} |  |
*AttendeeApi* | [**apiConventionsConventionIdAttendeesAccountIdGet**](Apis/AttendeeApi.md#apiconventionsconventionidattendeesaccountidget) | **GET** /api/conventions/{conventionId}/attendees/{accountId} |  |
*AttendeeApi* | [**apiConventionsConventionIdAttendeesGet**](Apis/AttendeeApi.md#apiconventionsconventionidattendeesget) | **GET** /api/conventions/{conventionId}/attendees |  |
*AttendeeApi* | [**apiConventionsConventionIdAttendeesMePost**](Apis/AttendeeApi.md#apiconventionsconventionidattendeesmepost) | **POST** /api/conventions/{conventionId}/attendees/me |  |
*AttendeeApi* | [**apiConventionsConventionIdAttendeesPost**](Apis/AttendeeApi.md#apiconventionsconventionidattendeespost) | **POST** /api/conventions/{conventionId}/attendees |  |
| *ConventionApi* | [**apiConventionsGet**](Apis/ConventionApi.md#apiconventionsget) | **GET** /api/conventions |  |
*ConventionApi* | [**apiConventionsIdGet**](Apis/ConventionApi.md#apiconventionsidget) | **GET** /api/conventions/{id} |  |
*ConventionApi* | [**apiConventionsIdPut**](Apis/ConventionApi.md#apiconventionsidput) | **PUT** /api/conventions/{id} |  |
*ConventionApi* | [**apiConventionsPost**](Apis/ConventionApi.md#apiconventionspost) | **POST** /api/conventions |  |
| *OrganizerApi* | [**apiConventionsConventionIdOrganizersGet**](Apis/OrganizerApi.md#apiconventionsconventionidorganizersget) | **GET** /api/conventions/{conventionId}/organizers |  |
*OrganizerApi* | [**apiConventionsConventionIdOrganizersOrganizerIdDelete**](Apis/OrganizerApi.md#apiconventionsconventionidorganizersorganizeriddelete) | **DELETE** /api/conventions/{conventionId}/organizers/{organizerId} |  |
*OrganizerApi* | [**apiConventionsConventionIdOrganizersOrganizerIdGet**](Apis/OrganizerApi.md#apiconventionsconventionidorganizersorganizeridget) | **GET** /api/conventions/{conventionId}/organizers/{organizerId} |  |
*OrganizerApi* | [**apiConventionsConventionIdOrganizersOrganizerIdPut**](Apis/OrganizerApi.md#apiconventionsconventionidorganizersorganizeridput) | **PUT** /api/conventions/{conventionId}/organizers/{organizerId} |  |
*OrganizerApi* | [**apiConventionsConventionIdOrganizersPost**](Apis/OrganizerApi.md#apiconventionsconventionidorganizerspost) | **POST** /api/conventions/{conventionId}/organizers |  |
| *TicketApi* | [**apiConventionsConventionIdAttendeesAttendeeIdTicketsGet**](Apis/TicketApi.md#apiconventionsconventionidattendeesattendeeidticketsget) | **GET** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets |  |
*TicketApi* | [**apiConventionsConventionIdAttendeesAttendeeIdTicketsPost**](Apis/TicketApi.md#apiconventionsconventionidattendeesattendeeidticketspost) | **POST** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets |  |
*TicketApi* | [**apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdDelete**](Apis/TicketApi.md#apiconventionsconventionidattendeesattendeeidticketsticketiddelete) | **DELETE** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets/{ticketId} |  |
*TicketApi* | [**apiConventionsConventionIdAttendeesAttendeeIdTicketsTicketIdPut**](Apis/TicketApi.md#apiconventionsconventionidattendeesattendeeidticketsticketidput) | **PUT** /api/conventions/{conventionId}/attendees/{attendeeId}/tickets/{ticketId} |  |
*TicketApi* | [**apiConventionsConventionIdTicketsGet**](Apis/TicketApi.md#apiconventionsconventionidticketsget) | **GET** /api/conventions/{conventionId}/tickets |  |
*TicketApi* | [**apiConventionsConventionIdTicketsTicketIdGet**](Apis/TicketApi.md#apiconventionsconventionidticketsticketidget) | **GET** /api/conventions/{conventionId}/tickets/{ticketId} |  |
| *TicketTemplateApi* | [**apiConventionsConventionIdTicketTemplatesGet**](Apis/TicketTemplateApi.md#apiconventionsconventionidtickettemplatesget) | **GET** /api/conventions/{conventionId}/ticket-templates |  |
*TicketTemplateApi* | [**apiConventionsConventionIdTicketTemplatesPost**](Apis/TicketTemplateApi.md#apiconventionsconventionidtickettemplatespost) | **POST** /api/conventions/{conventionId}/ticket-templates |  |
*TicketTemplateApi* | [**apiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete**](Apis/TicketTemplateApi.md#apiconventionsconventionidtickettemplatestickettemplateiddelete) | **DELETE** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} |  |
*TicketTemplateApi* | [**apiConventionsConventionIdTicketTemplatesTicketTemplateIdGet**](Apis/TicketTemplateApi.md#apiconventionsconventionidtickettemplatestickettemplateidget) | **GET** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} |  |
*TicketTemplateApi* | [**apiConventionsConventionIdTicketTemplatesTicketTemplateIdPut**](Apis/TicketTemplateApi.md#apiconventionsconventionidtickettemplatestickettemplateidput) | **PUT** /api/conventions/{conventionId}/ticket-templates/{ticketTemplateId} |  |


<a name="documentation-for-models"></a>
## Documentation for Models

 - [AttendeeCreateDto](./Models/AttendeeCreateDto.md)
 - [AttendeeDto](./Models/AttendeeDto.md)
 - [CheckoutSessionDetailsDto](./Models/CheckoutSessionDetailsDto.md)
 - [ConventionCreateDto](./Models/ConventionCreateDto.md)
 - [ConventionDto](./Models/ConventionDto.md)
 - [ConventionUpdateDto](./Models/ConventionUpdateDto.md)
 - [ErrorResponse](./Models/ErrorResponse.md)
 - [OrganizerCreateDto](./Models/OrganizerCreateDto.md)
 - [OrganizerDto](./Models/OrganizerDto.md)
 - [OrganizerRole](./Models/OrganizerRole.md)
 - [OrganizerUpdateDto](./Models/OrganizerUpdateDto.md)
 - [PaymentDto](./Models/PaymentDto.md)
 - [PaymentStatus](./Models/PaymentStatus.md)
 - [TicketCreateDto](./Models/TicketCreateDto.md)
 - [TicketDto](./Models/TicketDto.md)
 - [TicketTemplateCreateDto](./Models/TicketTemplateCreateDto.md)
 - [TicketTemplateDto](./Models/TicketTemplateDto.md)
 - [TicketTemplateUpdateDto](./Models/TicketTemplateUpdateDto.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="Bearer"></a>
### Bearer

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

