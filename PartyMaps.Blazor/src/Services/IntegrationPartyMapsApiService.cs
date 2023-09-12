using System.Text;
using Newtonsoft.Json;
using src.Models.Dtos;
using src.Pages.Data.Dto;

namespace src.Services
{
    public class IntegrationPartyMapsApiService
    {
        private readonly HttpClient _httpClient;

        public IntegrationPartyMapsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateEvent(string? idCreator, string? name, string? description, decimal eventValue, DateTime eventDate) 
        {
            var resource = "api/events";

            var json = JsonConvert.SerializeObject(new {
                IdCreator = idCreator,
                Name = name,
                Description = description,
                EventValue = eventValue,
                EventDate = eventDate
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(resource, content);

            if (!response.IsSuccessStatusCode) 
            {
                var message = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(message);
            } 
        }

        public async Task<List<ResponseEventDto>> GetEvents() 
        {
            var resource = "api/events/list";

            var response = await _httpClient.GetAsync(resource);

            if (!response.IsSuccessStatusCode) 
            {
                var message = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
                throw new ArgumentException(message);
            } 


            var eventList = JsonConvert.DeserializeObject<List<ResponseEventDto>>(await response.Content.ReadAsStringAsync())!;
            return eventList;
        }

        public async Task<ChatDto[]> GetChatMessages(int take, int limit) 
        {
            var resource = $"api/chats?take={take}&limit={limit}";

            var response = await _httpClient.GetAsync(resource);

            if (!response.IsSuccessStatusCode) 
                return Array.Empty<ChatDto>();    

            var messages = JsonConvert.DeserializeObject<ChatDto[]>(await response.Content.ReadAsStringAsync())!;
            return messages;
        }
    }
}