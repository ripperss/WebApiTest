﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
