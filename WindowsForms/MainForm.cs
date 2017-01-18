using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm;

namespace WindowsFormsApplication1
{

    public partial class MainForm : Form

    {

        FormBaseSecond secondForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secondForm = new FormBaseSecond();
            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secondForm.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点击了");
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("窗口点击了");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否查看窗体！","",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Console.WriteLine("点击是");
                //MessageBox.Show("谢谢");
            }else
            {
                Console.WriteLine("点击否");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否关闭窗体！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                e.Cancel = false;
                //MessageBox.Show("谢谢");
            }
            else
            {
                e.Cancel = true;
                Console.WriteLine("点击否");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBase formBase = new FormBase();
            formBase.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MDIBaseForm mdiBaseForm = new MDIBaseForm();
            mdiBaseForm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExtendsForm extendsForm = new ExtendsForm();
            extendsForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpacityForm opacityForm = new OpacityForm();
            opacityForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LabelForm labelForm = new LabelForm();
            labelForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonForm buttonForm = new ButtonForm();
            buttonForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextBoxForm textBoxForm = new TextBoxForm();
            textBoxForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RichTextBoxForm textBoxForm = new RichTextBoxForm();
            textBoxForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ComboBoxForm comboBoxForm = new ComboBoxForm();
            comboBoxForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CheckBoxForm checkBoxForm = new CheckBoxForm();
            checkBoxForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RadioButtonForm radioButtonForm = new RadioButtonForm();
            radioButtonForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NumericUpDownForm nuf = new NumericUpDownForm();
            nuf.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ListBoxForm lbf = new ListBoxForm();
            lbf.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PanelForm pf = new PanelForm();
            pf.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            TabControlForm tcf = new TabControlForm();
            tcf.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MenuStripForm msf = new MenuStripForm();
            msf.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ToolSTripForm ttf = new ToolSTripForm();
            ttf.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            StatusStripForm ssf = new StatusStripForm();
            ssf.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ImageListForm ilf = new ImageListForm();
            ilf.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ListViewForm lf = new ListViewForm();
            lf.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            TreeViewForm tvf = new TreeViewForm();
            tvf.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DateTimePickerForm dtp = new DateTimePickerForm();
            dtp.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MonthCalendarForm mcf = new MonthCalendarForm();
            mcf.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ErrorProviderForm epf = new ErrorProviderForm();
            epf.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            TimerForm tf = new TimerForm();
            tf.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ProgressBarForm pbf = new ProgressBarForm();
            pbf.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            TrackBarForm tbf = new TrackBarForm();
            tbf.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            TreeViewListViewForm tvlvf = new TreeViewListViewForm();
            tvlvf.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ConnectionDatabaseForm cdf = new ConnectionDatabaseForm();
            cdf.Show();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            IEnumeratorForm ief = new IEnumeratorForm();
            ief.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            PartialForm pf = new PartialForm();
            pf.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            FanXingForm fxf = new FanXingForm();
            fxf.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            FileForm ff = new FileForm();
            ff.Show();
        }
    }
}
