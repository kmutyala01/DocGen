using DocGen.Helpers;
using LibGit2Sharp;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string repoUrl = args.Length == 0 ? "https://github.com/qeeqbox/social-analyzer" : args[0];

string localPath = "C:\\Users\\karth\\source\\repos\\DocGen\\ClonedRepos";



Repository.Clone(repoUrl, localPath);
Console.WriteLine("Repository cloned.");



//var host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddSingleton<Response>();
//    })
//    .Build();

//var responseService = host.Services.GetRequiredService<Response>();
//Console.WriteLine(responseService.getOpenAIResponse("Who is the GOAT"));


