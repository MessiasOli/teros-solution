﻿using TEROS.Domain.Model.OpenBanking;

namespace TEROS.Domain.Services
{
    public class OpenBankingService : IOpenBankingService
    {
        public Configuration Configuration { get; set; }
        public ICollection<Organization> Organizations { get; set; }
    }
}
