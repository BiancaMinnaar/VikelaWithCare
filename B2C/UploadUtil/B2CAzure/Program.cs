using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Globalization;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System.IO;
using B2CAzure;

namespace B2CAzureStorageClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                var uploader = new AzureUpload();
                var files = uploader.UploadFiles().Result;
                foreach (var file in files)
                    Console.WriteLine(file);
                var cors = uploader.EnableCORS().Result;
                Console.WriteLine(cors);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Making Request to Azure Blob Storage: ");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press Enter to close...");
                Console.ReadLine();
            }
        }

        static void HandleAction()
        {
        }
    }
}