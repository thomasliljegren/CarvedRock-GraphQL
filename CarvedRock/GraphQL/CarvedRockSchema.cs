﻿using CarvedRock.Api.GraphQL;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.GraphQL
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CarvedRockQuery>();
            Mutation = resolver.Resolve<CarvedRockMutation>();
            Subscription = resolver.Resolve<CarvedRockSubscription>();
        }
    }
}
