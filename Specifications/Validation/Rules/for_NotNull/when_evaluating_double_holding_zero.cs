﻿using System;
using Dolittle.Rules;
using Dolittle.Validation.Rules;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Specs.Validation.Rules.for_NotNull
{
    public class when_evaluating_double_holding_zero
    {
        static NotNull rule;
        static Mock<IRuleContext> rule_context_mock;

        Establish context = () =>
        {
            rule = new NotNull(null);
            rule_context_mock = new Mock<IRuleContext>();
        };

        Because of = () => rule.Evaluate(rule_context_mock.Object, 0.0);

        It should_not_fail = () => rule_context_mock.Verify(r => r.Fail(rule, Moq.It.IsAny<object>(), Moq.It.IsAny<BrokenRuleReason>()), Times.Never());
    }
}
