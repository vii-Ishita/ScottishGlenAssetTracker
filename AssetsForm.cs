using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
namespace ScottishGlenApp;

public class AssetsForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public AssetsForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Label assetsTitle = new Label();
        assetsTitle.Text = "Asset Management";
        assetsTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
        assetsTitle.ForeColor = Color.FromArgb(25, 40, 65);
        assetsTitle.Location = new Point(40, 35);
        assetsTitle.AutoSize = true;
        Controls.Add(assetsTitle);

        var allAssets = _dbContext.Assets
            .OrderBy(a => a.assetID)
            .ToList();
        var allEmployees = _dbContext.Employees.ToList();
        DataGridView assetsTable = new DataGridView();
        assetsTable.Location = new Point(40, 270);
        assetsTable.Size = new Size(1500,850);
        assetsTable.BackgroundColor = Color.White;
        assetsTable.BorderStyle = BorderStyle.FixedSingle;
        assetsTable.ReadOnly = true;
        assetsTable.AllowUserToAddRows = false;
        assetsTable.RowHeadersVisible = false;
        assetsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        assetsTable.EnableHeadersVisualStyles = false;
        assetsTable.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 40, 65);
        assetsTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        assetsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        assetsTable.ColumnHeadersHeight = 40;
        assetsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        assetsTable.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        assetsTable.RowTemplate.Height = 35;
        assetsTable.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 245);
        assetsTable.DefaultCellStyle.SelectionForeColor = Color.FromArgb(25, 40, 65);
        assetsTable.DataSource = allAssets.Select(a=>new{
            AssetID = a.assetID,
            SystemName = a.systemName,
            Type = a.type,
            Manufacturer = a.manufacturer,
            Model = a.model,
            IPAddress = a.ipAddress,
            PurchaseDate = a.purchaseDate?.ToString("dd/MM/yyyy") ?? "Not specified",
            Notes = a.notes,
            AssignedEmployee = allEmployees
                .Where(e=>e.employeeID == a.employeeID)
                .Select(e=>e.firstName + " "+e.lastName)
                .FirstOrDefault() ?? "Unassigned"
        }).ToList();
        Controls.Add(assetsTable);
        Text = "ScottishGlen - Assets";
        Size = new Size(1200, 750);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
    }
}