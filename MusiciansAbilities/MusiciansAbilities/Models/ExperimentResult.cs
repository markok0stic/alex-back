using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansAbilities.Models;
[Table("ExperimentResults")]
public class ExperimentResult
{
    [Key] public int Id { get; set; }
    public string Result { get; set; }
    public string Answer { get; set; }
    public int ReactionTime { get; set; }
}