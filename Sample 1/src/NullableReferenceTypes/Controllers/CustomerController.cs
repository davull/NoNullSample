using Microsoft.AspNetCore.Mvc;
using NullableReferenceTypes.Repositories;

namespace NullableReferenceTypes.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerRepository _repository = new();

    [HttpGet]
    [Route("api/customers/{customerId:int}")]
    public IActionResult Get(int customerId)
    {
        var customer = _repository.GetCustomer(customerId);
        return customer is null
            ? NotFound()
            : Ok(CustomerDtoFactory.Create(customer));
    }
}