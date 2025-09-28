using System.Text.Json;
using DotnetKafka.Product.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetKafka.Product.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ILogger<ProductsController> logger) : ControllerBase
{
    private readonly ILogger<ProductsController> _logger = logger;
    private readonly string TopicName = "productTopic";
    private readonly KafkaProducer _kafkaProducer = new();

    [HttpPost]
    public ActionResult PostProduct(Models.Product product)
    {
        var productJson = JsonSerializer.Serialize(product);
        _kafkaProducer.ProduceMessage(TopicName, productJson);

        return Ok("product Added");
    }
}