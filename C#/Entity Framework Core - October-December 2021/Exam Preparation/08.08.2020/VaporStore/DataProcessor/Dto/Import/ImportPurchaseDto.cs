using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType(TypeName = "Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlElement]
        public string Type { get; set; }

        [Required]
        [XmlElement]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string Key { get; set; }

        [Required]
        [XmlElement]
        public string Date { get; set; }

        [Required]
        [XmlElement]
        public string Card { get; set; }

        [Required]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
    }
}
