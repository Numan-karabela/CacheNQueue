using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Abstractions.RabitMQ
{
    public interface IRabitMQService
    {
        void Message(string Message,string QueueKey);
    }
}
