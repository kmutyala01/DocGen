using DocGen.Helpers;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using LibGit2Sharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<Response>();
    })
    .Build();

var responseService = host.Services.GetRequiredService<Response>();



string repoUrl = args.Length == 0 ? "https://github.com/qeeqbox/social-analyzer" : args[0];

string localPath = "C:\\Users\\karth\\source\\repos\\DocGen\\ClonedRepos";


if (!Directory.Exists(localPath))
{
    Repository.Clone(repoUrl, localPath);
    Console.WriteLine("Repository cloned.");
}
else
{
    Console.WriteLine("Repository already exists locally.");
}
var input = FileParser.ParseThroughDirectoryAndGetFileContent(localPath);

File.WriteAllText("C:\\Users\\karth\\source\\repos\\DocGen\\AIResponse.txt", responseService.getOpenAIResponse(input));


