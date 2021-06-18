using AutoMapper;
using Client.BL.Interfaces;
using Client.Models.Models;
using Client.Models.Request;
using Client.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKClient.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]

        public class ComputerController : ControllerBase
        {
            //private readonly ProducerConfig config = new ProducerConfig 
            //{ 
            //    BootstrapServers = "localhost:9092" 
            //};

            //private readonly string topic = "Ticket_Base";
            private readonly IComputerService _computerService;
            private readonly IMapper _mapper;

            public ComputerController(IComputerService computerService, IMapper mapper)
            {
                _computerService = computerService;
                _mapper = mapper;
            }

            //[HttpPost]
            //  public IActionResult Post([FromQuery] string message)
            //  {
            //      return Created(string.Empty, SendToKafka(topic, message));
            //  }
            //  private Object SendToKafka(string topic, string message)
            //  {
            //      using (var producer =
            //           new ProducerBuilder<Null, string>(config).Build())
            //      {
            //          try
            //          {
            //              return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
            //                  .GetAwaiter()
            //                  .GetResult();
            //          }
            //          catch (Exception e)
            //          {
            //              Console.WriteLine($"Oops, something went wrong: {e}");
            //          }
            //      }
            //      return null;
            //  }



            [HttpPost("Create")]

            public async Task<IActionResult> Create(ComputerRequest request)
            {
                if (request == null)
                {
                    return BadRequest(request);
                }

                var position = _mapper.Map<Computer>(request);

                var result = await _computerService.Create(position);

                var response = _mapper.Map<ComputerResponse>(result);

                return Ok(response);
            }

            [HttpPost("Update")]
            public async Task<IActionResult> Update([FromBody] ComputerRequest request)
            {
                var result = await _computerService.Update(_mapper.Map<Computer>(request));

                if (result == null) return NotFound();

                var computer = _mapper.Map<ComputerResponse>(result);

                return Ok(computer);
            }

            [HttpDelete("Delete")]
            public async Task<IActionResult> Delete(int id)
            {
                await _computerService.Delete(id);
                return Ok();
            }

            [HttpGet("GetAll")]

            public async Task<IActionResult> GetAll()
            {
                var result = await _computerService.GetAll();

                if (result == null)
                {
                    return NotFound("Collection is empty");
                }

                var computerresult = _mapper.Map<IEnumerable<ComputerResponse>>(result);

                return Ok(computerresult);
            }
        }
}
