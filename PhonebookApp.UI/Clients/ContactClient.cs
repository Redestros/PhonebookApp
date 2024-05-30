using System.Net.Http.Json;
using PhonebookApp.Shared;
using PhonebookApp.UI.Models;

namespace PhonebookApp.UI.Clients;

public class ContactClient
{
    private readonly HttpClient _httpClient;

    public ContactClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ContactDto[]> Get()
    {
        var contacts = await _httpClient.GetFromJsonAsync<ContactDto[]>(_httpClient.BaseAddress);
        return contacts!;
    }

    public async Task<ContactDetailDto> Get(int id)
    {
        var contact = await _httpClient.GetFromJsonAsync<ContactDetailDto>($"{_httpClient.BaseAddress}/{id}");
        return contact!;
    }

    public async Task Create(CreateContactModel model)
    {
        await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress, model);
    }
    
    public async Task Update(int id, UpdateContactModel model)
    {
        await _httpClient.PutAsJsonAsync($"{_httpClient.BaseAddress}/{id}", model);
    }

    public async Task Delete(int id)
    {
        await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/{id}");
    }
}