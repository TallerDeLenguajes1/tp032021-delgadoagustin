using AutoMapper;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP3web.Models.ViewModels;

namespace TP3web
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
