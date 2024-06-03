﻿using B3Digitas.Todo.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace B3Digitas.Todo.Domain.Entities;

public class Todo
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    public DateTime CreatedAt{ get; set; }
    
    public DateTime EndsAt{ get; set; }
    
    public TodoStatus Status { get; set; }
    
    public Tag Tag { get; set; } = new Tag();  
    
}