using LingoPartnerDomain;
using LingoPartnerDomain.classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LingoPartnerConsole.Views
{
  internal class TeacherAdd
  {
    private Administration SchoolAdministration;
    public TeacherAdd(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      Console.WriteLine("Add a teacher");
    }
  }
}