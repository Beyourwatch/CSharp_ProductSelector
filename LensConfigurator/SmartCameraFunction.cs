﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalluffVisionConfigurator
{
    public partial class SmartCameraFunction : Form
    {
        public SmartCameraFunction()
        {
            InitializeComponent();
        }

        private void SmartCameraFunction_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}