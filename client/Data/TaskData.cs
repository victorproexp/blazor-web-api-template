public class TaskData {
    public TaskData(long todoTaskId, string text, bool done) {
        this.TodoTaskId = todoTaskId;
        this.Text = text;
        this.Done = done;
    }

    public long TodoTaskId { get; set; }
    public string Text { get; set; }
    public bool Done { get; set; }
}