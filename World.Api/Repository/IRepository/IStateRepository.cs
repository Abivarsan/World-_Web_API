﻿using World.Api.Models;

namespace World.Api.Repository.IRepository
{
    public interface IStateRepository : IGenericRepository<State>
    {
        Task update(State entity);
    }
}
