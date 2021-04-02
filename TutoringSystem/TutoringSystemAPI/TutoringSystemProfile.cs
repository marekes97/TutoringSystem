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

            CreateMap<Student, UserDto>()
                .ReverseMap();

            CreateMap<Student, StudentDetailsDto>();
            CreateMap<RegisterUserDto, Student>()
                .ForMember(u => u.Address, map => map.MapFrom(uDto => uDto.Address))
                .ForMember(u => u.School, map => map.MapFrom(uDto => uDto.School))
                .ForMember(u => u.Contact, map => map.MapFrom(uDto => uDto.Contact));

            CreateMap<AdditionalOrder, OrderDto>();
            CreateMap<OrderDto, AdditionalOrder>();

            CreateMap<AdditionalOrder, OrderDetailsDto>();
            CreateMap<OrderDetailsDto, AdditionalOrder>();

            CreateMap<Reservation, ReservationDto>()
                .ForMember(rDto => rDto.Duration, map => map.MapFrom(r => r.Lesson.Duration));

            CreateMap<TutorReservationDetailsDto, Reservation>()
                .ForPath(r => r.Lesson.Duration, map => map.MapFrom(rDto => rDto.Duration))
                .ForPath(r => r.Subject.Name, map => map.MapFrom(rDto => rDto.Subject))
                .ForPath(r => r.Lesson.Description, map => map.MapFrom(rDto => rDto.Description))
                .ForPath(r => r.Student.UserName, map => map.MapFrom(rDto => rDto.StudentName))
                .ReverseMap();

            CreateMap<Reservation, StudentReservationDetailsDto>()
                .ForMember(r => r.Duration, map => map.MapFrom(rDto => rDto.Lesson.Duration))
                .ForMember(r => r.Subject, map => map.MapFrom(rDto => rDto.Subject.Name))
                .ForMember(r => r.Description, map => map.MapFrom(rDto => rDto.Lesson.Description));

            CreateMap<Interval, IntervalDto>();
            CreateMap<Availability, AvailabilityDto>();
        }
    }
}
