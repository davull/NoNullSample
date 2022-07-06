using Microsoft.AspNetCore.Mvc;
using OptionType.Repositories;

namespace OptionType.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerRepository _repository = new();

    [HttpGet]
    [Route("api/customers/{customerId:int}")]
    public IActionResult Get(int customerId)
    {
        var customer = _repository.GetCustomer(customerId);
        return customer.ToResult(CustomerDtoFactory.Create);
    }
}