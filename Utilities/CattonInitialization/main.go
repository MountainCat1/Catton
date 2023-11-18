package main

import (
	accountsApi "catton_initialization/openapi-go/accounts"
	context "context"
	"crypto/tls"
	"net/http"
)

func main() {
	client := &http.Client{
		Transport: &http.Transport{
			TLSClientConfig: &tls.Config{InsecureSkipVerify: true},
		},
	}

	configuration := accountsApi.NewConfiguration()
	configuration.HTTPClient = client
	configuration.Host = "localhost:5000"
	configuration.Scheme = "https"

	apiClient := accountsApi.NewAPIClient(configuration)

	context := context.Background()


	username := "test"
	contract := accountsApi.CreatePasswordAccountRequestContract{
		Email: "test@test.test"
		Password: "foo"
		Username: *accountsApi.NewNullableString(&username)}
	}

	apiClient.AccountAPI.ApiAccountsPostExecute(accountsApi.ApiApiAccountsPostRequest{
		context,
		apiClient,
	})

}
