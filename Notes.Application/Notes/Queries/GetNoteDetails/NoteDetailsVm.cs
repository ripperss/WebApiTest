using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
  
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title, 
                note => note.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details,
                note => note.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.Id,
                note => note.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.EditDate,
                note => note.MapFrom(note => note.EditDate));

        }
    }
}
