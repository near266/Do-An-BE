using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entites.Assesment;

namespace WebApi.Application.Contracts.Persistence
{
    public interface IAssessment_questions : IGenericRepository<assessment_questions>
    {
    }
}
