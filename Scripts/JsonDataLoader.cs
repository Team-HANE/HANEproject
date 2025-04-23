using Godot;
using System;
using System.Text.Json;

namespace escapetampere
{
    public static class JsonDataLoader
    {
        private static JsonElement? Data = null;

        public static JsonElement? Load(string path)
        {
            if (Data != null)
                return Data;

            if (!FileAccess.FileExists(path))
            {
                GD.PrintErr($"JSON file not found at path: {path}");
                return null;
            }

            try
            {
                using FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
                string jsonText = file.GetAsText();
                Data = JsonSerializer.Deserialize<JsonElement>(jsonText);
                return Data;
            }
            catch (Exception ex)
            {
                GD.PrintErr("Failed to load or parse JSON: " + ex.Message);
                return null;
            }
        }
    }
}