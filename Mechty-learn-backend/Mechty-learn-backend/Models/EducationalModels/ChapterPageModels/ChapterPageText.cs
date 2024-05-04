using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mechty_learn_backend.Models;

[PrimaryKey(nameof(ChapterPageId))]
public class ChapterPageText
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public int ChapterPageId { get; init; }
    public ChapterPage ChapterPage { get; init; }
    public string ChapterPageTextUrl { get; init; }
}