using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_05.WinForms
{
  public partial class ExampleForm : Form
  {
    public ExampleForm()
    {
      InitializeComponent();
    }

    private void button2_MouseEnter(object sender, EventArgs e)
    {
      button2.Top += 10;
      button2.Left += 10;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      button1.Text = "You pressed me";
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      if (!Regex.IsMatch(textBox1.Text, @"\d+"))
      {
        e.Cancel = true;        
      }
    }
  }
}
