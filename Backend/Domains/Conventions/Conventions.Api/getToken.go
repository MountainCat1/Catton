package main

import (
	"bytes"
	"crypto/tls"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
)

type Credentials struct {
	Email    string `json:"email"`
	Password string `json:"password"`
}

type LoginResponse struct {
	AuthToken string `json:"authToken"`
}

func main() {
	defer func() {
		fmt.Scanln()
	}()

	url := "https://localhost:5000/api/accounts/login"

	credentials := Credentials{"admin@admin.admin", "foo"}

	jsonData, err := json.Marshal(credentials)
	if err != nil {
		fmt.Println("Could not parse data")
		return
	}
	fmt.Println(string(jsonData))

	req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonData))

	if err != nil {
		fmt.Println("Could not create request")
		return
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
		return
	}
	defer resp.Body.Close()

	fmt.Println("response Status:", resp.Status)

	body, err := io.ReadAll(resp.Body)

	if err != nil {
		fmt.Println("Could not parse response")
		return
	}

	fmt.Println(string(body))

	loginResponse := LoginResponse{}

	err = json.Unmarshal(body, &loginResponse)

	if err != nil {
		fmt.Println("Could not parse response")
		return
	}

	fmt.Println("\n\nLogin successful! Auth header:")
	fmt.Println("Bearer " + loginResponse.AuthToken)
}
