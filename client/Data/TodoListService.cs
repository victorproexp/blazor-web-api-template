using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace TodoListBlazor.Data;

public class TodoListService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public TodoListService(HttpClient http, IConfiguration configuration) {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }

    public async Task<TaskData[]> GetTaskData()
    {
        string url = $"{baseAPI}tasks/";
        return await http.GetFromJsonAsync<TaskData[]>(url);
    }

    public async void PutTaskData(TaskData data)
    {
        Console.WriteLine("Put Task Data!");
        Console.WriteLine(data);
        TaskDataAPI newData = new TaskDataAPI(data.TodoTaskId, data.Text, data.Done);
        string url = $"{baseAPI}tasks/{data.TodoTaskId}";
        var res = await http.PutAsJsonAsync(url, newData);
        Console.WriteLine(res);
    }

    private record TaskDataAPI(long TodoTaskId, string text, bool done);
    
}
