using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Alex Mitchelmore
// Date: 2019-04-30
// Exercise: Task Manager

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SortedList<DateTime, String> TaskList = new SortedList<DateTime, string>();

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTasks.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a task to remove.");
                }
                else
                {

                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTask.Text == String.Empty)
                {
                    MessageBox.Show("You must enter a task.");
                }
                else if (TaskList.Keys.Contains(dtpTaskDate.Value))
                {
                    MessageBox.Show("Only one task per day allowed.");
                }
                else
                {
                    TaskList.Add(dtpTaskDate.Value, txtTask.Text.Trim());
                    MessageBox.Show(dtpTaskDate.Value.ToString());

                    

                    dtpTaskDate.ResetText();
                    txtTask.ResetText();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;

                if (TaskList.Count == 0)
                {
                    message += "You currently have no tasks saved";
                }
                else
                {
                    foreach (var task in TaskList)
                    {
                        message += $"{task.Key} {task.Value} \n";
                    }
                }

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
  
        }
    }
}
