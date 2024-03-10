using AutoMapper;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;

namespace Warehouse.ApplicationServices.Mappings
{
    public class BookCaseProfile : Profile
    {
        public BookCaseProfile()
        {
            this.CreateMap<AddBookCaseRequest, Warehouse.DataAccess.Entities.BookCase>()
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));

            this.CreateMap<EditBookCaseRequest, Warehouse.DataAccess.Entities.BookCase>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BookCaseId));

            this.CreateMap<DeleteBookCaseRequest, Warehouse.DataAccess.Entities.BookCase>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BookCaseId));

            this.CreateMap<Warehouse.DataAccess.Entities.BookCase, API.Domain.Models.BookCase>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Number, y => y.MapFrom(z => z.Number));
                
        }
    }
}
