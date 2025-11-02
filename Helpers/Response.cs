using LibGit2Sharp;
using Microsoft.Extensions.Configuration;
using OpenAI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Suppress OPENAI001 warning for evaluation-only API usage
#pragma warning disable OPENAI001

namespace DocGen.Helpers
{
    public class Response
    {
        private readonly string _apiKey;

        public Response(IConfiguration configuration)
        {
            _apiKey = configuration["OpenAI:ApiKey"]
                ?? throw new InvalidOperationException("OpenAI:ApiKey not found in configuration.");
        }


        public string getOpenAIResponse(string prompt)
        {
            OpenAIResponseClient client = new(model: "gpt-5-mini", apiKey: _apiKey);

            OpenAIResponse response = client.CreateResponse("Please provide a breif high level overview of " + prompt);

            return response.GetOutputText();
        }
    }
}

#pragma warning restore OPENAI001
