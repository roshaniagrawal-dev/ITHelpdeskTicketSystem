using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ITHelpdeskTicketSystem.Data.Entities;

public partial class Ticket
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string TicketType { get; set; } = null!;

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public int Priority { get; set; }

    public int Status { get; set; }

    public DateTime CreatedOn { get; set; }

    [StringLength(50)]
    public string? AssetTag { get; set; }

    [StringLength(100)]
    public string? ApplicationName { get; set; }

    [StringLength(100)]
    public string? SystemName { get; set; }

    [StringLength(200)]
    public string? AssignedTo { get; set; }

    [InverseProperty("Ticket")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
