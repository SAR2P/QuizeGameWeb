using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quize_api.Models
{
    public class Question
    {
        [Key]
        public int QnId { get; set; }


        [Column(TypeName ="nvarchar(250)")]
        public string QnInWords { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string? ImageName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string option1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string option2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string option3 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string option4 { get; set; }


        public int Answre { get; set; }

    }
}
