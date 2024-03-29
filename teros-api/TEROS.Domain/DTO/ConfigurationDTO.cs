﻿using TEROS.Domain.Model.Enum;
using TEROS.Domain.Model.OpenBanking;

namespace TEROS.Domain.DTO
{
    public readonly record struct ConfigurationDTO
    {
        public ConfigurationDTO(Configuration configuration) : this()
        {
            LastSystemUpdate = configuration.LastSystemUpdate;
            LastUpdate = configuration.LastUpdate;
            StatusDatabase = configuration.StatusDatabase;
            UpdateCycle = configuration.UpdateCycle;

        }

        public string LastSystemUpdate { get; init; }
        public string LastUpdate { get; init; }
        public int UpdateCycle { get; init; }
        public DatabaseStatus StatusDatabase { get; init; }
    }
}
