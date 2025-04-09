using Godot;
using System;
using System.Text.Json;

namespace escapetampere
{
    public static class JsonDataLoader
    {
        private static JsonElement? cachedData = null;

        public static JsonElement? Load(string path)
        {
            if (cachedData != null)
                return cachedData;

            if (!FileAccess.FileExists(path))
            {
                GD.PrintErr($"JSON file not found at path: {path}");
                return null;
            }

            try
            {
                using FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
                string jsonText = file.GetAsText();
                cachedData = JsonSerializer.Deserialize<JsonElement>(jsonText);
                return cachedData;
            }
            catch (Exception ex)
            {
                GD.PrintErr("Failed to load or parse JSON: " + ex.Message);
                return null;
            }
        }
    }
}