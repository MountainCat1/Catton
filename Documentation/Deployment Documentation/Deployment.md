* All CI/CD pipelines are defined in /Pipelines folder. 
* Each pipeline is defined in a separate file. 
* The naming convention for the pipeline files is as follows: `<domain-name>-pipeline.yml`. The pipeline files are named as follows:

## Steps

#### Azure

* Create Azure Subscription
* Create app service for each domain
* Create Azure SQL Database
* Create Azure KeyVault
  * Add `JwtConfig` secret, value should be a json generated via `KeyGenerator` utility
  * Add `ConnectionStrings--Database` secret, value should be a connection string to the database
  * Add `ConnectionStrings--AzureBlobStorage` secret, value should be a connection string to the Azure Blob Storage
* Create Azure Storage Account
  * Create Container named `domain-config`
  * Add a file called `appsettings.json`
```json
{
  "KeyVault": {
    "Uri": "https://cattonkeyvault.vault.azure.net/",
    "TenantId": "6b604709-93e1-405d-8da4-92e36c5f9652",
    "ClientId": "fd2967e9-72b2-4353-a54f-d3248c7adb64",
    "ClientSecret": "LOADED FROM ENVIRONMENT VARIABLE"
  }
}
```

#### Azure DevOps
* Create Azure DevOps project
* Add all the pipelines to the project
* Add variable group to the project and give pipelines access to it, it should contain following secrets
  - `AzureBlobConnectionString`
  - `DomainKeyVaultSecret`


#### Backups
All persistent data is stored in Azure SQL Database. To perform a backup please follow official microsoft instruction:
https://learn.microsoft.com/en-us/azure/backup/tutorial-sql-backup