using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace studentms
{
	[Route("api/[controller]")]
	public class StudentmsController : Controller
	{

		private IStudentmsRepository studentmsRepository;
		private IClient studentmsClient;


		public StudentmsController(IStudentmsRepository studentmsRepository, IClient studentmsClient)
		{
			this.studentmsRepository = studentmsRepository;
            this.studentmsClient = studentmsClient;
		}

		[HttpGet]
		public virtual IActionResult Get()
		{
			return this.Ok(studentmsRepository.All());
		}

		[HttpGet("/fee")]
		public async Task<IActionResult> GetFee()
		{

            return this.Ok(new
            {

                Fee = new
                {
                    fee = await studentmsClient.GetFee()
				}
			});
		}

		[HttpGet("{id}")]
		public virtual IActionResult Get(int id)
		{

			return this.Ok(studentmsRepository.Get(id));
		}

	}
}
