/*
Name: Nathaniel Schiraldi
Student Number: 000855552
File Created Date: November 11, 2022 
File Last Updated Date: November 11, 2022
Program Purpose: View for the HTML file (tag) checker form.
Statement of Authorship: I, Nathaniel Schiraldi, 000855552 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab4B
{

    /// <summary>
    /// The Form class used to generate the GUI.
    /// </summary
    public partial class Form1 : Form
    {

        /*The Open File Dialog Global (Class) Variable*/
        OpenFileDialog openfileDialog;

        /// <summary>
        /// The Form constructor used to generate the form.
        /// Defaults the openfileDialog filtered index to 1, restores the directory, and browses HTML files.
        /// Filters files displayed to only HTML files.
        /// </summary
        public Form1()
        {
            InitializeComponent();
            ActiveControl = fileStatusLabel;
            openfileDialog = new OpenFileDialog();
            openfileDialog.FilterIndex = 1; 
            openfileDialog.RestoreDirectory = true;
            openfileDialog.Title = "Browse HTML Files";
            openfileDialog.DefaultExt = ".html";
            openfileDialog.Filter = "html files(*.html)|*.html";
            toolStripCheckTagsMenuItem.Enabled = false;
        }

        /// <summary>
        /// The load file menu item click event handler.
        /// Clears the file content list box, sets the file status label to black.
        /// If the user selects an HTML file the file status label displays the file name.
        /// If the user does not select an HTML file the file status label displays no file is loaded.
        /// </summary>
        /// <param name="sender">The base object (object)</param>
        /// <param name="e">The event data (EventArgs)</param>
        private void toolStripLoadFileMenuItem_Click(object sender, EventArgs e)
        {
            fileContentsListBox.Items.Clear();

            fileStatusLabel.ForeColor = Color.Black;

            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripCheckTagsMenuItem.Enabled = true;
                fileStatusLabel.Text = "Loaded: " + Path.GetFileName(openfileDialog.FileName);
            }

            else
            {
                fileStatusLabel.Text = "No File Loaded";
                toolStripCheckTagsMenuItem.Enabled = false;
            }

        }

        /// <summary>
        /// The check tags menu item click event handler.
        /// Gather's the element data using the ReadFile() function.
        /// Determines the result of the file using the CheckTags() function.
        /// If the result is true a success message is displayed to the user by changing the file status label.
        /// If the result is false a failure message is displayed to the user by changing the file status label.
        /// </summary>
        /// <param name="sender">The base object (object)</param>
        /// <param name="e">The event data (EventArgs)</param>
        private void toolStripCheckTagsMenuItem_Click(object sender, EventArgs e)
        {
            string dataFile = openfileDialog.FileName;
            string elementData = ReadFile(dataFile);
            bool result = CheckTags(elementData);
            toolStripCheckTagsMenuItem.Enabled = false;

            if (result)
            {
                fileStatusLabel.ForeColor = Color.Green;
                fileStatusLabel.Text = Path.GetFileName(openfileDialog.FileName) + " has balanced tags";
            }

            else
            {
                fileStatusLabel.ForeColor = Color.Red;
                fileStatusLabel.Text = Path.GetFileName(openfileDialog.FileName) + " does not have balanced tags";
            }
        }

        /// <summary>
        /// The ReadFile function.
        /// Reads the HTML file the user selected. 
        /// </summary>
        /// <param name="dataFile">The path of the file the user selected (string)</param>
        /// <returns>The raw element data from the file (string)</returns>
        public string ReadFile(string dataFile)
        {
            FileStream file = new FileStream(dataFile, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string elementData = "";
            try
            {
                elementData = reader.ReadToEnd();
                reader.Close();
                file.Close();
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Error Out Of Memory " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error File Not Found " + ex.Message);
            }
            return elementData;
        }

        /// <summary>
        /// The CheckTags function.
        /// Creates an elementStack and a elementsStackRev (the reverse of the previous stack).
        /// Uses the Replace function from Regex passing through the raw element data, the regular expression, and a delegate match (Match object from regex).
        /// Creates a string representation of the match finds the index of the space inside the HTML element (finding the attribute).
        /// If there is an attribute the missing '>' character is inserted where the space is used for the attribute location and pushed to the stack.
        /// If there is no attribute in the HTML tag the element is pushed to the stack.
        /// Adds the elements to the listbox.
        /// Determines if the opening tags match the closing tags.
        /// </summary>
        /// <param name="elementData">The raw element data from the file (string)</param>
        /// <returns>The status condition of the tags in the HTML file (boolean)</returns>
        public bool CheckTags(string elementData)
        {
            var elementsStack = new Stack<string>();
            var elementsStackRev = new Stack<string>();
            string pattern = "<.*?>";
            int openingTagCount = 0;
            int closingTagCount = 0;
            string tagSpace = "       ";

            // Lammbda expression used with a delegate (anonymous function).
            Regex.Replace(elementData, pattern, (Match match) =>
            {
                string patternMatch = match.ToString();
                int spacePosition = patternMatch.IndexOf(" ");
                
                // Has attribute
                if (spacePosition >= 0)
                {
                    elementsStack.Push(patternMatch.Substring(0, spacePosition) + ">");
                    return patternMatch.Substring(0, spacePosition) + ">";
                }
                // Missing attribute
                else
                {
                    elementsStack.Push(patternMatch);
                    return patternMatch;
                }
            });

            // Reverses the stack.
            while (elementsStack.Count != 0)
            {
                elementsStackRev.Push(elementsStack.Pop().ToLower());
            }

            int elementSpaceCounter = 0;

            foreach (string element in elementsStackRev)
            {
                
                // Opening Tag
                if (element[1] != '/' && !element.Contains("<hr>") && !element.Contains("<br>") && !element.Contains("<img>") && !element.Contains("<meta>") && !element.Contains("<link>") && !element.Contains("<!doctype>"))
                {
                    fileContentsListBox.Items.Add($"{string.Concat(Enumerable.Repeat(tagSpace, elementSpaceCounter))}Found opening tag: {element}");
                    openingTagCount++;
                    elementSpaceCounter++;
                }

                // Closing Tag
                else if (element[1] == '/')
                {
                    elementSpaceCounter--;
                    fileContentsListBox.Items.Add($"{string.Concat(Enumerable.Repeat(tagSpace, elementSpaceCounter))}Found closing tag:  {element}");
                    closingTagCount++;
                }

                // Non-Container Tag
                else
                {
                    fileContentsListBox.Items.Add($"{string.Concat(Enumerable.Repeat(tagSpace, elementSpaceCounter))}Found non-container tag: {element}");
                }
            }

            if (openingTagCount != closingTagCount)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The exit button event handler (click event).
        /// Exits the application.
        /// </summary>
        /// <param name="sender">The base object (object)</param>
        /// <param name="e">The event data (EventArgs)</param>
        private void toolStripExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// The form closing event handler.
        /// When the form closing event is trigged the user is asked if they want to quit.
        /// If the user selects yes from the dialog the form is closed.
        /// If the user selects no from the dialog the form remains opened.
        /// </summary>
        /// <param name="sender">The base object (object)</param>
        /// <param name="e">The event data (EventArgs)</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you really want to quit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
}
