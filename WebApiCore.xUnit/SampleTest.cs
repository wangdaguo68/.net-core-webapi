using Microsoft.AspNetCore.Mvc;
using WebApiCore.Controllers;
using Xunit;

namespace WebApiCore.xUnit
{
    public class SampleTest
    {
        [Fact]
        public void Test()
        {
            var controller = new TestController();
            var result = controller.Index() as ContentResult;
            Assert.NotNull(result);
            Assert.Equal("Test", result.Content);
        }
    }
}
