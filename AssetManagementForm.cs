using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using ScottishGlenApp;

public class AssetManagementForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public AssetManagementForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Text = "ScottishGlen - Asset Management";
        Size = new Size(1200, 750);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        Label title = new Label();
        title.Text = "Asset Management";
        title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(50, 40);
        title.AutoSize = true;
        Controls.Add(title);
        Panel addAssetCard = new Panel();
        addAssetCard.Location = new Point(50, 130);
        addAssetCard.Size = new Size(500, 180);
        addAssetCard.BackColor = Color.White;
        addAssetCard.BorderStyle = BorderStyle.FixedSingle;
        addAssetCard.Cursor = Cursors.Hand;
        Controls.Add(addAssetCard);
        Label addAssetTitle = new Label();
        addAssetTitle.Text = "+ Add Asset";
        addAssetTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        addAssetTitle.ForeColor = Color.FromArgb(25, 40, 65);
        addAssetTitle.Location = new Point(25, 35);
        addAssetTitle.AutoSize = true;
        addAssetCard.Controls.Add(addAssetTitle);
        Label addAssetDescription = new Label();
        addAssetDescription.Text = "Register a new company asset";
        addAssetDescription.Font = new Font("Segoe UI", 11);
        addAssetDescription.ForeColor = Color.Gray;
        addAssetDescription.Location = new Point(25, 85);
        addAssetDescription.AutoSize = true;
        addAssetCard.Controls.Add(addAssetDescription);
        EventHandler openAddAsset = (sender, e) =>
        {
            using (AddAssetForm addAssetForm = new AddAssetForm(_dbContext)){
                addAssetForm.ShowDialog();
            }
        };
        addAssetCard.Click +=openAddAsset;
        addAssetTitle.Click +=openAddAsset;
        addAssetDescription.Click += openAddAsset;
        Panel viewAssetsCard = new Panel();
        viewAssetsCard.Location = new Point(600, 130);
        viewAssetsCard.Size = new Size(500, 180);
        viewAssetsCard.BackColor = Color.White;
        viewAssetsCard.BorderStyle = BorderStyle.FixedSingle;
        viewAssetsCard.Cursor = Cursors.Hand;
        Controls.Add(viewAssetsCard);
        Label viewAssetsTitle = new Label();
        viewAssetsTitle.Text = "View All Assets";
        viewAssetsTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        viewAssetsTitle.ForeColor = Color.FromArgb(25, 40, 65);
        viewAssetsTitle.Location = new Point(25, 35);
        viewAssetsTitle.AutoSize = true;
        viewAssetsCard.Controls.Add(viewAssetsTitle);
        Label viewAssetsDescription = new Label();
        viewAssetsDescription.Text = "Browse all registered company assets";
        viewAssetsDescription.Font = new Font("Segoe UI", 11);
        viewAssetsDescription.ForeColor = Color.Gray;
        viewAssetsDescription.Location = new Point(25, 85);
        viewAssetsDescription.AutoSize = true;
        viewAssetsCard.Controls.Add(viewAssetsDescription);
        EventHandler openViewAssets = (sender, e) =>
        {
            using (AssetsForm assetsForm = new AssetsForm(_dbContext)){
                assetsForm.ShowDialog();
            }
        };
        viewAssetsCard.Click +=openViewAssets;
        viewAssetsTitle.Click +=openViewAssets;
        viewAssetsDescription.Click += openViewAssets;
        Panel editAssetCard = new Panel();
        editAssetCard.Location = new Point(50, 350);
        editAssetCard.Size = new Size(500, 180);
        editAssetCard.BackColor = Color.White;
        editAssetCard.BorderStyle = BorderStyle.FixedSingle;
        editAssetCard.Cursor = Cursors.Hand;
        Controls.Add(editAssetCard);
        Label editAssetTitle = new Label();
        editAssetTitle.Text = "Edit Asset";
        editAssetTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        editAssetTitle.ForeColor = Color.FromArgb(25, 40, 65);
        editAssetTitle.Location = new Point(25, 35);
        editAssetTitle.AutoSize = true;
        editAssetCard.Controls.Add(editAssetTitle);
        Label editAssetDescription = new Label();
        editAssetDescription.Text = "Update existing asset information";
        editAssetDescription.Font = new Font("Segoe UI", 11);
        editAssetDescription.ForeColor = Color.Gray;
        editAssetDescription.Location = new Point(25, 85);
        editAssetDescription.AutoSize = true;
        editAssetCard.Controls.Add(editAssetDescription);
        Panel deleteAssetCard = new Panel();
        deleteAssetCard.Location = new Point(600, 350);
        deleteAssetCard.Size = new Size(500, 180);
        deleteAssetCard.BackColor = Color.White;
        deleteAssetCard.BorderStyle = BorderStyle.FixedSingle;
        deleteAssetCard.Cursor = Cursors.Hand;
        Controls.Add(deleteAssetCard);
        Label deleteAssetTitle = new Label();
        deleteAssetTitle.Text = "Delete Asset";
        deleteAssetTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        deleteAssetTitle.ForeColor = Color.FromArgb(25, 40, 65);
        deleteAssetTitle.Location = new Point(25, 35);
        deleteAssetTitle.AutoSize = true;
        deleteAssetCard.Controls.Add(deleteAssetTitle);
        Label deleteAssetDescription = new Label();
        deleteAssetDescription.Text = "Remove an existing company asset";
        deleteAssetDescription.Font = new Font("Segoe UI", 11);
        deleteAssetDescription.ForeColor = Color.Gray;
        deleteAssetDescription.Location = new Point(25, 85);
        deleteAssetDescription.AutoSize = true;
        deleteAssetCard.Controls.Add(deleteAssetDescription);

        
    }
}
