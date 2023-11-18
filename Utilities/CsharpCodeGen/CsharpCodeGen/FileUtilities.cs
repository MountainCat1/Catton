namespace CsharpCodeGen;

public static class FileUtilities
{
    public static void MoveFiles(string sourceDirectory, string destinationDirectory)
    {
        // Get all file paths in the source directory
        string[] filePaths = Directory.GetFiles(sourceDirectory);

        // Move each file to the destination directory
        foreach (string filePath in filePaths)
        {
            // Extract the file name from the full path
            string fileName = Path.GetFileName(filePath);

            // Construct the new file path in the destination directory
            string newFilePath = Path.Combine(destinationDirectory, fileName);

            // Move the file
            File.Move(filePath, newFilePath);
        }
    }

    public static void ClearDirectory(string sourceDirectory)
    {
        // Get all file paths in the source directory
        var filePaths = Directory.GetFiles(sourceDirectory).Where(x => x.EndsWith(".cs"));

        // Move each file to the destination directory
        foreach (string filePath in filePaths)
        {
            // Extract the file name from the full path
            string fileName = Path.GetFileName(filePath);

            File.Delete(fileName);
            Console.WriteLine($"Removing {fileName}...");
        }
    }
}