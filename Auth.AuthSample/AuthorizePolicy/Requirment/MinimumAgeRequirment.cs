using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizePolicy.Requirment
{
    public class MinimumAgeRequirment : IAuthorizationRequirement
    {
        public MinimumAgeRequirment(int minimumAge)
        {
            MinimumAge = minimumAge;
        }

        public int MinimumAge { get; }
    }
}
