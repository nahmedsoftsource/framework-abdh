using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
	public interface ISoftDeletable
	{
		DateTime CreatedDate { get; set; }
		DateTime ModifiedDate { get; set; }
		DateTime? DeletedDate { get; set; }
	}
}
