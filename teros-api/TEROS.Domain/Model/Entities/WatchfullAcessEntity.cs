﻿namespace TEROS.Domain.Model.Entities
{
    public class WatchfullAcessEntity
    {
        public Guid Id { get; set; }
        public string AccessTime { get; set; }
        public string Username { get; set; }
        public int Updates { get; set; }
    }
}
