using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class MonthCalendarForm : Form
    {
        public MonthCalendarForm()
        {
            InitializeComponent();
        }

        private void MonthCalendarForm_Load(object sender, EventArgs e)
        {
            //monthCalendar1.TitleBackColor = System.Drawing.Color.Blue;
            //monthCalendar1.TrailingForeColor = System.Drawing.Color.Red;
            //monthCalendar1.TitleForeColor = System.Drawing.Color.Yellow;
            monthCalendar1.ShowWeekNumbers = true;//显示周数
            monthCalendar1.CalendarDimensions = new Size(2,2);//设置水平和垂直都显示两个月

            //粗体显示2008.3.2
            DateTime myVacation1 = new DateTime(2008, 3, 2);
            monthCalendar1.AddBoldedDate(myVacation1);
            monthCalendar1.UpdateBoldedDates();
        }
    }
}
