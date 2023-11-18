package main

import (
	"encoding/json"
	"fmt"
	"io"
	"os"
)

func ReadJSONFile(path string, v any) error {
	settingsFile, err := os.Open(path)
	if err != nil {
		return fmt.Errorf("could not open file: %w", err)
	}
	defer settingsFile.Close()

	settingsFileBytes, err := io.ReadAll(settingsFile)
	if err != nil {
		return fmt.Errorf("could not read file: %w", err)
	}

	err = json.Unmarshal(settingsFileBytes, v)
	if err != nil {
		return fmt.Errorf("could not unmarshal file: %w", err)
	}

	return nil
}
