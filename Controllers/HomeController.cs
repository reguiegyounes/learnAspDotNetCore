using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Controllers
{
    public class HomeController
    {
        public string hello()
        {
            return "Home controller , Hello action";
        }

        public string index()
        {
            return "Home controller , index action";
        }
    }
}

