using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using Model;

namespace Service;

public class DataService
{
    private TodoContext db { get; }

    public DataService(TodoContext db) {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    public void SeedData() {
        User user = db.Users.FirstOrDefault()!;
        if (user == null) {
            user = new User("Kristian");
            db.Users.Add(user);
            db.Users.Add(new User("Søren"));
            db.Users.Add(new User("Mette"));
        }

        TodoTask task = db.Tasks.FirstOrDefault()!;
        if (task == null)
        {
            db.Tasks.Add(new TodoTask("Husk denne opgave", false, user));
            db.Tasks.Add(new TodoTask("Lave kaffe", true, user));
            db.Tasks.Add(new TodoTask("Betale regninger", false, user));
        }

        db.SaveChanges();
    }

    public List<TodoTask> GetTasks() {
        return db.Tasks
            .Include(task => task.User)
            .ToList();
    }

    public TodoTask GetTaskById(int id) {
        var task = db
            .Tasks
            .Where(task => task.TodoTaskId == id)
            .Include(t => t.User)
            .First();
        return task;
    }

    public string CreateTask(string text, bool done, int userId) {
        User user = db.Users.Where(user => user.UserId == userId).First();
        TodoTask task = new TodoTask(text, done, user);
        db.Tasks.Add(task);
        db.SaveChanges();
        return JsonSerializer.Serialize(
            new { msg = "New task created", newTask = task }
        );
    }

    public string UpdateTask(int id, string text, bool done) {
        Console.WriteLine("id er " + id);
        TodoTask task = db.Tasks.Where(task => task.TodoTaskId == id).First();
        task.Text = text;
        task.Done = done;
        db.SaveChanges();
        return JsonSerializer.Serialize(
            new { msg = "Task updated", task = task }
        );
    }

    public DbSet<User> GetUsers() {
        return db.Users;
    }

    public string CreateUser(string name) {
        var user = new User(name);
        db.Users.Add(user);
        db.SaveChanges();
        return JsonSerializer.Serialize(
            new { msg = "New user created", newUser = user });
    }
}