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

        //List to hold the date and task
        private SortedList<DateTime, String> TaskList = new SortedList<DateTime, string>();

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTasks.SelectedIndex == -1)//checks if nothing is selected
                {
                    MessageBox.Show("You must select a task to remove.");
                }
                else
                {
                    int index = Convert.ToInt32(lstTasks.SelectedIndex);
                    TaskList.RemoveAt(index);//removes from tasklist
                    lstTasks.Items.Remove(lstTasks.SelectedItem);//removes from list
                    lstTasks.SelectedIndex = -1;
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
                DateTime taskDate = dtpTaskDate.Value.Date;//gives short value

                if (txtTask.Text == String.Empty)//checks if empty
                {
                    MessageBox.Show("You must enter a task.");
                }
                else if (TaskList.Keys.Contains(taskDate))//checks ifteh date excists in the task list
                {
                    MessageBox.Show("Only one task per day allowed.");
                }
                else
                {
                    TaskList.Add(taskDate, txtTask.Text.Trim());//adds date and task to tasklist
                    lstTasks.Items.Add(taskDate);//adds date to list

                    dtpTaskDate.ResetText();//resets datetimepicker
                    txtTask.ResetText();//resets textbox
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

                if (TaskList.Count == 0)//checks if there are no tasks
                {
                    message += "You currently have no tasks saved";
                }
                else
                {
                    foreach (var task in TaskList)//loops through tasklist and gives all keys and values
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

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblTaskDetails.Text = TaskList[Convert.ToDateTime(lstTasks.SelectedItem)];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            
        }
    }
}
