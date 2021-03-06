﻿using System;
using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Queries.Coordination.Specs.for_QueryCoordinator
{
    public class when_executing_an_async_query_with_a_known_provider_for_its_result_type : given.a_query_coordinator_with_known_provider
    {
        static AsyncQueryForKnownProvider query;
        static PagingInfo paging;
        static QueryType actual_query;
        static QueryProviderResult result;
        static ReadModelWithString[] items = new[] {
            new ReadModelWithString { Content = "Hello" },
            new ReadModelWithString { Content = "World" },
        };

        Establish context = () =>
        {
            query = new AsyncQueryForKnownProvider();
            paging = new PagingInfo();

            actual_query = new QueryType();
            query.QueryToReturn = actual_query;

            result = new QueryProviderResult {
                Items = items
            };

            query_provider_mock.Setup(c => c.Execute(actual_query, paging)).Returns(result);
        };

        Because of = () => coordinator.Execute(query, paging).Wait();

        It should_forward_query_with_clause_to_provider = () => query_provider_mock.Verify(q => q.Execute(actual_query, paging), Moq.Times.Once());
        It should_filter_result = () => read_model_filters.Verify(r => r.Filter(items),Times.Once());
    }
}
