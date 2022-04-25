using PDE.App.Services;
using System;



namespace PDE.App.Models
{
    public class WorkItem : IIdentifiable
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeSpan Total
        {
            get => End - Start;
        }

        public string Id { get; set; }
    }
}
