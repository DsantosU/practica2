﻿using Microsoft.AspNetCore.Mvc;
using RI.Novus.Core.Boundaries.Persistence;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers
{
    [Route("api/ImmovableOwners")]
    [ApiController]
    public sealed class ImmovableOwnersController : ControllerBase
    {

        private readonly IImmovableOwnersRepository _ImmovableOwnerRepository;
        private readonly IImmovablePropertyRepository _ImmovablePropertyRepository;


        public ImmovableOwnersController(IImmovableOwnersRepository immovableOwnerRepository, IImmovablePropertyRepository immovablePropertyRepository)
        {
            _ImmovableOwnerRepository = immovableOwnerRepository;
            _ImmovablePropertyRepository = immovablePropertyRepository;
        }

        [HttpGet]
        public IActionResult GetImmovablesOwners()
        {
            return Ok(_ImmovableOwnerRepository.GetImmovableOwners().Select(ImmovableOwnerModel.FromEntity));

        }


        [HttpPost]
        public IActionResult SaveImmovableOwner([FromBody] ImmovableOwnerModel immovableOwnerModel)
        {
            RI.Novus.Core.Immovable.ImmovableOwners.ImmovableOwner immovableOwner = immovableOwnerModel.ToEntity();
            immovableOwner.Persist(_ImmovableOwnerRepository);

            return Ok();

        }

        [HttpDelete("{ownerId}/properties/{propertyId}")]

        public IActionResult DeleteImmovableProperty(Guid ownerId, Guid propertyId)
        {
            var immovableOwner = _ImmovableOwnerRepository.GetImmovableOwnerById(ownerId);
            immovableOwner.DeleteProperty(_ImmovablePropertyRepository, propertyId);

            return Ok();
        }

        [HttpPut("{ownerId}/properties/{propertyId}")]
        public IActionResult UpdateImmovableProperty(Guid ownerId, Guid propertyId, [FromBody] ImmovablePropertyModel immovablePropertyModel)
        {
            var property = immovablePropertyModel.ToEntity();
            var owner = _ImmovableOwnerRepository.GetImmovableOwnerById(ownerId);
            owner.Update(_ImmovablePropertyRepository, propertyId, property);
            return Ok();
        }
    }
}
