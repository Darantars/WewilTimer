using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WewilTimer_Core.Models  //TODO:Выпилить и перенести в Core
{
    public class ToDoItem
    {
        public bool IsChecked { get; set; }

        public string Content { get; set; }
    }
}
