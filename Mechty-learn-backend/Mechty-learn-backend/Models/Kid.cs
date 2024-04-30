using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models.EducationalModels.EducationalProcess;
using Microsoft.AspNetCore.Identity;

namespace Mechty_learn_backend.Models;

public class Kid : IdentityUser
{
    public int Score = 0;
    public Progress KidProgress = Progress.zero;
    public User3DIcon Icon;
}