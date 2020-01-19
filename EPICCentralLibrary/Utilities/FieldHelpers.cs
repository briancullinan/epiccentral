using System.Web.UI;

namespace EPICCentralLibrary.Utilities
{
    public static class FieldHelpers
    {
		/// <summary> 
        /// Finds a Control recursively. Note finds the first match that exists 
        /// </summary> 
        /// <param name="ContainerCtl">Should be the lowest container in the heirarchy, for eg dont choose Master page if you can pick the specific panel</param> 
        /// <param name="IdToFind">ID of the control you are looking for</param> 
        /// <returns>the control if found else null</returns> 
        public static Control FindControlRecursive(Control ContainerCtl, string IdToFind)
        {
            if (ContainerCtl.ID == IdToFind)
                return ContainerCtl;
            foreach (Control Ctl in ContainerCtl.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, IdToFind);
                if (FoundCtl != null)
                   return FoundCtl;
            }
            return null;
        }
    }
}
