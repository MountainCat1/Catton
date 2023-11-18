/*
Conventions.Api

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

API version: 1.0
*/

// Code generated by OpenAPI Generator (https://openapi-generator.tech); DO NOT EDIT.

package openapi

import (
	"bytes"
	"context"
	"io"
	"net/http"
	"net/url"
	"strings"
)


// TicketTemplateAPIService TicketTemplateAPI service
type TicketTemplateAPIService service

type ApiApiConventionsConventionIdTicketTemplatesGetRequest struct {
	ctx context.Context
	ApiService *TicketTemplateAPIService
	conventionId string
}

func (r ApiApiConventionsConventionIdTicketTemplatesGetRequest) Execute() ([]TicketTemplateDto, *http.Response, error) {
	return r.ApiService.ApiConventionsConventionIdTicketTemplatesGetExecute(r)
}

/*
ApiConventionsConventionIdTicketTemplatesGet Method for ApiConventionsConventionIdTicketTemplatesGet

 @param ctx context.Context - for authentication, logging, cancellation, deadlines, tracing, etc. Passed from http.Request or context.Background().
 @param conventionId
 @return ApiApiConventionsConventionIdTicketTemplatesGetRequest
*/
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesGet(ctx context.Context, conventionId string) ApiApiConventionsConventionIdTicketTemplatesGetRequest {
	return ApiApiConventionsConventionIdTicketTemplatesGetRequest{
		ApiService: a,
		ctx: ctx,
		conventionId: conventionId,
	}
}

