using Application.Customers;
using Domain.Customers;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Functional;
using WebApp.Controllers.Dto;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : Controller
{
    private readonly ICustomersRepository _repository;

    public CustomersController(ICustomersRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var customers = _repository.GetAll();
        return Ok(customers);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var customer = _repository.Get(id);
        return customer.ToResult();
    }

    [HttpGet]
    [Route("{id:guid}/addresses")]
    public IActionResult GetAddresses(Guid id)
    {
        var customer = _repository.Get(id);

        var addresses = customer
            .Map(c => c.Addresses);

        return addresses.ToResult();
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateCustomerDto dto)
    {
        var customer = new Customer(
            id: Guid.NewGuid(),
            firstName: dto.FirstName!,
            lastName: dto.LastName,
            customerNumber: dto.CustomerNo);
        _repository.Add(customer);

        var result = new CreatedAtActionResult(
            actionName: nameof(Get),
            controllerName: "customers",
            routeValues: new
            {
                id = customer.Id
            },
            value: null);
        return result;
    }
}