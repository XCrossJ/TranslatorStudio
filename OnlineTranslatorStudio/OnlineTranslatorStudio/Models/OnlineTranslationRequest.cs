using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTranslatorStudio.Models
{
    public class OnlineTranslationRequest
    {
        [DataType(DataType.Text)]
        public string ProjectName { get; set; }

        [DataType(DataType.MultilineText)]
        public string RawData { get; set; }
    }
}