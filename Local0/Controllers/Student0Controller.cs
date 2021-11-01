using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Local0.Models;
using Local0.DTOs;

namespace Local0
{
    public class SelfClass
    {
        public decimal? Id { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class Student0Controller : ControllerBase
    {
        private readonly ModelContext _context;

        public Student0Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Student1
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetStudent0s()
        {
            List<Student0> student0s = await _context.Student0s
                                                     .OrderBy(i => i.Id)
                                                     .ToListAsync();

            if (student0s.Count <= 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "Data pacche nah",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "Data pacche ",
                Success = true,
                Payload = student0s
            });
        }


        // GET: api/Student1/5
        [HttpPost("GetByID")]
        public async Task<ActionResult<ResponseDto>> GetStudent0([FromBody] SelfClass input)
        {
            if (input.Id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Fill up the ID field",
                    Success = false,
                    Payload = null
                });
            }

            var student0 = await _context.Student0s.Where(i => i.Id == input.Id).FirstOrDefaultAsync();

            if (student0 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "ID not found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "ID found",
                Success = true,
                Payload = student0
            });
        }

        [HttpGet("GetCustom")]
        public async Task<ActionResult<ResponseDto>> GetStudent0c()
        {
            List<Student0> student0s = await _context.Student0s
                                                     .Where(i => i.Age > (decimal)9.5)
                                                     .OrderBy(i => i.Name)
                                                     .ToListAsync();

            if (student0s.Count <= 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "Data pacche nah",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "Data pacche ",
                Success = true,
                Payload = student0s
            });
        }

        // POST: api/Student1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertNewData")]
        public async Task<ActionResult<ResponseDto>> PostStudent00([FromBody] Student0 input)
        {

            if (input.Id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Fill up the ID field",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Name == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Fill up the Name field",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Age == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "AGE is null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Age == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "AGE cant be Zero",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Age < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "AGE cant be negative",
                    Success = false,
                    Payload = null
                });
            }
            var student0s = await _context.Student0s.Where(i => i.Id == input.Id).FirstOrDefaultAsync();

            _context.Student0s.Add(input);

            if (student0s != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto
                {
                    Message = "Already same ID in the dataBase",
                    Success = false,
                    Payload = null
                });
            }
            bool isSaved = await _context.SaveChangesAsync() > 0;
            if (isSaved == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "Data cant inserted for the Internal Server Error",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "Data Inserted",
                Success = true,
                Payload = null
            });

        }


        [HttpPost("UpdateData")]
        public async Task<ActionResult<ResponseDto>> PutStudent0([FromBody] Student0 input)
        {
            if (input.Id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Fill UP ID field",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Name == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Fill up the Name field",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Age == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "AGE is null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Age == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "AGE cant be Zero",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Age < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "AGE cant be negative",
                    Success = false,
                    Payload = null
                });
            }

            var students0 = await _context.Student0s.Where(i => i.Id == input.Id).FirstOrDefaultAsync();
            if (students0 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "This ID is not found in the database",
                    Success = false,
                    Payload = null
                });
            }
            students0.Name = input.Name;
            students0.Age = input.Age;


            _context.Student0s.Update(students0);
            bool isSaved = await _context.SaveChangesAsync() > 0;

            if (isSaved == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "Server error so cant Update data",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "DataUpdated",
                Success = true,
                Payload = null
            });
        }

        // DELETE: api/Student1/5
        [HttpPost("DeleteData")]
        public async Task<ActionResult<ResponseDto>> DeleteStudent0([FromBody] SelfClass input)
        {
            if (input.Id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Fill up the ID field",
                    Success = false,
                    Payload = null
                });
            }

            var student0s = await _context.Student0s.Where(i => i.Id == input.Id).FirstOrDefaultAsync();
            if (student0s == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "ID dont match with the database",
                    Success = false,
                    Payload = null
                });
            }

            _context.Student0s.Remove(student0s);
            bool isSaved = await _context.SaveChangesAsync() > 0;
            if (isSaved == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "Data Cant delete for the internal server error",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "Delete Done",
                Success = true,
                Payload = null
            });
        }

        
        private bool Student0Exists(decimal? id)
        {
            return _context.Student0s.Any(e => e.Id == id);
        }
    }
}
