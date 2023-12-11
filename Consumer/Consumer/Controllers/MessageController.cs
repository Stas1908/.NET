using Consumer.Model;
using lab1_efApi.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController:ControllerBase
    {
        private readonly IPublishEndpoint _publish;
        public MessageController(IPublishEndpoint publish)
        {
            _publish = publish;
        }
        [HttpPost]
        public async Task<ActionResult<Orders>> Create([FromBody] Orders orders)
        {
            await _publish.Publish<Orders>(orders);
            return Ok();
            //return Ok(await _orderService.Create(orders));
        }
    }
}
