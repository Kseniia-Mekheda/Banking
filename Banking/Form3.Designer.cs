namespace Banking
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            putMoneyLabel = new Label();
            sumEntryLabel = new Label();
            MoneyToPutCont = new TextBox();
            printReceiptPutting = new CheckBox();
            PutNowBtn = new Button();
            backBtn = new Button();
            SuspendLayout();
            // 
            // putMoneyLabel
            // 
            resources.ApplyResources(putMoneyLabel, "putMoneyLabel");
            putMoneyLabel.Name = "putMoneyLabel";
            // 
            // sumEntryLabel
            // 
            resources.ApplyResources(sumEntryLabel, "sumEntryLabel");
            sumEntryLabel.Name = "sumEntryLabel";
            // 
            // MoneyToPutCont
            // 
            resources.ApplyResources(MoneyToPutCont, "MoneyToPutCont");
            MoneyToPutCont.Name = "MoneyToPutCont";
            // 
            // printReceiptPutting
            // 
            resources.ApplyResources(printReceiptPutting, "printReceiptPutting");
            printReceiptPutting.Name = "printReceiptPutting";
            printReceiptPutting.UseVisualStyleBackColor = true;
            // 
            // PutNowBtn
            // 
            resources.ApplyResources(PutNowBtn, "PutNowBtn");
            PutNowBtn.Name = "PutNowBtn";
            PutNowBtn.UseVisualStyleBackColor = true;
            PutNowBtn.Click += PutNowBtn_Click;
            // 
            // backBtn
            // 
            resources.ApplyResources(backBtn, "backBtn");
            backBtn.Name = "backBtn";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backBtn);
            Controls.Add(PutNowBtn);
            Controls.Add(printReceiptPutting);
            Controls.Add(MoneyToPutCont);
            Controls.Add(sumEntryLabel);
            Controls.Add(putMoneyLabel);
            Name = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label putMoneyLabel;
        private Label sumEntryLabel;
        private TextBox MoneyToPutCont;
        private CheckBox printReceiptPutting;
        private Button PutNowBtn;
        private Button backBtn;
    }
}