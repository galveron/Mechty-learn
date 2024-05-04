using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

[PrimaryKey(nameof(Id), nameof(ChapterId))]
public class ChapterPage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public int ChapterId { get; init; }
    
    public string? ChapterPageTitle { get; init; }
    public string? ChapterPageDescription { get; init; }
}