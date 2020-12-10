using AutoMapper;
using ExerciseA.API.Controllers.Order.Response;
using ExerciseA.API.Requests;
using ExerciseA.Domain.DataContext;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;

namespace ExerciseA.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<PaginationRequest, PaginationFilter>();

            // Orders
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.OrderId,
                    opt => opt.MapFrom
                    (src => src.Id));

            CreateMap<OrderDetail, OrderDetailResponse>()
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom
                    (src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice,
                    opt => opt.MapFrom
                    (src => src.Product.Price));

            CreateMap<GetAllOrdersFilterRequest, GetAllOrdersFilter>();

            CreateMap<OrderDetailEditRequest, OrderDetailDataContext>();
        }
    }
}
