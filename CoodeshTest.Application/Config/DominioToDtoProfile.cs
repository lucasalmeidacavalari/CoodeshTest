using AutoMapper;
using CoodeshTest.Application.Dto;
using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Config
{
    public class DominioToDtoProfile : Profile
    {
        public DominioToDtoProfile()
        {
            CreateMap<Creator, CreatorDto>().ReverseMap();
            CreateMap<Affiliated, AffiliatedDto>().ReverseMap();
            CreateMap<Product, ProductDro>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
