using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizePolicy.Requirment
{
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MinimumAgeRequirment requirement)
        {
            var claim = context.User.FindFirst("MinimumAge21");
            var minimumAgeClaim1 = int.Parse(claim?.Value);

            if (minimumAgeClaim1 > requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
            return null;
        }
    }
}
