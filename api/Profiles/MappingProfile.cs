using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using api.Models;
using api.DTOs;

namespace api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateInvoiceMasterDTO, InvoiceMaster>();
            CreateMap<CreateInvoiceItemDTO, InvoiceItemDetail>();

            CreateMap<InvoiceMaster, InvoiceResponseDTO>();
            CreateMap<InvoiceItemDetail, InvoiceItemResponseDTO>();
            
            
            CreateMap<UpdateInvoiceMasterDTO, InvoiceMaster>();
            CreateMap<UpdateInvoiceItemDTO, InvoiceItemDetail>();
        }
    }
}