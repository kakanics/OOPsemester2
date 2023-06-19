using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class comboBox
    {
        TextBox txtBox;
        ComboBox combBox;
        public List<string> dataList = new List<string>();
        public comboBox(TextBox txtBox, ComboBox combBox)
        {
            this.txtBox = txtBox;
            this.combBox = combBox;
        }
    }
}
