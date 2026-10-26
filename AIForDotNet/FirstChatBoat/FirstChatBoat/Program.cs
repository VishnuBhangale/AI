using FirstChatBoat;
using OpenAI.Chat;

Utilities.LoadEnvFile(".env");

var model = Environment.GetEnvironmentVariable("OPENAI_MODEL") ?? "gpt-6-astra";
var key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

//string openkey = "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";

if (string.IsNullOrWhiteSpace(key))
{
    Console.WriteLine("OPENAI_API_KEY is missing. Add it to the .env file or your environment.");
    return;
}

try
{
    ChatClient client = new(model, key);
    var response = await client.CompleteChatAsync("What is the capital of India?");
    Console.WriteLine($"AI: {response.Value.Content[0].Text}");
}
catch (Exception ex)
{
    Console.WriteLine($"OpenAI request failed. Check that your API key is valid and has access to the model '{model}'.");
    Console.WriteLine(ex.Message);
}