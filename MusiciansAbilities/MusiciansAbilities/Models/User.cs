using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansAbilities.Models;
[Table("Users")]
public class User
{
    [Key] public int Id { get; set; }
    public string SecretId { get; set; }
    public DateTime Timestamp { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string Instrument { get; set; }
    public string TimeSpentPracticing { get; set; }
    public string Education { get; set; }
    public List<ExperimentResult> ExperimentResults { get; set; }
}