using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quize_api.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string name { get; set; }

        public int score { get; set; }

        public int TimceTaken { get; set; }

    }
}
