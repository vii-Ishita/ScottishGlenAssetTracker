using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using ScottishGlenApp;

public class DeleteAssetForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public DeleteAssetForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Text = "ScottishGlen - Delete Asset";
        Size = new Size(900, 700);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        Label title = new Label();
        title.Text = "Delete Asset";
        title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(40, 30);
        title.AutoSize = true;
        Controls.Add(title);
        Label selectAssetLabel = new Label();
        selectAssetLabel.Text = "Select an Asset";
        selectAssetLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        selectAssetLabel.ForeColor = Color.FromArgb(25, 40, 65);
        selectAssetLabel.Location = new Point(40, 110);
        selectAssetLabel.AutoSize = true;
        Controls.Add(selectAssetLabel);
        ComboBox assetDropdown = new ComboBox();
        assetDropdown.Location = new Point(40, 145);
        assetDropdown.Size = new Size(500,35);
        assetDropdown.Font = new Font("Segoe UI", 11);
        assetDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(assetDropdown);
        var assets = _dbContext.Assets
            .OrderBy(a=>a.assetID)
            .Select(a=>new
            {
                AssetID = a.assetID,
                DisplayName = a.assetID + "-" + a.systemName
            })
            .ToList();
        assetDropdown.DataSource = assets;
        assetDropdown.DisplayMember = "DisplayName";
        assetDropdown.ValueMember = "AssetID";
        Button deleteButton = new Button();
        deleteButton.Text = "Delete Asset";
        deleteButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        deleteButton.ForeColor = Color.White;
        deleteButton.BackColor = Color.FromArgb(190,45,55);
        deleteButton.FlatStyle = FlatStyle.Flat;
        deleteButton.FlatAppearance.BorderSize = 0;
        deleteButton.Location = new Point(40, 230);
        deleteButton.Size = new Size(200, 50);
        deleteButton.Cursor = Cursors.Hand;
        Controls.Add(deleteButton);
        deleteButton.Click += (sender, e)=>
        {
            if(assetDropdown.SelectedValue is not int selectedAssetID){
                MessageBox.Show("Please select an asset to delete.");
                return;
            }
            var asset = _dbContext.Assets
                .FirstOrDefault(a=>a.assetID == selectedAssetID);
            if(asset == null){
                MessageBox.Show("The selected asset could not be found");
                return;
            }
            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete {asset.assetID}-{asset.systemName} permanently?",
                "Confirm Asset Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );
            if(confirmation != DialogResult.Yes){
                return;
            }
             try{
                _dbContext.Assets.Remove(asset);
                _dbContext.SaveChanges();
                MessageBox.Show(
                    "Asset deleted successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                DialogResult =DialogResult.OK;
                Close();
            }
            catch (Exception ex){
                MessageBox.Show(
                    "Unable to delete asset: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                );
            }
        };
    }   
}