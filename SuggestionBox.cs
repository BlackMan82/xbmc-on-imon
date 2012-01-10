using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace iMon.XBMC
{
    public class SuggestionBox : TextBox
    {
        #region Private variables

        private const int InitialHeight = 17;
        private const int HeightIncrement = 13;

        private ListBox list;
        private List<string> suggestions;
        private int maximumRows;

        private string delimiter;
        private bool startAndEnd;

        private bool focused;

        #endregion

        #region Public variables

        [Browsable(true)]
        public ICollection<string> Suggestions
        {
            get { return this.suggestions; }
        }

        [Browsable(true)]
        public int MaximumRows
        {
            get { return this.maximumRows; }
            set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException();
                }

                this.maximumRows = value;
            }
        }

        [Browsable(true)]
        public string Delimiter
        {
            get { return this.delimiter; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.delimiter = value;
            }
        }

        [Browsable(true)]
        public bool StartAndEnd
        {
            get { return this.startAndEnd; }
            set { this.startAndEnd = value; }
        }

        #endregion

        #region Constructor

        public SuggestionBox()
        {
            this.suggestions = new List<string>();

            this.delimiter = " ";
            this.startAndEnd = false;
        }

        #endregion

        #region Overrides of ComboBox

        protected override void OnGotFocus(EventArgs e)
        {
            this.checkList();

            if (this.focused || this.Text.Length == 0)
            {
                this.suggest();
            }

            this.focused = true;

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.checkList();
            if (!this.list.Focused)
            {
                this.list.Visible = false;
            } 

            base.OnLostFocus(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.checkList();

            if (this.list.Visible &&
                (keyData == Keys.Up || keyData == Keys.Down))
            {
                switch (keyData)
                {
                    case Keys.Up:
                        if (this.list.SelectedIndex > 0)
                        {
                            this.list.SelectedIndex -= 1;
                        }
                        break;

                    case Keys.Down:
                        if (this.list.SelectedIndex + 1 < this.list.Items.Count)
                        {
                            this.list.SelectedIndex += 1;
                        }
                        break;
                }

                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            this.checkList();
            
            if (this.list.Visible &&
                (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter))
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (this.list.SelectedIndex >= 0)
                        {
                            this.insert(this.list.SelectedItem.ToString());
                            this.list.Visible = false;
                        }
                        break;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (!e.SuppressKeyPress)
            {
                this.suggest();
            }
            
            base.OnKeyDown(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.checkList();
                this.suggest();
            }

            base.OnMouseClick(e);
        }

        #endregion

        #region Private functions

        private void checkList()
        {
            if (this.list == null)
            {
                this.list = new ListBox();
                this.list.Visible = false;
                this.Parent.Controls.Add(this.list);

                this.list.SelectionMode = SelectionMode.One;

                this.list.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + this.Size.Height);
                this.list.Size = new System.Drawing.Size(this.Size.Width, InitialHeight);

                this.list.DoubleClick += suggestionDoubleClick;
                this.list.LostFocus += listLostFocus;
            }
        }

        private void insert(string value)
        {
            int currentPosition = this.SelectionStart;
            
            if (currentPosition <= 0)
            {
                this.Text = this.Text.Insert(0, value);
                this.SelectionStart = value.Length;
            }
            else
            {
                int delimiterPosition = this.getDelimiterPosition();
                this.Text = this.Text.Remove(delimiterPosition, currentPosition - delimiterPosition).Insert(delimiterPosition, value);
                this.SelectionStart = delimiterPosition + value.Length;
            }
        }

        private void suggest()
        {
            int currentPosition = this.SelectionStart;
            string text = this.Text;

            if (currentPosition <= 0)
            {
                this.list.Items.Clear();
                foreach (string suggestion in this.suggestions)
                {
                    this.list.Items.Add(suggestion);
                }
            }
            else
            {
                int delimiterPosition = this.getDelimiterPosition();

                this.list.Items.Clear();
                if (delimiterPosition >= 0)
                {
                    string pattern = text.Substring(delimiterPosition, currentPosition - delimiterPosition).ToLowerInvariant();

                    foreach (string suggestion in this.suggestions)
                    {
                        if (string.IsNullOrEmpty(pattern) || suggestion.ToLowerInvariant().StartsWith(pattern))
                        {
                            this.list.Items.Add(suggestion);
                        }
                    }
                }
            }

            if (this.list.Items.Count > 0)
            {
                this.list.Height = InitialHeight + (Math.Min(this.list.Items.Count, this.maximumRows) - 1) * HeightIncrement;
                this.list.Visible = true;
                this.list.BringToFront();
            }
            else
            {
                this.list.Visible = false;
            }

            this.SelectionStart = currentPosition;
        }

        private int getDelimiterPosition()
        {
            int currentPosition = this.SelectionStart;
            string text = this.Text;
            
            int delimiterPosition = text.LastIndexOf(this.delimiter, currentPosition, currentPosition + 1);
            if (delimiterPosition < 0)
            {
                // The delimiter was not found
                return -1;
            }
            if (this.startAndEnd)
            {
                int count = 0;
                int lastPosition = 0;

                // Let's loop through all occurances of the delimiter
                while (lastPosition >= 0 && lastPosition < currentPosition)
                {
                    int newPosition = text.IndexOf(this.delimiter, lastPosition, currentPosition - lastPosition);
                    // If the new position is smaller than the last one we reached the last delimiter
                    if (newPosition < lastPosition)
                    {
                        break;
                    }

                    // Delimiter found
                    count += 1;

                    // We have to check what's between the last two delimiters
                    if (count > 1)
                    {
                        // Last delimiter is used up
                        count -= 1;
                        // If there is no space between the last two delimiters it's a suggestion match
                        if (!text.Substring(lastPosition, newPosition - lastPosition).Contains(" "))
                        {
                            // Both delimiters are used up
                            count -= 1;
                        }
                    }

                    lastPosition = newPosition + 1;
                }                

                if (count == 0)
                {
                    // All delimiters are already in use
                    return -1;
                }
            }

            return delimiterPosition;
        }

        private void suggestionDoubleClick(object sender, EventArgs e)
        {
            if (this.list.SelectedIndex >= 0)
            {
                this.insert(this.list.SelectedItem.ToString());
                this.list.Visible = false;
                this.Focus();
            }
        }

        private void listLostFocus(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                this.list.Visible = false;
            }
        }

        #endregion
    }
}
