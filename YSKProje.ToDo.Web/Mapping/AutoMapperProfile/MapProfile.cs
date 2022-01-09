using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.AciliyetDto;
using YskProje.Todo.DTO.DTOs.AppUserDto;
using YskProje.Todo.DTO.DTOs.GorevDto;
using YskProje.Todo.DTO.DTOs.RaporDto;
using YskProje.Todo.DTO.DTOs.UrunDto;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            #region Aciliyet-AciliyetDto
            CreateMap<AciliyetAddDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetAddDto>();
            CreateMap<AciliyetListDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetListDto>();
            CreateMap<AciliyetUpdateDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSigInDto, AppUser>();
            CreateMap<AppUser, AppUserSigInDto>();
            #endregion

            #region Gorev-GorevDto
            CreateMap<GorevAddDto, Gorev>();
            CreateMap<Gorev, GorevAddDto>();
            CreateMap<GorevListDto, Gorev>();
            CreateMap<Gorev, GorevListDto>();
            CreateMap<GorevUpdateDto, Gorev>();
            CreateMap<Gorev, GorevUpdateDto>();
            CreateMap<GorevAllListDto, Gorev>();
            CreateMap<Gorev, GorevAllListDto>();
            #endregion

            #region Rapor-RaporDto
            CreateMap<RaporAddDto, Rapor>();
            CreateMap<Rapor, RaporAddDto>();
            CreateMap<RaporUpdateDto, Rapor>();
            CreateMap<Rapor, RaporUpdateDto>();
            #endregion

            #region Urun-UrunDto
            CreateMap<UrunAddDto, Urun>();
            CreateMap<Urun, UrunAddDto>();
            CreateMap<UrunListDto, Urun>();
            CreateMap<Urun, UrunListDto>();
            CreateMap<UrunUpdateDto, Urun>();
            CreateMap<Urun, UrunUpdateDto>();
    
            #endregion
        }
    }
}
