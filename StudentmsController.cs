using System;
using Microsoft.AspNetCore.Mvc;

namespace studentms
{
	[Route("api/[controller]")]
	public class StudentmsController : Controller
	{

		private IStudentmsRepository studentmsRepository;


		public StudentmsController(IStudentmsRepository studentmsRepository)
		{
			this.studentmsRepository = studentmsRepository;
		}

		[HttpGet]
		public virtual IActionResult Get()
		{
			return this.Ok(studentmsRepository.All());
		}

		[HttpGet("{id}")]
		public virtual IActionResult Get(int id)
		{

			return this.Ok(studentmsRepository.Get(id));
		}

	}
}
