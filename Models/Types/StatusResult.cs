using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Models.Types
{
    public class StatusResult
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public string QueryStrings { get; set; }
    }
}
