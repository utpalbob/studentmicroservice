using System;
using System.Collections.Generic;

namespace studentms {

	public interface IStudentmsRepository{

		Studentms Update(Studentms studentms);
		Studentms Add(Studentms studentms);
		Studentms Get(int id);
		ICollection<Studentms> All();

	}
}
