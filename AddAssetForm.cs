using System.Management;
using System.Net;
using System.Net.Sockets;
using ScottishGlenApp.Data;
using ScottishGlenApp.Models;
namespace ScottishGlenApp;

public partial class AddAssetForm : Form
{
    private readonly ScottishGlenDbContext _dbContext;
    public AddAssetForm(ScottishGlenDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
        Label systemNameLabel=new Label();
        systemNameLabel.Text="System Name: ";
        systemNameLabel.Location= new Point (30,30);
        Controls.Add(systemNameLabel);
        TextBox systemNameTextBox = new TextBox();
        systemNameTextBox.Location= new Point (150,30);
        systemNameTextBox.Width=250;
        systemNameTextBox.ReadOnly=true;
        Controls.Add(systemNameTextBox);
        systemNameTextBox.Text=Environment.MachineName;
        Label modelLabel=new Label();
        modelLabel.Text="Model: ";
        modelLabel.Location= new Point (30,70);
        Controls.Add(modelLabel);
        TextBox modelTextBox = new TextBox();
        modelTextBox.Location= new Point (150,70);
        modelTextBox.Width=250;
        modelTextBox.ReadOnly=true;
        Controls.Add(modelTextBox);
        Label manufacturerLabel=new Label();
        manufacturerLabel.Text="Manufacturer: ";
        manufacturerLabel.Location= new Point (30,110);
        Controls.Add(manufacturerLabel);
        TextBox manufacturerTextBox = new TextBox();
        manufacturerTextBox.Location= new Point (150,110);
        manufacturerTextBox.Width=250;
        manufacturerTextBox.ReadOnly=true;
        Controls.Add(manufacturerTextBox);
        Label typeLabel=new Label();
        typeLabel.Text="Type: ";
        typeLabel.Location= new Point (30,150);
        Controls.Add(typeLabel);
        TextBox typeTextBox = new TextBox();
        typeTextBox.Location= new Point (150,150);
        typeTextBox.Width=250;
        typeTextBox.ReadOnly=true;
        Controls.Add(typeTextBox);
        Label ipAddressLabel=new Label();
        ipAddressLabel.Text="IP Address: ";
        ipAddressLabel.Location= new Point (30,190);
        Controls.Add(ipAddressLabel);
        TextBox ipAddressTextBox = new TextBox();
        ipAddressTextBox.Location= new Point (150,190);
        ipAddressTextBox.Width=250;
        ipAddressTextBox.ReadOnly=true;
        Controls.Add(ipAddressTextBox);
        Label purchaseDateLabel=new Label();
        purchaseDateLabel.Text="Purchase Date: ";
        purchaseDateLabel.Location= new Point (30,230);
        Controls.Add(purchaseDateLabel);
        DateTimePicker purchaseDatePicker = new DateTimePicker();
        purchaseDatePicker.Location=new Point (150,230);
        purchaseDatePicker.Width=250;
        purchaseDatePicker.Format=DateTimePickerFormat.Short;
        purchaseDatePicker.ShowCheckBox=true;
        purchaseDatePicker.Checked = false;
        Controls.Add(purchaseDatePicker);
        Label notesLabel=new Label();
        notesLabel.Text="Notes: ";
        notesLabel.Location= new Point (30,270);
        Controls.Add(notesLabel);
        TextBox notesTextBox=new TextBox();
        notesTextBox.Location= new Point (150,270);
        notesTextBox.Width=250;
        notesTextBox.Height=70;
        notesTextBox.Multiline=true;
        Controls.Add(notesTextBox);
        Label employeeLabel=new Label();
        employeeLabel.Text="Assigned Employee: ";
        employeeLabel.Location= new Point (30,360);
        Controls.Add(employeeLabel);
        ComboBox employeeComboBox=new ComboBox();
        employeeComboBox.Location = new Point (150,360);
        employeeComboBox.Width=250;
        employeeComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
        Controls.Add(employeeComboBox);
        Button saveAssetButton = new Button();
        saveAssetButton.Text = "Save Asset";
        saveAssetButton.Location = new Point (130, 410);
        saveAssetButton.Width=120;
        Controls.Add(saveAssetButton);
        saveAssetButton.Click += (sender, e)=>
        {
            if(employeeComboBox.SelectedItem==null){
                MessageBox.Show("Please select an employee.");
                return;
            }
            int selectedEmployeeID = (int)employeeComboBox.SelectedValue!;
            Asset newAsset = new Asset();
            newAsset.systemName = systemNameTextBox.Text;
            newAsset.model=modelTextBox.Text;
            newAsset.manufacturer = manufacturerTextBox.Text;
            newAsset.type = typeTextBox.Text;
            newAsset.ipAddress = ipAddressTextBox.Text;
            if(purchaseDatePicker.Checked==true){
                newAsset.purchaseDate =  purchaseDatePicker.Value.Date;
            } else{
                newAsset.purchaseDate=null;
            }
            newAsset.notes = notesTextBox.Text;
            newAsset.employeeID = selectedEmployeeID;
            try{
                _dbContext.Assets.Add(newAsset);
                _dbContext.SaveChanges();
                MessageBox.Show($"Asset saved successfully! Asset ID: {newAsset.assetID}");
            } catch (Exception ex){
                MessageBox.Show("Failed to save asset: "+ ex.Message);
            }

        };
        var employees = _dbContext.Employees.ToList();
        employeeComboBox.DataSource = employees;
        employeeComboBox.DisplayMember = "FullName";
        employeeComboBox.ValueMember = "employeeID";

        ManagementObjectSearcher searcher= new ManagementObjectSearcher("SELECT Model, Manufacturer, PCSystemType FROM Win32_ComputerSystem");

        var results = searcher.Get();
        foreach(ManagementObject computer in results){
            modelTextBox.Text = computer["Model"]?.ToString()??string.Empty;
            manufacturerTextBox.Text = computer["Manufacturer"]?.ToString()??string.Empty;
            int pcType=Convert.ToInt32(computer["PCSystemType"]);
            if(pcType==1){
                typeTextBox.Text="Desktop";
            }else if(pcType==2){
                typeTextBox.Text="Laptop";
            }else{
                typeTextBox.Text="Other";
            }
        }
        var ipAddresses=Dns.GetHostAddresses(Dns.GetHostName());
        foreach (var ip in ipAddresses){
            if(ip.AddressFamily==AddressFamily.InterNetwork){
                ipAddressTextBox.Text=ip.ToString();
                break;
            }
        }
        
    }
}
