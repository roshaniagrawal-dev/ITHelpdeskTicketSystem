using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ITHelpdeskTicketSystem.Data.Entities;

public partial class Comment
{
    [Key]
    public int Id { get; set; }

    public int TicketId { get; set; }

    [StringLength(500)]
    public string Text { get; set; } = null!;

    public DateTime PostedOn { get; set; }

    [ForeignKey("TicketId")]
    [InverseProperty("Comments")]
    public virtual Ticket Ticket { get; set; } = null!;
}
