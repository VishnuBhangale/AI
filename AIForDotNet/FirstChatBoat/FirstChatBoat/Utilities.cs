namespace FirstChatBoat
{
    internal static class Utilities
    {
        internal static void LoadEnvFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            foreach (var rawLine in File.ReadLines(path))
            {
                var line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split('=', 2);
                if (parts.Length != 2)
                    continue;

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                if (value.EndsWith(";"))
                {
                    value = value.TrimEnd(';');
                }

                if ((value.StartsWith('"') && value.EndsWith('"')) ||
                    (value.StartsWith('\'') && value.EndsWith('\'')))
                {
                    value = value.Substring(1, value.Length - 2);
                }

                Environment.SetEnvironmentVariable(key, value);
            }
        }
    }
}
