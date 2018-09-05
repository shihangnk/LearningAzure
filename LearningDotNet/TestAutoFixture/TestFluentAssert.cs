using FluentAssertions;
using FluentAssertions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutoFixture
{
    [TestClass]
    public class TestFluentAssert
    {
        [TestMethod]
        public void test()
        {
            string a = "aaa";
            a.Should().Be("aaa");   // Should() is available on the "a" even it is not a test method.

            var theDateTime = 1.March(2018).At(22, 13).AsLocal();

            var h1 = new HasNoAttribute();
            var h2 = new HasNoAttribute();

            h1.Should().BeOfType<HasNoAttribute>();
            // still failed, it looks like that we can't use BeEquivalentTo() to compare objects without member variable.
            h1.Should().BeEquivalentTo(h2, options => options.ExcludingProperties());
            h1.Should().BeEquivalentTo(h2, options=>options.ExcludingFields());

        }
    }

    class HasNoAttribute
    {

    }


}