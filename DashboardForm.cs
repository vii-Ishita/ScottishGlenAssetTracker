using ScottishGlenApp.Data;
namespace ScottishGlenApp;
public partial class DashboardForm: Form{
    private readonly ScottishGlenDbContext _dbContext;
    public DashboardForm(ScottishGlenDbContext dbContext){
        _dbContext = dbContext;
        int totalAssets = _dbContext.Assets.Count();
        int totalEmployees = _dbContext.Employees.Count();
        int totalDepartments = _dbContext.Departments.Count();
        int assignedAssets = _dbContext.Assets.Count(a=> a.employeeID != 0);
        var recentAssets = _dbContext.Assets
            .OrderByDescending(a=>a.assetID)
            .Take(5)
            .ToList();

        Text = "ScottishGlen - Dashboard";
        Size = new Size(1500,850);
        BackColor = Color.FromArgb(245, 247, 250);
        StartPosition= FormStartPosition.CenterScreen;
        Panel sidebarPanel = new Panel();
        sidebarPanel.BackColor = Color.FromArgb(25, 40, 65);
        sidebarPanel.Dock = DockStyle.Left;
        sidebarPanel.Width = 220;
        Controls.Add(sidebarPanel);
        Label brandLabel = new Label();
        brandLabel.Text = "ScottishGlen";
        brandLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        brandLabel.ForeColor = Color.White;
        brandLabel.Location = new Point(20,25);
        brandLabel.AutoSize = true;
        sidebarPanel.Controls.Add(brandLabel);
        Button dashboardButton = new Button();
        dashboardButton.Text = "Dashboard";
        dashboardButton.Location = new Point(20, 110);
        dashboardButton.Size = new Size (180, 45);
        dashboardButton.FlatStyle = FlatStyle.Flat;
        dashboardButton.FlatAppearance.BorderSize=0;
        dashboardButton.BackColor = Color.FromArgb(45, 65, 95);
        dashboardButton.ForeColor = Color.White;
        dashboardButton.Font = new Font("Segoe UI", 11);
        sidebarPanel.Controls.Add(dashboardButton);
        Label dashboardTitle = new Label();
        dashboardTitle.Text = "Dashboard Overview";
        dashboardTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
        dashboardTitle.ForeColor = Color.FromArgb(25,40,65);
        dashboardTitle.Location = new Point(260, 55);
        dashboardTitle.AutoSize = true;
        Controls.Add(dashboardTitle);
        Label dashboardSubtitle = new Label();
        dashboardSubtitle.Text = "ScottishGlen Asset Tracking System";
        dashboardSubtitle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
        dashboardSubtitle.ForeColor = Color.FromArgb(110, 120, 135);
        dashboardSubtitle.Location = new Point(262, 105);
        dashboardSubtitle.AutoSize = true;
        Controls.Add(dashboardSubtitle);
        Button addNewAssetButton = new Button();
        addNewAssetButton.Text = "+ Add New Asset";
        addNewAssetButton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        addNewAssetButton.ForeColor = Color.White;
        addNewAssetButton.BackColor = Color.FromArgb(25, 40, 65);
        addNewAssetButton.FlatStyle = FlatStyle.Flat;
        addNewAssetButton.FlatAppearance.BorderSize = 0;
        addNewAssetButton.Size = new Size(180,45);
        addNewAssetButton.Location = new Point(1100, 75);
        addNewAssetButton.Cursor = Cursors.Hand;
        Controls.Add(addNewAssetButton);
        Button AssetButton = new Button();
        AssetButton.Text = "Assets";
        AssetButton.Location = new Point(20, 165);
        AssetButton.Size = new Size (180, 45);
        AssetButton.FlatStyle = FlatStyle.Flat;
        AssetButton.FlatAppearance.BorderSize=0;
        AssetButton.BackColor = Color.FromArgb(25, 40, 65);
        AssetButton.ForeColor = Color.White;
        AssetButton.Font = new Font("Segoe UI", 11);
        sidebarPanel.Controls.Add(AssetButton);
        Button EmployeeButton = new Button();
        EmployeeButton.Text = "Employees";
        EmployeeButton.Location = new Point(20, 220);
        EmployeeButton.Size = new Size (180, 45);
        EmployeeButton.FlatStyle = FlatStyle.Flat;
        EmployeeButton.FlatAppearance.BorderSize=0;
        EmployeeButton.BackColor = Color.FromArgb(25, 40, 65);
        EmployeeButton.ForeColor = Color.White;
        EmployeeButton.Font = new Font("Segoe UI", 11);
        EmployeeButton.Click += (sender, e) =>{
              using(EmployeeManagementForm employeeManagementForm = new EmployeeManagementForm(_dbContext)){
                employeeManagementForm.ShowDialog();
              }
            
        
        };
        sidebarPanel.Controls.Add(EmployeeButton);
        Button DepartmentButton = new Button();
        DepartmentButton.Text = "Departments";
        DepartmentButton.Location = new Point(20, 275);
        DepartmentButton.Size = new Size (180, 45);
        DepartmentButton.FlatStyle = FlatStyle.Flat;
        DepartmentButton.FlatAppearance.BorderSize=0;
        DepartmentButton.BackColor = Color.FromArgb(25, 40, 65);
        DepartmentButton.ForeColor = Color.White;
        DepartmentButton.Font = new Font("Segoe UI", 11);
        DepartmentButton.Click += (sender, e) =>
        {
            DepartmentsForm departmentsForm = new DepartmentsForm(_dbContext);
            departmentsForm.ShowDialog();
        };
        sidebarPanel.Controls.Add(DepartmentButton);
        Panel totalAssetsCard = new Panel();
        totalAssetsCard.Location = new Point(260, 180);
        totalAssetsCard.Size = new Size(290, 130);
        totalAssetsCard.BackColor = Color.White;
        totalAssetsCard.BorderStyle = BorderStyle.None;
        Controls.Add(totalAssetsCard);
        Panel cardBorder = new Panel();
        cardBorder.Location = new Point(259, 179);
        cardBorder.Size = new Size(292, 132);
        cardBorder.BackColor = Color.FromArgb(225, 230, 235);
        Controls.Add(cardBorder);
        cardBorder.SendToBack();
        Label totalAssetsLabel = new Label();
        totalAssetsLabel.Text = "TOTAL ASSETS";
        totalAssetsLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        totalAssetsLabel.ForeColor = Color.FromArgb(110, 120, 135);
        totalAssetsLabel.Location = new Point(25, 25);
        totalAssetsLabel.AutoSize = true;
        totalAssetsCard.Controls.Add(totalAssetsLabel); 
        Label totalAssetsNumber = new Label();
        totalAssetsNumber.Text = totalAssets.ToString();
        totalAssetsNumber.Font = new Font("Segoe UI", 26, FontStyle.Bold);
        totalAssetsNumber.ForeColor = Color.FromArgb(25, 40, 65);
        totalAssetsNumber.Location = new Point(25, 55);
        totalAssetsNumber.AutoSize = true;
        totalAssetsCard.Controls.Add(totalAssetsNumber);
        Panel totalEmployeesCard = new Panel();
        totalEmployeesCard.Location = new Point(570, 180);
        totalEmployeesCard.Size = new Size(290, 130);
        totalEmployeesCard.BackColor = Color.White;
        totalEmployeesCard.BorderStyle = BorderStyle.None;
        Controls.Add(totalEmployeesCard);
        Panel totalEmployeesCardBorder = new Panel();
        totalEmployeesCardBorder.Location = new Point(569, 179);
        totalEmployeesCardBorder.Size = new Size(292, 132);
        totalEmployeesCardBorder.BackColor = Color.FromArgb(225, 230, 235);
        Controls.Add(totalEmployeesCardBorder);
        totalEmployeesCardBorder.SendToBack();
        Label totalEmployeesLabel = new Label();
        totalEmployeesLabel.Text = "TOTAL EMPLOYEES";
        totalEmployeesLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        totalEmployeesLabel.ForeColor = Color.FromArgb(110, 120, 135);
        totalEmployeesLabel.Location = new Point(25, 25);
        totalEmployeesLabel.AutoSize = true;
        totalEmployeesCard.Controls.Add(totalEmployeesLabel); 
        Label totalEmployeesNumber = new Label();
        totalEmployeesNumber.Text = totalEmployees.ToString();
        totalEmployeesNumber.Font = new Font("Segoe UI", 26, FontStyle.Bold);
        totalEmployeesNumber.ForeColor = Color.FromArgb(25, 40, 65);
        totalEmployeesNumber.Location = new Point(25, 55);
        totalEmployeesNumber.AutoSize = true;
        totalEmployeesCard.Controls.Add(totalEmployeesNumber);
        Panel totalDepartmentsCard = new Panel();
        totalDepartmentsCard.Location = new Point(880, 180);
        totalDepartmentsCard.Size = new Size(290, 130);
        totalDepartmentsCard.BackColor = Color.White;
        totalDepartmentsCard.BorderStyle = BorderStyle.None;
        Controls.Add(totalDepartmentsCard);
        Panel totalDepartmentsCardBorder = new Panel();
        totalDepartmentsCardBorder.Location = new Point(879, 179);
        totalDepartmentsCardBorder.Size = new Size(292, 132);
        totalDepartmentsCardBorder.BackColor = Color.FromArgb(225, 230, 235);
        Controls.Add(totalDepartmentsCardBorder);
        totalDepartmentsCardBorder.SendToBack();
        Label totalDepartmentsLabel = new Label();
        totalDepartmentsLabel.Text = "TOTAL DEPARTMENTS";
        totalDepartmentsLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        totalDepartmentsLabel.ForeColor = Color.FromArgb(110, 120, 135);
        totalDepartmentsLabel.Location = new Point(25, 25);
        totalDepartmentsLabel.AutoSize = true;
        totalDepartmentsCard.Controls.Add(totalDepartmentsLabel); 
        Label totalDepartmentsNumber = new Label();
        totalDepartmentsNumber.Text = totalDepartments.ToString();
        totalDepartmentsNumber.Font = new Font("Segoe UI", 26, FontStyle.Bold);
        totalDepartmentsNumber.ForeColor = Color.FromArgb(25, 40, 65);
        totalDepartmentsNumber.Location = new Point(25, 55);
        totalDepartmentsNumber.AutoSize = true;
        totalDepartmentsCard.Controls.Add(totalDepartmentsNumber);
        Panel assignedAssetsCard = new Panel();
        assignedAssetsCard.Location = new Point(1190, 180);
        assignedAssetsCard.Size = new Size(290, 130);
        assignedAssetsCard.BackColor = Color.White;
        assignedAssetsCard.BorderStyle = BorderStyle.None;
        Controls.Add(assignedAssetsCard);
        Panel assignedAssetsCardBorder = new Panel();
        assignedAssetsCardBorder.Location = new Point(1189, 179);
        assignedAssetsCardBorder.Size = new Size(292, 132);
        assignedAssetsCardBorder.BackColor = Color.FromArgb(225, 230, 235);
        Controls.Add(assignedAssetsCardBorder);
        assignedAssetsCardBorder.SendToBack();
        Label assignedAssetsLabel = new Label();
        assignedAssetsLabel.Text = "ASSIGNED ASSETS";
        assignedAssetsLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        assignedAssetsLabel.ForeColor = Color.FromArgb(110, 120, 135);
        assignedAssetsLabel.Location = new Point(25, 25);
        assignedAssetsLabel.AutoSize = true;
        assignedAssetsCard.Controls.Add(assignedAssetsLabel); 
        Label assignedAssetsNumber = new Label();
        assignedAssetsNumber.Text = assignedAssets.ToString();
        assignedAssetsNumber.Font = new Font("Segoe UI", 26, FontStyle.Bold);
        assignedAssetsNumber.ForeColor = Color.FromArgb(25, 40, 65);
        assignedAssetsNumber.Location = new Point(25, 55);
        assignedAssetsNumber.AutoSize = true;
        assignedAssetsCard.Controls.Add(assignedAssetsNumber);
        Label recentAssetsTitle = new Label();
        recentAssetsTitle.Text = "Recently Added Assets";
        recentAssetsTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        recentAssetsTitle.ForeColor = Color.FromArgb(25, 40, 65);
        recentAssetsTitle.Location = new Point(260, 365);
        recentAssetsTitle.AutoSize = true;
        Controls.Add(recentAssetsTitle);
        Label recentAssetsSubtitle = new Label();
        recentAssetsSubtitle.Text = "The five most recently registered assets";
        recentAssetsSubtitle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        recentAssetsSubtitle.ForeColor = Color.FromArgb(110, 120, 135);
        recentAssetsSubtitle.Location = new Point(262, 400);
        recentAssetsSubtitle.AutoSize = true;
        Controls.Add(recentAssetsSubtitle);
        DataGridView recentAssetsTable = new DataGridView();
        recentAssetsTable.Location = new Point(260, 440);
        recentAssetsTable.Size = new Size(1200, 140);
        recentAssetsTable.BackgroundColor = Color.White;
        recentAssetsTable.BorderStyle = BorderStyle.FixedSingle;
        recentAssetsTable.ReadOnly = true;
        recentAssetsTable.AllowUserToAddRows = false;
        recentAssetsTable.RowHeadersVisible = false;
        recentAssetsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        recentAssetsTable.EnableHeadersVisualStyles = false;
        recentAssetsTable.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 40, 65);
        recentAssetsTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        recentAssetsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        recentAssetsTable.ColumnHeadersHeight = 35;
        recentAssetsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        recentAssetsTable.DefaultCellStyle.Font = new Font("Segoe UI", 10);;
        recentAssetsTable.RowTemplate.Height = 32;
        recentAssetsTable.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 245);
        recentAssetsTable.DefaultCellStyle.SelectionForeColor = Color.FromArgb(25,40, 65);
        recentAssetsTable.DefaultCellStyle.ForeColor = Color.FromArgb(25, 40, 65);
        recentAssetsTable.DefaultCellStyle.BackColor = Color.White;
        recentAssetsTable.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        recentAssetsTable.DataSource = recentAssets
            .Select(a => new{
                AssetID = a.assetID,
                SystemName = a.systemName,
                Type = a.type,
                Manufacturer = a.manufacturer,
                Model = a.model,
                PurchaseDate = a.purchaseDate?.ToString("dd/MM/yyyy")?? "Not specified",
                Notes = a.notes
            })
            .ToList();
        Controls.Add(recentAssetsTable);
         AssetButton.Click += (sender, e)=>
        {
            AssetManagementForm assetManagementForm = new AssetManagementForm(_dbContext);
            assetManagementForm.ShowDialog();
        };
        addNewAssetButton.Click += (sender, e) =>
        {
            AddAssetForm addAssetForm = new AddAssetForm(_dbContext);
            addAssetForm.ShowDialog();
            totalAssetsNumber.Text = _dbContext.Assets.Count().ToString();
            assignedAssetsNumber.Text = _dbContext.Assets.Count(a=>a.employeeID !=0).ToString();
            recentAssetsTable.DataSource = _dbContext.Assets
                .OrderByDescending(a=>a.assetID)
                .Take(5)
                .ToList()
                .Select(a=>new
                {
                    AssetID = a.assetID,
                    SystemName = a.systemName,
                    Type = a.type,
                    Manufacturer = a.manufacturer,
                    Model = a.model,
                    PurchaseDate = a.purchaseDate?.ToString("dd/MM/yyyy")?? "Not specified",
                    Notes = a.notes
                })
                .ToList();
        };

    }
}