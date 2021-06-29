using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Tests.Builders;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountryControllerTests
    {
        [Fact]
        public void Get_OnInvoke_ReturnsExpectedResult()
        {
            var builder = new CountryControllerBuilder();
            var controller = builder.WithGetSuccessResponseAsync().Build();
            var result = controller.GetAsync().Result; 
            
            Assert.IsType<OkObjectResult>(result);
            var response = result as OkObjectResult;

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Value.Should().NotBeNull();
            builder.CountryServiceMock.Verify(c => c.GetAsync(), Times.Once);
        }


        [Fact]
        public void Get_OnInvoke_ReturnsErrorResult()
        {
            var builder = new CountryControllerBuilder();
            var controller = builder.WithGetErrorResponseAsync().Build();
            var result = controller.GetAsync().Result;

            Assert.IsType<StatusCodeResult>(result);
            var response = result as StatusCodeResult;
            response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            builder.CountryServiceMock.Verify(c => c.GetAsync(), Times.Once);
        }
    }
}
