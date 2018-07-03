﻿using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Xunit;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swashbuckle.AspNetCore.Annotations.Test
{
    public class AnnotationsParameterFilterTests
    {
        [Fact]
        public void Apply_EnrichesParameterMetadata_IfParameterDecoratedWithSwaggerParameterAttribute()
        {
            var parameter = new NonBodyParameter { };
            var filterContext = FilterContextFor(
                nameof(TestController.ActionWithSwaggerParameterAttribute), "param1");

            Subject().Apply(parameter, filterContext);

            Assert.Equal("description for param1", parameter.Description);
            Assert.True(parameter.Required);
        }

        [Fact]
        public void Apply_DoesNotModifyTheRequiredFlag_IfNotSpecifiedWithSwaggerParameterAttribute()
        {
            var parameter = new NonBodyParameter { Required = true };
            var filterContext = FilterContextFor(
                nameof(TestController.ActionWithSwaggerParameterAttributeDescriptionOnly), "param1");

            Subject().Apply(parameter, filterContext);

            Assert.True(parameter.Required);
        }

        private ParameterFilterContext FilterContextFor(string actionName, string parameterName)
        {
            var methodInfo = typeof(TestController).GetMethod(actionName);
            var parameterInfo = methodInfo.GetParameters().Single(p => p.Name == parameterName);

            return new ParameterFilterContext(
                new ApiParameterDescription(),
                null,
                parameterInfo,
                null);
        }

        private AnnotationsParameterFilter Subject()
        {
            return new AnnotationsParameterFilter();
        }
    }
}
