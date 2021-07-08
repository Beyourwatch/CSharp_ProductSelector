using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BalluffVisionConfigurator
{
    public partial class FormSettingWindow : Form
    {
        public event EventHandler SettingApllied;

        public SettingProperty SP_ = new SettingProperty();
        public FormSettingWindow( SettingProperty oldsetting )
        {
            InitializeComponent();

            SetPropertyfromMainWindow(oldsetting);


        }
               

        private void FormSettingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            SettingApllied(SP_, EventArgs.Empty);

        }


        private void SetPropertyfromMainWindow(SettingProperty settingtoset )
        {
            this.cBSystemLanguage.Text = settingtoset.Systemlanguage;
        }

        private void cBSystemLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            SP_.Systemlanguage = this.cBSystemLanguage.Text;

            if (cBSystemLanguage.Text == "English")
            {
                labelLanguage.Text = "Language:";
                // 声明
                labelStatement.Text = "@Statement \n";
                labelStatement.Text = labelStatement.Text + " \n";

                labelStatement.Text = labelStatement.Text + "Balluff Vision Configurator is offline tool used for helping select of the Balluff vision products,";
                labelStatement.Text = labelStatement.Text + "it does not garant the right! For certain please refer to the Balluff homepage: \n";
                labelStatement.Text = labelStatement.Text + "www.balluff.com.cn \n";

                labelStatement.Text = labelStatement.Text + " \n";

                labelStatement.Text = labelStatement.Text + "If you have question or idea, please contact: \n";
                labelStatement.Text = labelStatement.Text + "Boqie.zhang@balluff.com.cn \n";

                labelStatement.Text = labelStatement.Text + " \n";
                labelStatement.Text = labelStatement.Text + "Release Date: 2021.02.25";
            }
            else if (cBSystemLanguage.Text == "中文")
            {
                //语言
                labelLanguage.Text = "语言:";

                //声明
                labelStatement.Text = "@声明 \n";
                labelStatement.Text = labelStatement.Text + " \n";

                labelStatement.Text = labelStatement.Text + "Balluff Vision Configurator 是用来帮助巴鲁夫视觉产品选型的离线工具，不完全确保产品的实时性和结果的准备性，还请参考巴鲁夫官网:\n ";
                labelStatement.Text = labelStatement.Text + "www.balluff.com.cn \n";

                labelStatement.Text = labelStatement.Text + " \n";

                labelStatement.Text = labelStatement.Text + "如果对该工具有问题或建议请联系: \n";
                labelStatement.Text = labelStatement.Text + "Boqie.zhang@balluff.com.cn \n";

                labelStatement.Text = labelStatement.Text + " \n";
                labelStatement.Text = labelStatement.Text + "发布日期: 2021.02.25";
            }

        }
    }
}
