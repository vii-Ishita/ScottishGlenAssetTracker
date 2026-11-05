using System.Management;
using System.Net;
using System.Net.Sockets;
using ScottishGlenApp.Data;
using ScottishGlenApp.Models;
using System.Linq;
namespace ScottishGlenApp;

public partial class AddEmployeeForm : Form
{
    private readonly ScottishGlenDbContext _dbContext;
    public AddEmployeeForm(ScottishGlenDbContext dbContext)
    {

        _dbContext = dbContext;
        Text = "ScottishGlen - Add Employee";
        Size = new Size(750, 700);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Label title = new Label();
        title.Text = "Add New Employee";
        title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(30, 20);
        title.AutoSize = true;
        Controls.Add(title);
        Label firstNameLabel = new Label();
        firstNameLabel.Text = "First Name:";
        firstNameLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        firstNameLabel.ForeColor = Color.FromArgb(25, 40, 65);
        firstNameLabel.Location = new Point(50, 130);
        firstNameLabel.AutoSize = true;
        Controls.Add(firstNameLabel);
        TextBox firstNameTextBox = new TextBox();
        firstNameTextBox.Font = new Font("Segoe UI", 11);
        firstNameTextBox.Location = new Point(220,125);
        firstNameTextBox.Size = new Size(350, 30);
        Controls.Add(firstNameTextBox);
        Label lastNameLabel = new Label();
        lastNameLabel.Text = "Last Name:";
        lastNameLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        lastNameLabel.ForeColor = Color.FromArgb(25, 40, 65);
        lastNameLabel.Location = new Point(50, 190);
        lastNameLabel.AutoSize = true;
        Controls.Add(lastNameLabel);
        TextBox lastNameTextBox = new TextBox();
        lastNameTextBox.Font = new Font("Segoe UI", 11);
        lastNameTextBox.Location = new Point(220,185);
        lastNameTextBox.Size = new Size(350, 30);
        Controls.Add(lastNameTextBox);
        Label emailLabel = new Label();
        emailLabel.Text = "Email Address:";
        emailLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        emailLabel.ForeColor = Color.FromArgb(25, 40, 65);
        emailLabel.Location = new Point(50, 250);
        emailLabel.AutoSize = true;
        Controls.Add(emailLabel);
        TextBox emailTextBox = new TextBox();
        emailTextBox.Font = new Font("Segoe UI", 11);
        emailTextBox.Location = new Point(220,245);
        emailTextBox.Size = new Size(350, 30);
        Controls.Add(emailTextBox);
        Label departmentLabel = new Label();
        departmentLabel.Text = "Department:";
        departmentLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        departmentLabel.ForeColor = Color.FromArgb(25, 40, 65);
        departmentLabel.Location = new Point(50, 310);
        departmentLabel.AutoSize = true;
        Controls.Add(departmentLabel);
        ComboBox departmentComboBox = new ComboBox();
        departmentComboBox.Font = new Font("Segoe UI", 11);
        departmentComboBox.Location = new Point(220, 305);
        departmentComboBox.Size = new Size(350, 30);
        departmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(departmentComboBox);
        var departments = _dbContext.Departments
            .OrderBy(d=>d.departmentName)
            .ToList();
        departmentComboBox.DataSource = departments;
        departmentComboBox.DisplayMember = "departmentName";
        departmentComboBox.ValueMember = "departmentID";
        departmentComboBox.SelectedIndex = -1;
        Button saveEmployeeButton = new Button();
        saveEmployeeButton.Text = "Save Employee";
        saveEmployeeButton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        saveEmployeeButton.ForeColor = Color.White;
        saveEmployeeButton.BackColor = Color.FromArgb(25, 40, 65);
        saveEmployeeButton.FlatStyle = FlatStyle.Flat;
        saveEmployeeButton.FlatAppearance.BorderSize = 0;
        saveEmployeeButton.Size = new Size(180, 45);
        saveEmployeeButton.Cursor = Cursors.Hand;
        saveEmployeeButton.Location = new Point (220, 390);
        Controls.Add(saveEmployeeButton);
        saveEmployeeButton.Click += (sender, e)=>
        {
           string firstName = firstNameTextBox.Text.Trim();
           string lastName = lastNameTextBox.Text.Trim();
           string email = emailTextBox.Text.Trim();
           if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)||string.IsNullOrWhiteSpace(email)||departmentComboBox.SelectedIndex == -1)
           {
            MessageBox.Show(
                "Please complete all employee fields.",
                "Missing Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
            }
            if(!System.Net.Mail.MailAddress.TryCreate(email, out var emailAddress)||
            emailAddress.Address !=email)
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            } 
            try{
                Employee employee = new Employee{
                    firstName = firstName,
                    lastName = lastName,
                    email = email,
                    departmentID = (int)departmentComboBox.SelectedValue!

                };
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                MessageBox.Show("Employee added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex){
                MessageBox.Show(
                    "Unable to save employee: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                );
            }

        };

    }
}