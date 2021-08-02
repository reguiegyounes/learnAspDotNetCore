using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Controllers
{
    public class PageController
    {
        public string hello()
        {
            return "Page controller ,Hello action";
        }

        public string index()
        {
            return "Page controller ,index action";
        }
    }
}
