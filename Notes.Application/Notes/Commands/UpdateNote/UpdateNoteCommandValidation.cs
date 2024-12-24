using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandValidation : AbstractValidator<UpdateNote>
{
    public UpdateNoteCommandValidation()
    {
        RuleFor(updateNote => updateNote.Title).NotEmpty().MaximumLength(100);
        RuleFor(updateNote => updateNote.UserId).NotEqual(Guid.Empty);
        RuleFor(UpdateNote => UpdateNote.Id).NotEqual(Guid.Empty);

    }
}
