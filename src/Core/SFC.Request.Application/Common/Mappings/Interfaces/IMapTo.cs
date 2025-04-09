using AutoMapper;

namespace SFC.Request.Application.Common.Mappings.Interfaces;
public interface IMapTo<T>
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
}

public interface IMapToReverse<T>
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
}