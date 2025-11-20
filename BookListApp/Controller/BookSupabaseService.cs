using BookListApp.Models;
using System;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookListApp.Controller
{
    public class BookSupabaseService
    {
        private readonly HttpClient _http;
        private const string BaseUrl = "https://ugodonfunwjqvwbmhepv.supabase.co";
        private const string ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InVnb2RvbmZ1bndqcXZ3Ym1oZXB2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjM1OTA3NTQsImV4cCI6MjA3OTE2Njc1NH0.9KdBdzhkG5t9RC74JToza33qs9m7Urs3I-Amn2XmWHU";

        public BookSupabaseService(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.Clear();
            _http.DefaultRequestHeaders.Add("apikey", ApiKey);
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", ApiKey);
        }

        public async Task<List<Book>> LoadBooksAsync()
        {
            // WICHTIG: Fügen Sie hier Ihren Tabellennamen ein!
            var response = await _http.GetAsync($"{BaseUrl}/books?select=*");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Book>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<Book>();
        }
    }
}