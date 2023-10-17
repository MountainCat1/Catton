﻿using Azure.Storage.Blobs;
using Conventions.Api.Configuration;

namespace Conventions.Api.Extensions.ServiceCollection;

public static class AzureBlobConfigurationInstaller
{
    public static IConfigurationBuilder AddAzureBlobJsonConfiguration(this IConfigurationBuilder builder, BlobStorageConfig storageConfig, string fileName)
    {
        var blobServiceClient = new BlobServiceClient(storageConfig.ConnectionString);
        var blobClient = blobServiceClient.GetBlobContainerClient(storageConfig.ContainerName).GetBlobClient(fileName);

        using var memoryStream = new MemoryStream();
        blobClient.DownloadTo(memoryStream);
        memoryStream.Position = 0;

        return builder.AddJsonStream(memoryStream);
    }
}