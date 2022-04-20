using BLL;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ProductController : ControllerBase
    {
        private IProductLogic _logic;
        public ProductController(IProductLogic logic)
        {
            _logic = logic;
        }


        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct()
        {

            return Ok(_logic.GetAllProduct());


        }

        [HttpGet("SearchProduct/{name}/{category}/{priceId}")]
        public IActionResult SearchProduct(string name, string category, int priceId)
        {

            return Ok(_logic.SearchProduct(name, category, priceId));


        }


        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductDto z)
        {

            if (_logic.isEexsist(z))
            {
                return StatusCode(409, "קיים כבר מוצר עם קוד זה");
            }
            return Ok(_logic.AddProduct(z));

        }

        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] ProductDto u)
        {


            return Ok(_logic.Edit(u));

        }



        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(_logic.GetProductById(id));
            }
            catch (Exception e)
            {

                return NotFound();
            }
        }


        [HttpGet("Views/{num}")]
        public IActionResult GetProductByUnitsInStock(int num)
        {
            return Ok(_logic.GetProductByUnitsInStock(num));
        }

       




    }
}
