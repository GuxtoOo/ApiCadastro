using AutoMapper;
using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.ViewModel;
using System.Reflection;

namespace AvonalleRegisterApi.Configurations;

public static class AutoMapperConfigurations
{
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assembly);

        return services;
    }
}
public class AutoMapperFastMapper : Profile
{
    public AutoMapperFastMapper()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<CreateProductViewModel, Product>().ReverseMap();
    }
}
