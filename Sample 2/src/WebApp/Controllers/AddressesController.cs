using Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressesController : Controller
{
    private readonly ICustomersRepository _repository;

    public AddressesController(ICustomersRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get(string? countryCode)
    {
        var addresses = _repository
            .GetAll()
            .SelectMany(customer => customer.Addresses
                .Where(address => address.CountryCode == countryCode!));
        return Ok(addresses);
    }
}