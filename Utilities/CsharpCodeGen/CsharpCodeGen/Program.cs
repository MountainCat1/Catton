using System.Globalization;
using System.Net;
using System.Reflection;
using CsharpCodeGen;
using NSwag;
using NSwag.CodeGeneration.CSharp;

internal class Program
{
    public static async Task Main(string[] args)
    {
        WebClient wclient = new WebClient();

        var docNames = LoadSource();

        Console.WriteLine(GetSourceCodeDirectory());
        var targetDirectory = Path.Combine(GetSourceCodeDirectory(), "generated");
        Directory.CreateDirectory(targetDirectory);
        FileUtilities.ClearDirectory(targetDirectory);

        foreach (var docName in docNames)
        {
            Console.WriteLine($">  Generating client for {docName}");
            try
            {
                await GenerateClient(docName, "v1");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine();
        }


        async Task GenerateClient(string docsName, string version)
        {
            var url = $"http://localhost:4000/swagger/docs/{version}/{docsName}";
            Console.WriteLine($"Generating api client from {url}");
            var document = await OpenApiDocument.FromJsonAsync(wclient.DownloadString(url));

            wclient.Dispose();

            var className = ConvertToPascalCase($"{docsName}-api");

            var codeNamespace = $"OpenApi.{ConvertToPascalCase(docsName)}";
            
            var settings = new CSharpClientGeneratorSettings()
            {
                ClassName = className,
                CSharpGeneratorSettings =
                {
                    Namespace = codeNamespace,
                    GenerateJsonMethods = true,
                    
                    ExcludedTypeNames = new[] { $"ErrorResponse" }
                },
                GenerateClientInterfaces = true,
                ClientBaseInterface = "IApiClient",
                
                GenerateClientClasses = true,
                ClientBaseClass = "ApiClient",
                
                UseBaseUrl = false,
                AdditionalNamespaceUsages = new []{"Catton.ApiClient", "Catut.Application.Exceptions", "Catut.Application.Dtos"},
                GeneratePrepareRequestAndProcessResponseAsAsyncMethods = true,
                
                GenerateExceptionClasses = false,
                
                
            };


            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();

            string projectDirectory = GetSourceCodeDirectory(); // Get the project directory
            string filePath =
                Path.Combine(projectDirectory,
                    $"generated\\{className}.cs"); // Specify the file path within the project directory

            Console.WriteLine(filePath);

            using var file = File.Open(filePath, FileMode.OpenOrCreate);
            using var streamWriter = new StreamWriter(file);

            streamWriter.WriteLine(code);
        }

        static string[]? LoadSource()
        {
            string projectDirectory = Directory.GetCurrentDirectory(); // Get the project directory
            string filePath = Path.Combine(projectDirectory, "source.md");

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                return lines;
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }

            throw new NotImplementedException();
        }
    }

    private static string ConvertToPascalCase(string input)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string[] words = input.Split('-', '.');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = textInfo.ToTitleCase(words[i]);
        }

        return string.Join("", words);
    }
    
    public static string GetSourceCodeDirectory()
    {
        // Get the current working directory
        string currentDirectory = Environment.CurrentDirectory;

        // Navigate up the directory structure until reaching the source code directory
        string sourceCodeDirectory = currentDirectory;
        while (!System.IO.File.Exists(System.IO.Path.Combine(sourceCodeDirectory, "Program.cs")))
        {
            sourceCodeDirectory = System.IO.Directory.GetParent(sourceCodeDirectory)?.FullName;
            if (sourceCodeDirectory == null)
            {
                throw new Exception("Unable to determine the source code directory.");
            }
        }

        // Return the directory containing the source code
        return sourceCodeDirectory;
    }
}