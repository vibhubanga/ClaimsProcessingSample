﻿using ClaimsProcessingSample.Application.Features.Brands.AddEdit;
using ClaimsProcessingSample.Application.Features.Brands.Delete;
using ClaimsProcessingSample.Application.Features.Brands.Queries.GetAll;
using ClaimsProcessingSample.Application.Features.Brands.Queries.GetById;
using ClaimsProcessingSample.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Server.Controllers.v1.Catalog
{
    public class BrandsController : BaseApiController<BrandsController>
    {
        [Authorize(Policy = Permissions.Brands.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
        }

        [Authorize(Policy = Permissions.Brands.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _mediator.Send(new GetBrandByIdQuery() { Id = id });
            return Ok(brand);
        }

        [Authorize(Policy = Permissions.Brands.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditBrandCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize(Policy = Permissions.Brands.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBrandCommand { Id = id }));
        }
    }
}