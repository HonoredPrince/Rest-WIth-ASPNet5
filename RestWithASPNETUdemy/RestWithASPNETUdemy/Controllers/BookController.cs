﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Service;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookBusiness)
        {
            _logger = logger;
            _bookService = bookBusiness;
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(_bookService.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookService.GetBook(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book); 
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookService.Create(book));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
