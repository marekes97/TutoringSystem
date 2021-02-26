using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI
{
    public class TutoringSystemProfile : Profile
    {
        public TutoringSystemProfile()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<SchoolDto, School>()
                .ForMember(s => s.Name, map => map.MapFrom(sDto => sDto.SchoolName));
            CreateMap<ContactDto, Contact>();
            CreateMap<PhoneNumberDto, PhoneNumber>();

            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentDetailsDto>();
            CreateMap<RegisterUserDto, Student>()
                .ForMember(u => u.Address, map => map.MapFrom(uDto => uDto.Address))
                .ForMember(u => u.School, map => map.MapFrom(uDto => uDto.School))
                .ForMember(u => u.Contact, map => map.MapFrom(uDto => uDto.Contact));
        }
    }
}
