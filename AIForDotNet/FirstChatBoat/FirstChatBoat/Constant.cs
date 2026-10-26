namespace FirstChatBoat
{
    public static class Constant
    {
        public static string OpenAIKey => Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? string.Empty;
        public static string Model => Environment.GetEnvironmentVariable("OPENAI_MODEL") ?? "gpt-5.4-nano";
    }
}
