using System.Collections.Generic;

namespace SiteBibliotecaMVC.Models
{
    public class BadRequestResponse
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public int? Status { get; set; }

        public string TraceId { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}