using System.ComponentModel.DataAnnotations;

namespace OnlineTranslatorStudio.Models
{
    public class OnlineTranslationRequest
    {
        [DataType(DataType.Text)]
        public string ProjectName { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string RawData { get; set; }
    }
}