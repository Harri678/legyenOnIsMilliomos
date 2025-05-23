using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnIsMilliomos
{
	internal class Segitsegeek
	{
		public bool FelezoHasznalva {  get; private set; } = false;
		public bool TelefonHasznalva { get; private set; } = false;
		public bool KozonsegHasznalva { get; private set; } = false;

		public void HasznalFelezo() => FelezoHasznalva = true;
		public void HasznalTelefon() => TelefonHasznalva = true;
		public void HasznalKozonseg() => KozonsegHasznalva = true;


	}
}
