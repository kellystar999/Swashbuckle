﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MultipleVersions.V1;

namespace MultipleVersions.V2
{
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/products")]
    [Produces("application/json")]
    public class ProductsController
    {
        [HttpPost]
        public int CreateProduct([FromBody, Required]Product product)
        {
            return 1;
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody, Required]Product product)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
        }
    }
}