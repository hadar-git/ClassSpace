using AutoMapper;
using DAL.Data;
using DTO;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionPostDto, Question>();
            CreateMap<QuestionUpdateDto, Question>();

            CreateMap<Vote, VoteDto>();
            CreateMap<VotePostDto, Vote>();

            CreateMap<Material, MaterialDto>();
            CreateMap<MaterialPostDto, Material>();
            CreateMap<MaterialUpdateDto, Material>();

            CreateMap<Assignment, AssignmentDto>();
            CreateMap<AssignmentPostDto, Assignment>();
            CreateMap<AssignmentUpdateDto, Assignment>();

            CreateMap<AssignmentUnit, AssignmentUnitDto>();
            CreateMap<AssignmentUnitPostDto, AssignmentUnit>();
        }
    }
}
