using System;
namespace Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Deleted { get; set; }       
    }
}