using AutoMapper;
using Invest.Application.DTOS;
using Invest.Domain;

namespace Invest.Application.Helpers
{
    public class InvestProfile : Profile
    {
        public InvestProfile()
        {
            //Mapeamento de Consulta de Cotista
            CreateMap<Cotista,CotistaConsultaDto>().ReverseMap();

            //Mapeamento de para registro Costista
            CreateMap<Cotista,CotistaRegisterDto>().ReverseMap();

            //Mapeamento de Consulta de Operacao
            CreateMap<Operacao,OperacaoConsultaDto>().ReverseMap();

            //Mapeamento de para registro Operacao
            CreateMap<Operacao,OperacaoRegisterDto>().ReverseMap();
        }
        
    }
}