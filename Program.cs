using LibGit2Sharp;
using System.IO;

// Define the repository URL and local path
string repoUrl = "https://github.com/kmutyala01/ApartmentTracker";
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

// Enumerate and print all files in the cloned repository
foreach (var file in Directory.EnumerateFiles(localPath, "*.*", SearchOption.AllDirectories))
{
    Console.WriteLine(file);
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

