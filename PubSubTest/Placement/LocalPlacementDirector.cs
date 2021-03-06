﻿using Orleans.Runtime;
using Orleans.Runtime.Placement;
using System.Threading.Tasks;

namespace PubSubTest.Placement
{
    public sealed class LocalPlacementDirector : IPlacementDirector
    {
        private Task<SiloAddress> cachedLocalSilo;

        public Task<SiloAddress> OnAddActivation(PlacementStrategy strategy, PlacementTarget target, IPlacementContext context)
        {
            cachedLocalSilo ??= Task.FromResult(context.LocalSilo);

            return cachedLocalSilo;
        }
    }
}