// Execute executes the request
//  @return []TicketTemplateDto
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesGetExecute(r ApiApiConventionsConventionIdTicketTemplatesGetRequest) ([]TicketTemplateDto, *http.Response, error) {
	var (
		localVarHTTPMethod   = http.MethodGet
		localVarPostBody     interface{}
		formFiles            []formFile
		localVarReturnValue  []TicketTemplateDto
	)

	localBasePath, err := a.client.cfg.ServerURLWithContext(r.ctx, "TicketTemplateAPIService.ApiConventionsConventionIdTicketTemplatesGet")
	if err != nil {
		return localVarReturnValue, nil, &GenericOpenAPIError{error: err.Error()}
	}

	localVarPath := localBasePath + "/api/conventions/{conventionId}/ticket-templates"
	localVarPath = strings.Replace(localVarPath, "{"+"conventionId"+"}", url.PathEscape(parameterValueToString(r.conventionId, "conventionId")), -1)

	localVarHeaderParams := make(map[string]string)
	localVarQueryParams := url.Values{}
	localVarFormParams := url.Values{}

	// to determine the Content-Type header
	localVarHTTPContentTypes := []string{}

	// set Content-Type header
	localVarHTTPContentType := selectHeaderContentType(localVarHTTPContentTypes)
	if localVarHTTPContentType != "" {
		localVarHeaderParams["Content-Type"] = localVarHTTPContentType
	}

	// to determine the Accept header
	localVarHTTPHeaderAccepts := []string{"text/plain", "application/json", "text/json"}

	// set Accept header
	localVarHTTPHeaderAccept := selectHeaderAccept(localVarHTTPHeaderAccepts)
	if localVarHTTPHeaderAccept != "" {
		localVarHeaderParams["Accept"] = localVarHTTPHeaderAccept
	}
	if r.ctx != nil {
		// API Key Authentication
		if auth, ok := r.ctx.Value(ContextAPIKeys).(map[string]APIKey); ok {
			if apiKey, ok := auth["Bearer"]; ok {
				var key string
				if apiKey.Prefix != "" {
					key = apiKey.Prefix + " " + apiKey.Key
				} else {
					key = apiKey.Key
				}
				localVarHeaderParams["Authorization"] = key
			}
		}
	}
	req, err := a.client.prepareRequest(r.ctx, localVarPath, localVarHTTPMethod, localVarPostBody, localVarHeaderParams, localVarQueryParams, localVarFormParams, formFiles)
	if err != nil {
		return localVarReturnValue, nil, err
	}

	localVarHTTPResponse, err := a.client.callAPI(req)
	if err != nil || localVarHTTPResponse == nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	localVarBody, err := io.ReadAll(localVarHTTPResponse.Body)
	localVarHTTPResponse.Body.Close()
	localVarHTTPResponse.Body = io.NopCloser(bytes.NewBuffer(localVarBody))
	if err != nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	if localVarHTTPResponse.StatusCode >= 300 {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: localVarHTTPResponse.Status,
		}
		if localVarHTTPResponse.StatusCode == 401 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
			return localVarReturnValue, localVarHTTPResponse, newErr
		}
		if localVarHTTPResponse.StatusCode == 404 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	err = a.client.decode(&localVarReturnValue, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
	if err != nil {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: err.Error(),
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	return localVarReturnValue, localVarHTTPResponse, nil
}

type ApiApiConventionsConventionIdTicketTemplatesPostRequest struct {
	ctx context.Context
	ApiService *TicketTemplateAPIService
	conventionId string
	ticketTemplateCreateDto *TicketTemplateCreateDto
}

func (r ApiApiConventionsConventionIdTicketTemplatesPostRequest) TicketTemplateCreateDto(ticketTemplateCreateDto TicketTemplateCreateDto) ApiApiConventionsConventionIdTicketTemplatesPostRequest {
	r.ticketTemplateCreateDto = &ticketTemplateCreateDto
	return r
}

func (r ApiApiConventionsConventionIdTicketTemplatesPostRequest) Execute() (*TicketTemplateDto, *http.Response, error) {
	return r.ApiService.ApiConventionsConventionIdTicketTemplatesPostExecute(r)
}

/*
ApiConventionsConventionIdTicketTemplatesPost Method for ApiConventionsConventionIdTicketTemplatesPost

 @param ctx context.Context - for authentication, logging, cancellation, deadlines, tracing, etc. Passed from http.Request or context.Background().
 @param conventionId
 @return ApiApiConventionsConventionIdTicketTemplatesPostRequest
*/
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesPost(ctx context.Context, conventionId string) ApiApiConventionsConventionIdTicketTemplatesPostRequest {
	return ApiApiConventionsConventionIdTicketTemplatesPostRequest{
		ApiService: a,
		ctx: ctx,
		conventionId: conventionId,
	}
}

// Execute executes the request
//  @return TicketTemplateDto
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesPostExecute(r ApiApiConventionsConventionIdTicketTemplatesPostRequest) (*TicketTemplateDto, *http.Response, error) {
	var (
		localVarHTTPMethod   = http.MethodPost
		localVarPostBody     interface{}
		formFiles            []formFile
		localVarReturnValue  *TicketTemplateDto
	)

	localBasePath, err := a.client.cfg.ServerURLWithContext(r.ctx, "TicketTemplateAPIService.ApiConventionsConventionIdTicketTemplatesPost")
	if err != nil {
		return localVarReturnValue, nil, &GenericOpenAPIError{error: err.Error()}
	}

	localVarPath := localBasePath + "/api/conventions/{conventionId}/ticket-templates"
	localVarPath = strings.Replace(localVarPath, "{"+"conventionId"+"}", url.PathEscape(parameterValueToString(r.conventionId, "conventionId")), -1)

	localVarHeaderParams := make(map[string]string)
	localVarQueryParams := url.Values{}
	localVarFormParams := url.Values{}

	// to determine the Content-Type header
	localVarHTTPContentTypes := []string{"application/json", "text/json", "application/*+json"}

	// set Content-Type header
	localVarHTTPContentType := selectHeaderContentType(localVarHTTPContentTypes)
	if localVarHTTPContentType != "" {
		localVarHeaderParams["Content-Type"] = localVarHTTPContentType
	}

	// to determine the Accept header
	localVarHTTPHeaderAccepts := []string{"text/plain", "application/json", "text/json"}

	// set Accept header
	localVarHTTPHeaderAccept := selectHeaderAccept(localVarHTTPHeaderAccepts)
	if localVarHTTPHeaderAccept != "" {
		localVarHeaderParams["Accept"] = localVarHTTPHeaderAccept
	}
	// body params
	localVarPostBody = r.ticketTemplateCreateDto
	if r.ctx != nil {
		// API Key Authentication
		if auth, ok := r.ctx.Value(ContextAPIKeys).(map[string]APIKey); ok {
			if apiKey, ok := auth["Bearer"]; ok {
				var key string
				if apiKey.Prefix != "" {
					key = apiKey.Prefix + " " + apiKey.Key
				} else {
					key = apiKey.Key
				}
				localVarHeaderParams["Authorization"] = key
			}
		}
	}
	req, err := a.client.prepareRequest(r.ctx, localVarPath, localVarHTTPMethod, localVarPostBody, localVarHeaderParams, localVarQueryParams, localVarFormParams, formFiles)
	if err != nil {
		return localVarReturnValue, nil, err
	}

	localVarHTTPResponse, err := a.client.callAPI(req)
	if err != nil || localVarHTTPResponse == nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	localVarBody, err := io.ReadAll(localVarHTTPResponse.Body)
	localVarHTTPResponse.Body.Close()
	localVarHTTPResponse.Body = io.NopCloser(bytes.NewBuffer(localVarBody))
	if err != nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	if localVarHTTPResponse.StatusCode >= 300 {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: localVarHTTPResponse.Status,
		}
		if localVarHTTPResponse.StatusCode == 401 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
			return localVarReturnValue, localVarHTTPResponse, newErr
		}
		if localVarHTTPResponse.StatusCode == 404 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	err = a.client.decode(&localVarReturnValue, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
	if err != nil {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: err.Error(),
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	return localVarReturnValue, localVarHTTPResponse, nil
}

type ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest struct {
	ctx context.Context
	ApiService *TicketTemplateAPIService
	conventionId string
	ticketTemplateId string
}

func (r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest) Execute() (*TicketTemplateDto, *http.Response, error) {
	return r.ApiService.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteExecute(r)
}

/*
ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete Method for ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete

 @param ctx context.Context - for authentication, logging, cancellation, deadlines, tracing, etc. Passed from http.Request or context.Background().
 @param conventionId
 @param ticketTemplateId
 @return ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest
*/
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete(ctx context.Context, conventionId string, ticketTemplateId string) ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest {
	return ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest{
		ApiService: a,
		ctx: ctx,
		conventionId: conventionId,
		ticketTemplateId: ticketTemplateId,
	}
}

// Execute executes the request
//  @return TicketTemplateDto
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteExecute(r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdDeleteRequest) (*TicketTemplateDto, *http.Response, error) {
	var (
		localVarHTTPMethod   = http.MethodDelete
		localVarPostBody     interface{}
		formFiles            []formFile
		localVarReturnValue  *TicketTemplateDto
	)

	localBasePath, err := a.client.cfg.ServerURLWithContext(r.ctx, "TicketTemplateAPIService.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdDelete")
	if err != nil {
		return localVarReturnValue, nil, &GenericOpenAPIError{error: err.Error()}
	}

	localVarPath := localBasePath + "/api/conventions/{conventionId}/ticket-templates/{ticketTemplateId}"
	localVarPath = strings.Replace(localVarPath, "{"+"conventionId"+"}", url.PathEscape(parameterValueToString(r.conventionId, "conventionId")), -1)
	localVarPath = strings.Replace(localVarPath, "{"+"ticketTemplateId"+"}", url.PathEscape(parameterValueToString(r.ticketTemplateId, "ticketTemplateId")), -1)

	localVarHeaderParams := make(map[string]string)
	localVarQueryParams := url.Values{}
	localVarFormParams := url.Values{}

	// to determine the Content-Type header
	localVarHTTPContentTypes := []string{}

	// set Content-Type header
	localVarHTTPContentType := selectHeaderContentType(localVarHTTPContentTypes)
	if localVarHTTPContentType != "" {
		localVarHeaderParams["Content-Type"] = localVarHTTPContentType
	}

	// to determine the Accept header
	localVarHTTPHeaderAccepts := []string{"text/plain", "application/json", "text/json"}

	// set Accept header
	localVarHTTPHeaderAccept := selectHeaderAccept(localVarHTTPHeaderAccepts)
	if localVarHTTPHeaderAccept != "" {
		localVarHeaderParams["Accept"] = localVarHTTPHeaderAccept
	}
	if r.ctx != nil {
		// API Key Authentication
		if auth, ok := r.ctx.Value(ContextAPIKeys).(map[string]APIKey); ok {
			if apiKey, ok := auth["Bearer"]; ok {
				var key string
				if apiKey.Prefix != "" {
					key = apiKey.Prefix + " " + apiKey.Key
				} else {
					key = apiKey.Key
				}
				localVarHeaderParams["Authorization"] = key
			}
		}
	}
	req, err := a.client.prepareRequest(r.ctx, localVarPath, localVarHTTPMethod, localVarPostBody, localVarHeaderParams, localVarQueryParams, localVarFormParams, formFiles)
	if err != nil {
		return localVarReturnValue, nil, err
	}

	localVarHTTPResponse, err := a.client.callAPI(req)
	if err != nil || localVarHTTPResponse == nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	localVarBody, err := io.ReadAll(localVarHTTPResponse.Body)
	localVarHTTPResponse.Body.Close()
	localVarHTTPResponse.Body = io.NopCloser(bytes.NewBuffer(localVarBody))
	if err != nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	if localVarHTTPResponse.StatusCode >= 300 {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: localVarHTTPResponse.Status,
		}
		if localVarHTTPResponse.StatusCode == 401 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
			return localVarReturnValue, localVarHTTPResponse, newErr
		}
		if localVarHTTPResponse.StatusCode == 404 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	err = a.client.decode(&localVarReturnValue, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
	if err != nil {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: err.Error(),
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	return localVarReturnValue, localVarHTTPResponse, nil
}

type ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest struct {
	ctx context.Context
	ApiService *TicketTemplateAPIService
	conventionId string
	ticketTemplateId string
}

func (r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest) Execute() (*TicketTemplateDto, *http.Response, error) {
	return r.ApiService.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetExecute(r)
}

/*
ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet Method for ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet

 @param ctx context.Context - for authentication, logging, cancellation, deadlines, tracing, etc. Passed from http.Request or context.Background().
 @param conventionId
 @param ticketTemplateId
 @return ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest
*/
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet(ctx context.Context, conventionId string, ticketTemplateId string) ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest {
	return ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest{
		ApiService: a,
		ctx: ctx,
		conventionId: conventionId,
		ticketTemplateId: ticketTemplateId,
	}
}

// Execute executes the request
//  @return TicketTemplateDto
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetExecute(r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdGetRequest) (*TicketTemplateDto, *http.Response, error) {
	var (
		localVarHTTPMethod   = http.MethodGet
		localVarPostBody     interface{}
		formFiles            []formFile
		localVarReturnValue  *TicketTemplateDto
	)

	localBasePath, err := a.client.cfg.ServerURLWithContext(r.ctx, "TicketTemplateAPIService.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdGet")
	if err != nil {
		return localVarReturnValue, nil, &GenericOpenAPIError{error: err.Error()}
	}

	localVarPath := localBasePath + "/api/conventions/{conventionId}/ticket-templates/{ticketTemplateId}"
	localVarPath = strings.Replace(localVarPath, "{"+"conventionId"+"}", url.PathEscape(parameterValueToString(r.conventionId, "conventionId")), -1)
	localVarPath = strings.Replace(localVarPath, "{"+"ticketTemplateId"+"}", url.PathEscape(parameterValueToString(r.ticketTemplateId, "ticketTemplateId")), -1)

	localVarHeaderParams := make(map[string]string)
	localVarQueryParams := url.Values{}
	localVarFormParams := url.Values{}

	// to determine the Content-Type header
	localVarHTTPContentTypes := []string{}

	// set Content-Type header
	localVarHTTPContentType := selectHeaderContentType(localVarHTTPContentTypes)
	if localVarHTTPContentType != "" {
		localVarHeaderParams["Content-Type"] = localVarHTTPContentType
	}

	// to determine the Accept header
	localVarHTTPHeaderAccepts := []string{"text/plain", "application/json", "text/json"}

	// set Accept header
	localVarHTTPHeaderAccept := selectHeaderAccept(localVarHTTPHeaderAccepts)
	if localVarHTTPHeaderAccept != "" {
		localVarHeaderParams["Accept"] = localVarHTTPHeaderAccept
	}
	if r.ctx != nil {
		// API Key Authentication
		if auth, ok := r.ctx.Value(ContextAPIKeys).(map[string]APIKey); ok {
			if apiKey, ok := auth["Bearer"]; ok {
				var key string
				if apiKey.Prefix != "" {
					key = apiKey.Prefix + " " + apiKey.Key
				} else {
					key = apiKey.Key
				}
				localVarHeaderParams["Authorization"] = key
			}
		}
	}
	req, err := a.client.prepareRequest(r.ctx, localVarPath, localVarHTTPMethod, localVarPostBody, localVarHeaderParams, localVarQueryParams, localVarFormParams, formFiles)
	if err != nil {
		return localVarReturnValue, nil, err
	}

	localVarHTTPResponse, err := a.client.callAPI(req)
	if err != nil || localVarHTTPResponse == nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	localVarBody, err := io.ReadAll(localVarHTTPResponse.Body)
	localVarHTTPResponse.Body.Close()
	localVarHTTPResponse.Body = io.NopCloser(bytes.NewBuffer(localVarBody))
	if err != nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	if localVarHTTPResponse.StatusCode >= 300 {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: localVarHTTPResponse.Status,
		}
		if localVarHTTPResponse.StatusCode == 401 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
			return localVarReturnValue, localVarHTTPResponse, newErr
		}
		if localVarHTTPResponse.StatusCode == 404 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	err = a.client.decode(&localVarReturnValue, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
	if err != nil {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: err.Error(),
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	return localVarReturnValue, localVarHTTPResponse, nil
}

type ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest struct {
	ctx context.Context
	ApiService *TicketTemplateAPIService
	conventionId string
	ticketTemplateId string
	ticketTemplateUpdateDto *TicketTemplateUpdateDto
}

func (r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest) TicketTemplateUpdateDto(ticketTemplateUpdateDto TicketTemplateUpdateDto) ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest {
	r.ticketTemplateUpdateDto = &ticketTemplateUpdateDto
	return r
}

func (r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest) Execute() (*TicketTemplateDto, *http.Response, error) {
	return r.ApiService.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutExecute(r)
}

/*
ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut Method for ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut

 @param ctx context.Context - for authentication, logging, cancellation, deadlines, tracing, etc. Passed from http.Request or context.Background().
 @param conventionId
 @param ticketTemplateId
 @return ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest
*/
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut(ctx context.Context, conventionId string, ticketTemplateId string) ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest {
	return ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest{
		ApiService: a,
		ctx: ctx,
		conventionId: conventionId,
		ticketTemplateId: ticketTemplateId,
	}
}

// Execute executes the request
//  @return TicketTemplateDto
func (a *TicketTemplateAPIService) ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutExecute(r ApiApiConventionsConventionIdTicketTemplatesTicketTemplateIdPutRequest) (*TicketTemplateDto, *http.Response, error) {
	var (
		localVarHTTPMethod   = http.MethodPut
		localVarPostBody     interface{}
		formFiles            []formFile
		localVarReturnValue  *TicketTemplateDto
	)

	localBasePath, err := a.client.cfg.ServerURLWithContext(r.ctx, "TicketTemplateAPIService.ApiConventionsConventionIdTicketTemplatesTicketTemplateIdPut")
	if err != nil {
		return localVarReturnValue, nil, &GenericOpenAPIError{error: err.Error()}
	}

	localVarPath := localBasePath + "/api/conventions/{conventionId}/ticket-templates/{ticketTemplateId}"
	localVarPath = strings.Replace(localVarPath, "{"+"conventionId"+"}", url.PathEscape(parameterValueToString(r.conventionId, "conventionId")), -1)
	localVarPath = strings.Replace(localVarPath, "{"+"ticketTemplateId"+"}", url.PathEscape(parameterValueToString(r.ticketTemplateId, "ticketTemplateId")), -1)

	localVarHeaderParams := make(map[string]string)
	localVarQueryParams := url.Values{}
	localVarFormParams := url.Values{}

	// to determine the Content-Type header
	localVarHTTPContentTypes := []string{"application/json", "text/json", "application/*+json"}

	// set Content-Type header
	localVarHTTPContentType := selectHeaderContentType(localVarHTTPContentTypes)
	if localVarHTTPContentType != "" {
		localVarHeaderParams["Content-Type"] = localVarHTTPContentType
	}

	// to determine the Accept header
	localVarHTTPHeaderAccepts := []string{"text/plain", "application/json", "text/json"}

	// set Accept header
	localVarHTTPHeaderAccept := selectHeaderAccept(localVarHTTPHeaderAccepts)
	if localVarHTTPHeaderAccept != "" {
		localVarHeaderParams["Accept"] = localVarHTTPHeaderAccept
	}
	// body params
	localVarPostBody = r.ticketTemplateUpdateDto
	if r.ctx != nil {
		// API Key Authentication
		if auth, ok := r.ctx.Value(ContextAPIKeys).(map[string]APIKey); ok {
			if apiKey, ok := auth["Bearer"]; ok {
				var key string
				if apiKey.Prefix != "" {
					key = apiKey.Prefix + " " + apiKey.Key
				} else {
					key = apiKey.Key
				}
				localVarHeaderParams["Authorization"] = key
			}
		}
	}
	req, err := a.client.prepareRequest(r.ctx, localVarPath, localVarHTTPMethod, localVarPostBody, localVarHeaderParams, localVarQueryParams, localVarFormParams, formFiles)
	if err != nil {
		return localVarReturnValue, nil, err
	}

	localVarHTTPResponse, err := a.client.callAPI(req)
	if err != nil || localVarHTTPResponse == nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	localVarBody, err := io.ReadAll(localVarHTTPResponse.Body)
	localVarHTTPResponse.Body.Close()
	localVarHTTPResponse.Body = io.NopCloser(bytes.NewBuffer(localVarBody))
	if err != nil {
		return localVarReturnValue, localVarHTTPResponse, err
	}

	if localVarHTTPResponse.StatusCode >= 300 {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: localVarHTTPResponse.Status,
		}
		if localVarHTTPResponse.StatusCode == 401 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
			return localVarReturnValue, localVarHTTPResponse, newErr
		}
		if localVarHTTPResponse.StatusCode == 404 {
			var v ErrorResponse
			err = a.client.decode(&v, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
			if err != nil {
				newErr.error = err.Error()
				return localVarReturnValue, localVarHTTPResponse, newErr
			}
					newErr.error = formatErrorMessage(localVarHTTPResponse.Status, &v)
					newErr.model = v
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	err = a.client.decode(&localVarReturnValue, localVarBody, localVarHTTPResponse.Header.Get("Content-Type"))
	if err != nil {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: err.Error(),
		}
		return localVarReturnValue, localVarHTTPResponse, newErr
	}

	return localVarReturnValue, localVarHTTPResponse, nil
}
