using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MobilityFriends.Functional.Test
{
    public class xUnitTest
    {
        [Fact]
        public void testaEssaBagaca()
        {
            var x = 10;
            var y = 20;
            Assert.True( x + y==30);
        }
    }
}
