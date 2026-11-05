using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using ScottishGlenApp;

public class EditAssetForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public EditAssetForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Text = "ScottishGlen - Edit Asset";
        Size = new Size(900, 700);
        AutoScroll = true;
        AutoScrollMinSize = new Size(0, 1100);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        Label title = new Label();
        title.Text = "Edit Asset";
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
        Label systemNameLabel = new Label();
        systemNameLabel.Text = "System Name";
        systemNameLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        systemNameLabel.ForeColor = Color.FromArgb(25, 40, 65);
        systemNameLabel.Location = new Point(40, 210);
        systemNameLabel.AutoSize = true;
        Controls.Add(systemNameLabel);
        TextBox systemNameTextBox = new TextBox();
        systemNameTextBox.Location = new Point(40, 245);
        systemNameTextBox.Size = new Size(500,35);
        systemNameTextBox.Font = new Font("Segoe UI", 11);
        Controls.Add(systemNameTextBox);
        Label modelLabel = new Label();
        modelLabel.Text = "Model: ";
        modelLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        modelLabel.ForeColor = Color.FromArgb(25, 40, 65);
        modelLabel.Location = new Point(40, 300);
        modelLabel.AutoSize = true;
        Controls.Add(modelLabel);
        TextBox modelTextBox = new TextBox();
        modelTextBox.Location = new Point(40, 335);
        modelTextBox.Size = new Size(500,35);
        modelTextBox.Font = new Font("Segoe UI", 11);
        Controls.Add(modelTextBox);
        Label manufacturerLabel = new Label();
        manufacturerLabel.Text = "Manufacturer: ";
        manufacturerLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        manufacturerLabel.ForeColor = Color.FromArgb(25, 40, 65);
        manufacturerLabel.Location = new Point(40, 390);
        manufacturerLabel.AutoSize = true;
        Controls.Add(manufacturerLabel);
        TextBox manufacturerTextBox = new TextBox();
        manufacturerTextBox.Location = new Point(40, 425);
        manufacturerTextBox.Size = new Size(500,35);
        manufacturerTextBox.Font = new Font("Segoe UI", 11);
        Controls.Add(manufacturerTextBox);
        Label typeLabel = new Label();
        typeLabel.Text = "Asset Type: ";
        typeLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        typeLabel.ForeColor = Color.FromArgb(25, 40, 65);
        typeLabel.Location = new Point(40, 480);
        typeLabel.AutoSize = true;
        Controls.Add(typeLabel);
        TextBox typeTextBox = new TextBox();
        typeTextBox.Location = new Point(40, 515);
        typeTextBox.Size = new Size(500,35);
        typeTextBox.Font = new Font("Segoe UI", 11);
        Controls.Add(typeTextBox);
        Label ipAddressLabel = new Label();
        ipAddressLabel.Text = "IP Address: ";
        ipAddressLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        ipAddressLabel.ForeColor = Color.FromArgb(25, 40, 65);
        ipAddressLabel.Location = new Point(40, 570);
        ipAddressLabel.AutoSize = true;
        Controls.Add(ipAddressLabel);
        TextBox ipAddressTextBox = new TextBox();
        ipAddressTextBox.Location = new Point(40, 605);
        ipAddressTextBox.Size = new Size(500,35);
        ipAddressTextBox.Font = new Font("Segoe UI", 11);
        Controls.Add(ipAddressTextBox);
        Label purchaseDateLabel = new Label();
        purchaseDateLabel.Text = "Purchase Date: ";
        purchaseDateLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        purchaseDateLabel.ForeColor = Color.FromArgb(25, 40, 65);
        purchaseDateLabel.Location = new Point(40, 660);
        purchaseDateLabel.AutoSize = true;
        Controls.Add(purchaseDateLabel);
        DateTimePicker purchaseDatePicker = new DateTimePicker();
        purchaseDatePicker.Location = new Point(40, 695);
        purchaseDatePicker.Size = new Size(500,35);
        purchaseDatePicker.Font = new Font("Segoe UI", 11);
        purchaseDatePicker.Format = DateTimePickerFormat.Short;
        purchaseDatePicker.ShowCheckBox = true;
        purchaseDatePicker.Checked = false;
        Controls.Add(purchaseDatePicker);
        Label notesLabel = new Label();
        notesLabel.Text = "Notes (Optional): ";
        notesLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        notesLabel.ForeColor = Color.FromArgb(25, 40, 65);
        notesLabel.Location = new Point(40, 750);
        notesLabel.AutoSize = true;
        Controls.Add(notesLabel);
        TextBox notesTextBox = new TextBox();
        notesTextBox.Location = new Point(40, 785);
        notesTextBox.Size = new Size(500,90);
        notesTextBox.Font = new Font("Segoe UI", 11);
        notesTextBox.Multiline = true;
        notesTextBox.ScrollBars = ScrollBars.Vertical;
        Controls.Add(notesTextBox);
        Label employeeLabel = new Label();
        employeeLabel.Text = "Assigned Employee";
        employeeLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        employeeLabel.ForeColor = Color.FromArgb(25, 40, 65);
        employeeLabel.Location = new Point(40, 895);
        employeeLabel.AutoSize = true;
        Controls.Add(employeeLabel);
        ComboBox employeeDropdown = new ComboBox();
        employeeDropdown.Location = new Point(40, 930);
        employeeDropdown.Size = new Size(500,35);
        employeeDropdown.Font = new Font("Segoe UI", 11);
        employeeDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(employeeDropdown);
        var employees = _dbContext.Employees
            .OrderBy(e => e.firstName)
            .Select(e=>new
            {
                EmployeeID = e.employeeID,
                FullName = e.firstName + "-" + e.lastName
            })
            .ToList();
        employeeDropdown.DataSource = employees;
        employeeDropdown.DisplayMember = "FullName";
        employeeDropdown.ValueMember = "EmployeeID";
        Button saveButton = new Button();
        saveButton.Text = "Save Changes";
        saveButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        saveButton.ForeColor = Color.White;
        saveButton.BackColor = Color.FromArgb(25,40,65);
        saveButton.FlatStyle = FlatStyle.Flat;
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.Location = new Point(40, 1000);
        saveButton.Size = new Size(200, 50);
        saveButton.Cursor = Cursors.Hand;
        Controls.Add(saveButton);
        saveButton.Click += (sender, e)=>
        {
            if(assetDropdown.SelectedValue is not int selectedAssetID){
                MessageBox.Show("Please select an asset.");
                return;
            }
            if(string.IsNullOrWhiteSpace(systemNameTextBox.Text)){
                MessageBox.Show("System Name cannot be empty.");
                return;
            }
            var asset = _dbContext.Assets
                .FirstOrDefault(a=>a.assetID == selectedAssetID);
            if(asset == null){
                MessageBox.Show("The selected asset could not be found");
                return;
            }
            asset.systemName = systemNameTextBox.Text.Trim();
            asset.model = modelTextBox.Text.Trim();
            asset.manufacturer = manufacturerTextBox.Text.Trim();
            asset.type = typeTextBox.Text.Trim();
            asset.ipAddress = ipAddressTextBox.Text.Trim();
            asset.purchaseDate = purchaseDatePicker.Checked ? purchaseDatePicker.Value.Date:null;
            asset.notes = notesTextBox.Text.Trim();
            if(employeeDropdown.SelectedValue is int employeeID){
                asset.employeeID = employeeID;
            } try{
                _dbContext.SaveChanges();
                MessageBox.Show(
                    "Asset updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex){
                MessageBox.Show(
                    "Unable to update asset: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                );
            }
        };

        assetDropdown.SelectedIndexChanged += (sender, e) =>
        {
            if(assetDropdown.SelectedValue is int selectedAssetID){
                var selectedAsset = _dbContext.Assets
                    .FirstOrDefault(a=>a.assetID == selectedAssetID);
                if (selectedAsset != null){
                    systemNameTextBox.Text = selectedAsset.systemName;
                    modelTextBox.Text = selectedAsset.model ?? "";
                    manufacturerTextBox.Text = selectedAsset.manufacturer ?? "";
                    typeTextBox.Text = selectedAsset.type ?? "";
                    ipAddressTextBox.Text = selectedAsset.ipAddress ?? "";
                    notesTextBox.Text = selectedAsset.notes ?? "";
                    employeeDropdown.SelectedValue = selectedAsset.employeeID;
                    purchaseDatePicker.Checked = selectedAsset.purchaseDate.HasValue;
                    if (selectedAsset.purchaseDate.HasValue){
                        purchaseDatePicker.Value = selectedAsset.purchaseDate.Value;
                    }

                }
            }
        };
        if (assetDropdown.SelectedValue is int initialAssetID){
            var initialAsset = _dbContext.Assets
                .FirstOrDefault(a=>a.assetID == initialAssetID);
            if(initialAsset != null){
                systemNameTextBox.Text = initialAsset.systemName;
                modelTextBox.Text = initialAsset.model ?? "";
                manufacturerTextBox.Text = initialAsset.manufacturer ?? "";
                typeTextBox.Text = initialAsset.type ?? "";
                ipAddressTextBox.Text = initialAsset.ipAddress ?? "";
                notesTextBox.Text = initialAsset.notes ?? "";
                purchaseDatePicker.Checked = initialAsset.purchaseDate.HasValue;
                employeeDropdown.SelectedValue = initialAsset.employeeID;
                if (initialAsset.purchaseDate.HasValue){
                    purchaseDatePicker.Value = initialAsset.purchaseDate.Value;
                }

            }

        }

    }
}