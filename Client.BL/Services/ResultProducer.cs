using Client.BL.Interfaces;
using Client.DL.Memory;
using Client.Models.Models;
using Confluent.Kafka;
using EqClient.DataLayer.Common;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Client.BL.Services
{
    public class ResultProducer : BackgroundService
    {
        private readonly IResultProducer _resultProducer;
        private readonly IProducer<int, Computer> _producer;

        public ResultProducer(IResultProducer resultProducer)
        {
            _resultProducer = resultProducer;

        }

        protected  override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Computer comp;
                InMemoryDb.Computers.TryDequeue(out comp);

                if (comp != null)
                {
                    comp.ComputerId = 123;
                    
                    _resultProducer.ProduceResultAsync(comp);
                }
            }

            return Task.CompletedTask;
        }
    }
}
