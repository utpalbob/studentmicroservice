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

		[HttpGet("{id}/fee")]
		public async Task<IActionResult> RetriveFee(int id)
		{
			Studentms studentms = studentmsRepository.Get(id);
			return this.Ok(new
			{
				id = studentms.id,
				name = studentms.Name,
				address = studentms.Address,
				Fee = new
				{
					fee = await studentmsClient.GetFee(studentms.id)
				}
			});
		}

		[HttpPost("{id}/fee")]
		public IActionResult Fee(int id)
		{

			this.studentmsClient.GetFee(id);
			return this.Ok();
		}

	}
}
