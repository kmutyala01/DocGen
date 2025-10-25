using DocGen;
using LibGit2Sharp;
using System.IO;


// Define the repository URL and local path
string repoUrl = args.Length == 0 ?  "https://github.com/kmutyala01/ApartmentTracker" : args[0];

string localPath = "C:\\Users\\karth\\source\\repos\\DocGen\\ClonedRepos";

// Clone the repository if it doesn't exist locally
if (!Directory.Exists(localPath))
{
    Repository.Clone(repoUrl, localPath);
    Console.WriteLine("Repository cloned.");
}
else
{
    Console.WriteLine("Repository already exists locally.");
}
Console.WriteLine(Response.getOpenAIResponse()); 

// Enumerate and print all files in the cloned repository
//foreach (var file in Directory.EnumerateFiles(localPath, "*.*", SearchOption.AllDirectories))
//{
//    if (!file.Contains($"{Path.DirectorySeparatorChar}.git{Path.DirectorySeparatorChar}"))
//    {
//        try
//        {
//            string content = File.ReadAllText(file);
//            Console.WriteLine(content);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Could not read file: {ex.Message}");
//        }
//    }
//}


