using Jazani.Application.Cores.Services;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IInvestmentconceptService:IQueryService<InvestmentconceptDto,int>
    {
    }
}
