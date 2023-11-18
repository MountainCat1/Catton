package main

import (
	"context"
	"crypto/tls"
	openapi "environmentInitialization/swagger/accounts"
	"fmt"
	"net/http"
)

// Settings struct
type settings struct {
	AdminName     string `json:"adminUsername"`
	AdminPassword string `json:"adminPassword"`
	AdminEmail    string `json:"adminEmail"`
}

func main() {
	// Read settings file
	var settings = settings{}
	err := ReadJSONFile("settings.json", &settings)
	if err != nil {
		fmt.Println("Could not read settings file: ", err)
		return
	}

	fmt.Printf("Admin name: %s\n", settings.AdminPassword)

	// Create a TLS config with InsecureSkipVerify set to true
	tlsConfig := &tls.Config{
		InsecureSkipVerify: true,
	}

	// Create an HTTP transport using the TLS config
	transport := &http.Transport{
		TLSClientConfig: tlsConfig,
	}

	// Create an HTTP client with the custom transport
	httpClient := &http.Client{
		Transport: transport,
	}

	var configuration = openapi.NewConfiguration()
	configuration.Host = "localhost:5000"
	configuration.Scheme = "https"
	configuration.HTTPClient = httpClient

	accountApiClient := openapi.NewAPIClient(configuration)

	auth := context.WithValue(
		context.Background(),
		openapi.ContextAPIKeys,
		map[string]openapi.APIKey{
			"Authorization": {Key: "API_KEY_STRING"},
		},
	)

	model := openapi.CreatePasswordAccountRequestContract{
		Email:    settings.AdminEmail,
		Password: settings.AdminPassword,
		Username: settings.AdminName,
	}

	request := accountApiClient.AccountAPI.ApiAccountsPost(auth, o)
	response, err := accountApiClient.AccountAPI.ApiAccountsPostExecute(request)

	if err != nil {
		fmt.Println("Error while sending an http request: ", err)
		return
	}

	var responseBytes []byte
	response.Body.Read(responseBytes)

	fmt.Println(string(responseBytes))
}
