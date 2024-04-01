using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WPF_project_N_000047.Models;

public class Film
{
    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("filmName")]
    public string? FilmName { get; set; }

    [JsonPropertyName("imagePath")]
    public string? ImagePath { get; set; }

    [JsonPropertyName("filmContent")]
    public string? FilmContent { get; set; }

    [JsonPropertyName("seanses")]
    public string[]? Seanses { get; set; }
}