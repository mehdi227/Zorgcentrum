using System;
using System.Collections.Generic;
using System.Text;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces
{
    public interface IPersoonRepositoryReader
    {

        public void Insert();
        public void Update();
        public void Delete();
    }
}
