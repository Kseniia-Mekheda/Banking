namespace Banking
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            withdrawalAmountLabel = new Label();
            withdrawalAmountCont = new TextBox();
            printReceiptWithdraw = new CheckBox();
            WithdrawNowBtn = new Button();
            warningLable = new Label();
            backBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // withdrawalAmountLabel
            // 
            resources.ApplyResources(withdrawalAmountLabel, "withdrawalAmountLabel");
            withdrawalAmountLabel.Name = "withdrawalAmountLabel";
            // 
            // withdrawalAmountCont
            // 
            resources.ApplyResources(withdrawalAmountCont, "withdrawalAmountCont");
            withdrawalAmountCont.Name = "withdrawalAmountCont";
            // 
            // printReceiptWithdraw
            // 
            resources.ApplyResources(printReceiptWithdraw, "printReceiptWithdraw");
            printReceiptWithdraw.Name = "printReceiptWithdraw";
            printReceiptWithdraw.UseVisualStyleBackColor = true;
            // 
            // WithdrawNowBtn
            // 
            resources.ApplyResources(WithdrawNowBtn, "WithdrawNowBtn");
            WithdrawNowBtn.Name = "WithdrawNowBtn";
            WithdrawNowBtn.UseVisualStyleBackColor = true;
            WithdrawNowBtn.Click += WithdrawNowBtn_Click;
            // 
            // warningLable
            // 
            resources.ApplyResources(warningLable, "warningLable");
            warningLable.Name = "warningLable";
            // 
            // backBtn
            // 
            resources.ApplyResources(backBtn, "backBtn");
            backBtn.Name = "backBtn";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backBtn);
            Controls.Add(warningLable);
            Controls.Add(WithdrawNowBtn);
            Controls.Add(printReceiptWithdraw);
            Controls.Add(withdrawalAmountCont);
            Controls.Add(withdrawalAmountLabel);
            Controls.Add(label1);
            Name = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label withdrawalAmountLabel;
        private TextBox withdrawalAmountCont;
        private CheckBox printReceiptWithdraw;
        private Button WithdrawNowBtn;
        private Label warningLable;
        private Button backBtn;
    }
}