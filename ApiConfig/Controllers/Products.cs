using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConfig.Controllers
{
    [Route("Products")] // /Products ile bu controller'a gel dedik
    public class Products: ControllerBase //class oluşturduk ama controller olması için ControllerBase inherit ettik
    {
        [Route("Merhaba")] // /products/merhaba
        public string Merhaba() //buraya gelmesi için addcontrollers eklenmeli
        {
            return "Merhaba";
        }

        [Route("Hello")] // /products/Hello
        public string Hello()
        {
            return "Hello";
        }
    }
}
