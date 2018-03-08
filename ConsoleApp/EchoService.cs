using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class EchoService : IEchoService
    {
        private readonly MyConfiguration _config;

        public EchoService(IOptions<MyConfiguration> options)
        {
            _config = options.Value;
        }

        void IEchoService.Echo()
        {
            Console.WriteLine(_config.Title);
        }
    }
}
