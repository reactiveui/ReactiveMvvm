namespace ReactiveMvvm.WinForms.Views
{
    partial class FeedbackView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.SubmitButton = new System.Windows.Forms.Button();
            this.IssueCheckBox = new System.Windows.Forms.CheckBox();
            this.IdeaCheckBox = new System.Windows.Forms.CheckBox();
            this.MessageLengthLabel = new System.Windows.Forms.Label();
            this.TitleLengthLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HasErrorsTextBox = new System.Windows.Forms.Label();
            this.TimeElapsedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(112, 227);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(169, 23);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            // 
            // IssueCheckBox
            // 
            this.IssueCheckBox.AutoSize = true;
            this.IssueCheckBox.Location = new System.Drawing.Point(112, 204);
            this.IssueCheckBox.Name = "IssueCheckBox";
            this.IssueCheckBox.Size = new System.Drawing.Size(51, 17);
            this.IssueCheckBox.TabIndex = 1;
            this.IssueCheckBox.Text = "Issue";
            this.IssueCheckBox.UseVisualStyleBackColor = true;
            // 
            // IdeaCheckBox
            // 
            this.IdeaCheckBox.AutoSize = true;
            this.IdeaCheckBox.Location = new System.Drawing.Point(201, 204);
            this.IdeaCheckBox.Name = "IdeaCheckBox";
            this.IdeaCheckBox.Size = new System.Drawing.Size(47, 17);
            this.IdeaCheckBox.TabIndex = 2;
            this.IdeaCheckBox.Text = "Idea";
            this.IdeaCheckBox.UseVisualStyleBackColor = true;
            // 
            // MessageLengthLabel
            // 
            this.MessageLengthLabel.AutoSize = true;
            this.MessageLengthLabel.Location = new System.Drawing.Point(109, 161);
            this.MessageLengthLabel.Name = "MessageLengthLabel";
            this.MessageLengthLabel.Size = new System.Drawing.Size(35, 13);
            this.MessageLengthLabel.TabIndex = 3;
            this.MessageLengthLabel.Text = "label1";
            // 
            // TitleLengthLabel
            // 
            this.TitleLengthLabel.AutoSize = true;
            this.TitleLengthLabel.Location = new System.Drawing.Point(109, 122);
            this.TitleLengthLabel.Name = "TitleLengthLabel";
            this.TitleLengthLabel.Size = new System.Drawing.Size(35, 13);
            this.TitleLengthLabel.TabIndex = 4;
            this.TitleLengthLabel.Text = "label2";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(112, 99);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(169, 20);
            this.TitleTextBox.TabIndex = 5;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(112, 138);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(169, 20);
            this.MessageTextBox.TabIndex = 6;
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Items.AddRange(new object[] {
            "User Interface",
            "Audio",
            "Video"});
            this.SectionComboBox.Location = new System.Drawing.Point(112, 177);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(169, 21);
            this.SectionComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Feedback";
            // 
            // HasErrorsTextBox
            // 
            this.HasErrorsTextBox.AutoSize = true;
            this.HasErrorsTextBox.Location = new System.Drawing.Point(109, 253);
            this.HasErrorsTextBox.Name = "HasErrorsTextBox";
            this.HasErrorsTextBox.Size = new System.Drawing.Size(149, 13);
            this.HasErrorsTextBox.TabIndex = 9;
            this.HasErrorsTextBox.Text = "Please, fill in all the form fields.";
            // 
            // TimeElapsedLabel
            // 
            this.TimeElapsedLabel.AutoSize = true;
            this.TimeElapsedLabel.Location = new System.Drawing.Point(109, 83);
            this.TimeElapsedLabel.Name = "TimeElapsedLabel";
            this.TimeElapsedLabel.Size = new System.Drawing.Size(35, 13);
            this.TimeElapsedLabel.TabIndex = 10;
            this.TimeElapsedLabel.Text = "label1";
            // 
            // FeedbackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 369);
            this.Controls.Add(this.TimeElapsedLabel);
            this.Controls.Add(this.HasErrorsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SectionComboBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.TitleLengthLabel);
            this.Controls.Add(this.MessageLengthLabel);
            this.Controls.Add(this.IdeaCheckBox);
            this.Controls.Add(this.IssueCheckBox);
            this.Controls.Add(this.SubmitButton);
            this.Name = "FeedbackView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.CheckBox IssueCheckBox;
        private System.Windows.Forms.CheckBox IdeaCheckBox;
        private System.Windows.Forms.Label MessageLengthLabel;
        private System.Windows.Forms.Label TitleLengthLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label HasErrorsTextBox;
        private System.Windows.Forms.Label TimeElapsedLabel;
    }
}

