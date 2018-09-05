using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace TestAutoFixture
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        public void test()
        {
            string username = "dennis";
            username.Should().StartWith("d").And.EndWith("s");

            string username2 = "dennis";
            username2.Should().BeSameAs(username);

            string part1 = "denn";
            string part2 = "is";
            string username3 = part1+part2;
            username3.Should().BeEquivalentTo(username);
            username3.Should().NotBeSameAs(username);
            username3.Should().Be(username);
        }

    }
}