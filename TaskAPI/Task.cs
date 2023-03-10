﻿namespace TaskAPI
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;    
        public string DueDate { get; set; } = string.Empty;     
        public string Status { get; set; } = string.Empty; 

    }
}
