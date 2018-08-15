using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace B2CAzure
{
    public class AzureUpload
    {
        private static string connectionStringTemplate = "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}";
        string storageAccountName = "stgvikeladevb2cstyling";
        string storageKey = "VuemZp8s4WC9JnOY4u0kEVAI7hevXOSZSRX6gtuJT+jfprdExKfiaS/dGnOZqpKmHr5UE4tankFVQg72gzccZA==";
        string containerName = "b2clogin3";
        string directoryPath = "/Alpha/Clients/DOTCOM/Development/Assopul/B2C/Vikela";
        CloudStorageAccount storageAccount;
        CloudBlobClient blobClient;
        CloudBlobContainer container;

        public AzureUpload()
        {
            // Upload File to Blob Storage
            storageAccount = CloudStorageAccount.Parse(String.Format(CultureInfo.InvariantCulture, connectionStringTemplate, storageAccountName, storageKey));
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(containerName);
        }

        public async Task<string[]> UploadFiles()
        {
            var fileNames = new List<string>();
            string absoluteDirPath = Path.GetFullPath(directoryPath);
            var allFiles = Directory.GetFiles(absoluteDirPath, "*.*", SearchOption.AllDirectories).ToList().Where(a => !a.Contains(".DS_Store"));
            foreach (string filePath in allFiles)
            {
                string relativePathAndFileName = filePath.Substring(filePath.IndexOf(absoluteDirPath) + absoluteDirPath.Length);
                relativePathAndFileName = relativePathAndFileName[0] == '/' ? relativePathAndFileName.Substring(1) : relativePathAndFileName;
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(relativePathAndFileName);
                blockBlob.Properties.ContentType = MapFileExtensionToContentType(relativePathAndFileName);
                using (var fileStream = System.IO.File.OpenRead(filePath))
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                    fileNames.Add(relativePathAndFileName);
                }
            }
            return fileNames.ToArray();
        }

        public async Task<string> EnableCORS()
        {
            // Enable CORS
            CorsProperties corsProps = new CorsProperties();
            corsProps.CorsRules.Add(new CorsRule
            {
                AllowedHeaders = new List<string> { "*" },
                AllowedMethods = CorsHttpMethods.Get,
                AllowedOrigins = new List<string> { "*" },
                ExposedHeaders = new List<string> { "*" },
                MaxAgeInSeconds = 200
            });

            ServiceProperties serviceProps = new ServiceProperties
            {
                Cors = corsProps,
                Logging = new LoggingProperties
                {
                    Version = "1.0",
                },
                HourMetrics = new MetricsProperties
                {
                    Version = "1.0"
                },
                MinuteMetrics = new MetricsProperties
                {
                    Version = "1.0"
                },
            };
            await blobClient.SetServicePropertiesAsync(serviceProps);
            return "Successfully set CORS policy, allowing GET on all origins.  See https://msdn.microsoft.com/en-us/library/azure/dn535601.aspx for more.";
        }

        private string MapFileExtensionToContentType(string relativePathAndFileName)
        {
            string extension = relativePathAndFileName.Substring(relativePathAndFileName.IndexOf('.'));
            return MimeTypes.MimeTypeMap.GetMimeType(extension);
        }
    }
}
