

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
 
namespace JsonSerializeDemo
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }
 
    private void button1_Click(object sender, EventArgs e)
    {
      DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(InfoClass));
 
      InfoClass infoc = new InfoClass();
      infoc.ID = Convert.ToInt32(textBox_ID.Text);
      infoc.Name = textBox_Name.Text;
 
      MemoryStream ms = new MemoryStream();
      serializer.WriteObject(ms, infoc);
      string JsonString = Encoding.UTF8.GetString(ms.ToArray());
 
      textBox_Output.Text = JsonString;
 
    }
 
    private void button2_Click(object sender, EventArgs e)
    {
      DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(InfoClass));
       
      byte[] bytes = Encoding.UTF8.GetBytes(textBox_Output.Text);
      MemoryStream ms = new MemoryStream(bytes);
      InfoClass infoc = (InfoClass)serializer.ReadObject(ms);
 
      textBox_ID.Text = Convert.ToString(infoc.ID);
      textBox_Name.Text = infoc.Name;
    }
 
    private void button3_Click(object sender, EventArgs e)
    {
      textBox_ID.Text = "";
      textBox_Name.Text = "";
    }
  }
}
 

