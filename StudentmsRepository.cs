using System;
using System.Linq;
using System.Collections.Generic;


namespace studentms{

	public class StudentmsRepository : IStudentmsRepository
	{

		public static ICollection<Studentms> studentmsCol;

		public StudentmsRepository()
		{
			if(studentmsCol == null){
				studentmsCol = new List<Studentms>(){

					new Studentms(){id=1, Name="Utpal", Address="Mumbai", Course="Computer Science"},
					new Studentms(){id=2, Name="Arnab", Address="Bangalore", Course="Computer Science"},
					new Studentms(){id=3, Name="Venkat", Address="Hyderabad", Course="Bio Science"},
					new Studentms(){id=4, Name="Manoj", Address="Pune", Course="Computer Science"},
				};
			}

		}

		public Studentms Update(Studentms studentms)
		{

			Studentms oldStudentms = this.Get(studentms.id);
			oldStudentms.Name = studentms.Name;
			return oldStudentms;
		}


		public ICollection<Studentms> All()
		{
			return studentmsCol;
		}

		public Studentms Add(Studentms studentms)
		{
			studentmsCol.Add(studentms);
			return studentms;
		}

		public Studentms Get(int id)
		{

			return studentmsCol.ElementAt(id);
		}


	}
}
