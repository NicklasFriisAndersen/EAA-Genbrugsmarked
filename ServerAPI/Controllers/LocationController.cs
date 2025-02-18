﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/location")]
public class LocationController : ControllerBase
{
	private ILocationRepository _locationRepository;
	public LocationController(ILocationRepository locationRepository)
	{
		_locationRepository = locationRepository;
	}

	[HttpGet("getAllLocations")]
	public IActionResult GetLocations()
	{
		var locations = _locationRepository.SendLocations();
		return Ok(locations);
	}
}