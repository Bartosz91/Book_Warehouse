using AutoMapper;
using Warehouse.ApplicationServices.API.Domain.BookElements;

namespace Warehouse.ApplicationServices.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<AddBookRequest, Warehouse.DataAccess.Entities.Book>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Year, y => y.MapFrom(z => z.Year));

            this.CreateMap<EditBookRequest, Warehouse.DataAccess.Entities.Book>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BookId));

            this.CreateMap<DeleteBookRequest, Warehouse.DataAccess.Entities.Book>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BookId));

            this.CreateMap<Warehouse.DataAccess.Entities.Book, API.Domain.Models.Book>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title));
        }
    }
}
