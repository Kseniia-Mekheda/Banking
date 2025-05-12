namespace Banking
{
    partial class SystemEntrance
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemEntrance));
            btnUkr = new Button();
            btnEng = new Button();
            rulesLabel = new Label();
            cardNumLabel = new Label();
            cardNumCont = new TextBox();
            ExpirationLabel = new Label();
            ExpirationMonthCont = new TextBox();
            slash = new Label();
            ExpirationYearCont = new TextBox();
            CvvLabel = new Label();
            CvvContainer = new TextBox();
            cardPasswordLabel = new Label();
            cardPasswordCont = new TextBox();
            checkBalanceBtn = new Button();
            withdrawBtn = new Button();
            PutMoneyOnBtn = new Button();
            exitBtn = new Button();
            SuspendLayout();
            // 
            // btnUkr
            // 
            resources.ApplyResources(btnUkr, "btnUkr");
            btnUkr.Name = "btnUkr";
            btnUkr.UseVisualStyleBackColor = true;
            btnUkr.Click += btnUkr_Click;
            // 
            // btnEng
            // 
            resources.ApplyResources(btnEng, "btnEng");
            btnEng.Name = "btnEng";
            btnEng.UseVisualStyleBackColor = true;
            btnEng.Click += btnEng_Click;
            // 
            // rulesLabel
            // 
            resources.ApplyResources(rulesLabel, "rulesLabel");
            rulesLabel.Name = "rulesLabel";
            // 
            // cardNumLabel
            // 
            resources.ApplyResources(cardNumLabel, "cardNumLabel");
            cardNumLabel.Name = "cardNumLabel";
            // 
            // cardNumCont
            // 
            resources.ApplyResources(cardNumCont, "cardNumCont");
            cardNumCont.Name = "cardNumCont";
            // 
            // ExpirationLabel
            // 
            resources.ApplyResources(ExpirationLabel, "ExpirationLabel");
            ExpirationLabel.Name = "ExpirationLabel";
            // 
            // ExpirationMonthCont
            // 
            resources.ApplyResources(ExpirationMonthCont, "ExpirationMonthCont");
            ExpirationMonthCont.Name = "ExpirationMonthCont";
            // 
            // slash
            // 
            resources.ApplyResources(slash, "slash");
            slash.Name = "slash";
            // 
            // ExpirationYearCont
            // 
            resources.ApplyResources(ExpirationYearCont, "ExpirationYearCont");
            ExpirationYearCont.Name = "ExpirationYearCont";
            // 
            // CvvLabel
            // 
            resources.ApplyResources(CvvLabel, "CvvLabel");
            CvvLabel.Name = "CvvLabel";
            // 
            // CvvContainer
            // 
            resources.ApplyResources(CvvContainer, "CvvContainer");
            CvvContainer.Name = "CvvContainer";
            CvvContainer.UseSystemPasswordChar = true;
            // 
            // cardPasswordLabel
            // 
            resources.ApplyResources(cardPasswordLabel, "cardPasswordLabel");
            cardPasswordLabel.Name = "cardPasswordLabel";
            // 
            // cardPasswordCont
            // 
            resources.ApplyResources(cardPasswordCont, "cardPasswordCont");
            cardPasswordCont.Name = "cardPasswordCont";
            cardPasswordCont.UseSystemPasswordChar = true;
            // 
            // checkBalanceBtn
            // 
            resources.ApplyResources(checkBalanceBtn, "checkBalanceBtn");
            checkBalanceBtn.Name = "checkBalanceBtn";
            checkBalanceBtn.UseVisualStyleBackColor = true;
            checkBalanceBtn.Click += checkBalanceBtn_Click;
            // 
            // withdrawBtn
            // 
            resources.ApplyResources(withdrawBtn, "withdrawBtn");
            withdrawBtn.Name = "withdrawBtn";
            withdrawBtn.UseVisualStyleBackColor = true;
            withdrawBtn.Click += withdrawBtn_Click;
            // 
            // PutMoneyOnBtn
            // 
            resources.ApplyResources(PutMoneyOnBtn, "PutMoneyOnBtn");
            PutMoneyOnBtn.Name = "PutMoneyOnBtn";
            PutMoneyOnBtn.UseVisualStyleBackColor = true;
            PutMoneyOnBtn.Click += PutMoneyOnBtn_Click;
            // 
            // exitBtn
            // 
            resources.ApplyResources(exitBtn, "exitBtn");
            exitBtn.Name = "exitBtn";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // SystemEntrance
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(exitBtn);
            Controls.Add(PutMoneyOnBtn);
            Controls.Add(withdrawBtn);
            Controls.Add(checkBalanceBtn);
            Controls.Add(cardPasswordCont);
            Controls.Add(cardPasswordLabel);
            Controls.Add(CvvContainer);
            Controls.Add(CvvLabel);
            Controls.Add(ExpirationYearCont);
            Controls.Add(slash);
            Controls.Add(ExpirationMonthCont);
            Controls.Add(ExpirationLabel);
            Controls.Add(cardNumCont);
            Controls.Add(cardNumLabel);
            Controls.Add(rulesLabel);
            Controls.Add(btnEng);
            Controls.Add(btnUkr);
            Name = "SystemEntrance";
            Load += SystemEntrance_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUkr;
        private Button btnEng;
        private Label rulesLabel;
        private Label cardNumLabel;
        private TextBox cardNumCont;
        private Label ExpirationLabel;
        private TextBox ExpirationMonthCont;
        private Label slash;
        private TextBox ExpirationYearCont;
        private Label CvvLabel;
        private TextBox CvvContainer;
        private Label cardPasswordLabel;
        private TextBox cardPasswordCont;
        private Button checkBalanceBtn;
        private Button withdrawBtn;
        private Button PutMoneyOnBtn;
        private Button exitBtn;
    }
}
