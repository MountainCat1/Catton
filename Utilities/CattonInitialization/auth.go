package main

import (
	"bytes"
	"crypto/tls"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
)

type RegisterRequest struct {
	Email    string `json:"email"`
	Username string `json:"username`
	Password string `json:"password"`
}

type Credentials struct {
	Email    string `json:"email"`
	Password string `json:"password"`
}

type LoginResponse struct {
	AuthToken string `json:"authToken"`
}

func auth(authUrl string, credentials Credentials) (string, error) {
	url := authUrl // "https://localhost:5000/api/accounts/login"

	jsonData, err := json.Marshal(credentials)
	if err != nil {
		fmt.Println("Could not parse data")
		return "", err
	}
	req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonData))

	if err != nil {
		fmt.Println("Could not create request")
		return "", err
	}

	req.Header.Set("Content-Type", "application/json")

	client := &http.Client{
		Transport: &http.Transport{
			TLSClientConfig: &tls.Config{InsecureSkipVerify: true},
		},
	}

	resp, err := client.Do(req)
	if err != nil {
		fmt.Println("Could not send request")
		fmt.Println(err.Error())
		return "", err
	}
	defer resp.Body.Close()

	body, err := io.ReadAll(resp.Body)

	if err != nil {
		fmt.Println("Could not parse response")
		return "", err
	}
	loginResponse := LoginResponse{}

	err = json.Unmarshal(body, &loginResponse)

	if err != nil {
		fmt.Println("Could not parse response")
		return "", err
	}

	return loginResponse.AuthToken, nil
}
