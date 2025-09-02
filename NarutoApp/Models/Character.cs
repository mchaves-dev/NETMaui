namespace NarutoApp.Models;

public sealed class Character
{
    public int id { get; set; }
    public string name { get; set; }
    public string []? images { get; set; }
    public string firsImage => images?.FirstOrDefault();
    public Personal personal { get; set; }
}

public class Personal
{
    public object clan { get; set; }
}