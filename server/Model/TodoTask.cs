namespace Model
{
    public class TodoTask
    {
        public TodoTask(string text, bool done, User user) {
            this.Text = text;
            this.Done = done;
            this.User = user;
        }

        public TodoTask(string text, bool done) {
            this.Text = text;
            this.Done = done;
        }

        public long TodoTaskId { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public User? User { get; set; }

        public override string ToString() {
            return $"{TodoTaskId}, {Text}, {Done}, {User}";
        }
    }
}