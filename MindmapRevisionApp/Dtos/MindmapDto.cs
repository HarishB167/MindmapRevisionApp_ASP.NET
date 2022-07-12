using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindmapRevisionApp.Dtos
{
    public class MindmapDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int RevisionsCount { get; set; }
    }
}