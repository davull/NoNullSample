using EmptyObjects.Domain;
using EmptyObjects.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmptyObjects.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerRepository _repository = new();

    [HttpGet]
    [Route("api/customers/{customerId:int}")]
    public IActionResult Get(int customerId)
    {
        var customer = _repository.GetCustomer(customerId);
        return customer == Customer.Empty
            ? NotFound()
            : Ok(CustomerDtoFactory.Create(customer));
    }
}