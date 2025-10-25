using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Responses;

// Suppress OPENAI001 warning for evaluation-only API usage
#pragma warning disable OPENAI001

namespace DocGen
{
    public class Response
    {
        readonly public static string API_KEY = "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";

        public static string getOpenAIResponse()
        {
            OpenAIResponseClient client = new(model: "gpt-5", apiKey: API_KEY);

            OpenAIResponse response = client.CreateResponse(
                "Write a one-sentence bedtime story about a unicorn."
            );

            return response.GetOutputText();
        }
    }
}

#pragma warning restore OPENAI001
