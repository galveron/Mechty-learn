using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

public class Lesson
{
    public int Id { get; init; }
    public List<Chapter> Chapters { get; init; } = new List<Chapter>();
}