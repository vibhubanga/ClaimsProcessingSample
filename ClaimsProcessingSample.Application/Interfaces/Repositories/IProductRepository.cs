﻿using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<bool> IsBrandUsed(int brandId);
    }
}