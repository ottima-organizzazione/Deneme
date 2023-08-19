using Deneme.Application.Interfaces.Repositories;
using Deneme.Domain.Entities;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Persistence.Repositories
{
    public class CampaignRepository : GenericRepository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
