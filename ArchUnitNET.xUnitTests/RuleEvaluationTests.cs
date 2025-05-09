using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Extensions;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchUnitNET.xUnitTests
{
    public class RuleEvaluationTests
    {
        private readonly Architecture _architecture;
        private readonly string _expectedErrorMessage;
        private readonly IArchRule _falseRule;
        private readonly IArchRule _trueRule;

        public RuleEvaluationTests()
        {
            _architecture = new ArchLoader()
                .LoadAssemblies(System.Reflection.Assembly.Load("ArchUnitNET.xUnitTests"))
                .Build();
            _trueRule = Classes().That().Are(typeof(RuleEvaluationTests)).Should().Exist();
            _falseRule = Classes().That().Are(typeof(RuleEvaluationTests)).Should().NotExist();
            _expectedErrorMessage = _falseRule.Evaluate(_architecture).ToErrorMessage();
        }

        [Fact]
        public void ArchRuleAssertTest()
        {
            ArchRuleAssert.CheckRule(_architecture, _trueRule);
            Assert.Throws<FailedArchRuleException>(() =>
                ArchRuleAssert.CheckRule(_architecture, _falseRule)
            );
            Assert.Equal(
                _expectedErrorMessage,
                Assert
                    .Throws<FailedArchRuleException>(() =>
                        ArchRuleAssert.CheckRule(_architecture, _falseRule)
                    )
                    .Message
            );
        }

        [Fact]
        public void ArchRuleExtensionsTest()
        {
            _architecture.CheckRule(_trueRule);
            _trueRule.Check(_architecture);
            Assert.Throws<FailedArchRuleException>(() => _architecture.CheckRule(_falseRule));
            Assert.Throws<FailedArchRuleException>(() => _falseRule.Check(_architecture));
            Assert.Equal(
                _expectedErrorMessage,
                Assert
                    .Throws<FailedArchRuleException>(() => _architecture.CheckRule(_falseRule))
                    .Message
            );
            Assert.Equal(
                _expectedErrorMessage,
                Assert
                    .Throws<FailedArchRuleException>(() => _falseRule.Check(_architecture))
                    .Message
            );
        }
    }
}
