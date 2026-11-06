using System;
using ScottishGlenApp.Models;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using System.Linq;
using ScottishGlenApp;

namespace ScottishGlenApp
{
    public class EditEmployeeForm : Form
    {
        private readonly ScottishGlenDbContext _dbContext;
        public EditEmployeeForm(ScottishGlenDbContext dbContext)
       {
        _dbContext = dbContext;
        Text = "ScottishGlen - Edit Employee Information";
        Size = new Size(900, 700);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Label title = new Label();
        title.Text = "Edit Employee Details";
        title.Font = new Font("Segoe UI", 22, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(50, 35);
        title.AutoSize = true;
        Controls.Add(title);
        Label selectEmployeeLabel = new Label();
        selectEmployeeLabel.Text = "Select Employee: ";
        selectEmployeeLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        selectEmployeeLabel.ForeColor = Color.FromArgb(25, 40, 65);
        selectEmployeeLabel.Location = new Point(50, 130);
        selectEmployeeLabel.AutoSize = true;
        Controls.Add(selectEmployeeLabel);
        ComboBox employeeComboBox = new ComboBox();
        employeeComboBox.Location = new Point(220, 125);
        employeeComboBox.Size = new Size(350,30);
        employeeComboBox.Font = new Font("Segoe UI", 11);
        employeeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(employeeComboBox);
        var employees = _dbContext.Employees
            .OrderBy(e => e.firstName)
            .ThenBy(e => e.lastName)
            .ToList();
        employeeComboBox.DataSource = employees;
        employeeComboBox.DisplayMember = "FullName";
        employeeComboBox.ValueMember = "employeeID";
        employeeComboBox.SelectedIndex = -1;
        Label firstNameLabel = new Label();
        firstNameLabel.Text = "First Name:";
        firstNameLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        firstNameLabel.ForeColor = Color.FromArgb(25, 40, 65);
        firstNameLabel.Location = new Point(50, 190);
        firstNameLabel.AutoSize = true;
        Controls.Add(firstNameLabel);
        TextBox firstNameTextBox = new TextBox();
        firstNameTextBox.Font = new Font("Segoe UI", 11);
        firstNameTextBox.Location = new Point(220,185);
        firstNameTextBox.Size = new Size(350, 30);
        Controls.Add(firstNameTextBox);
        Label lastNameLabel = new Label();
        lastNameLabel.Text = "Last Name:";
        lastNameLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        lastNameLabel.ForeColor = Color.FromArgb(25, 40, 65);
        lastNameLabel.Location = new Point(50, 250);
        lastNameLabel.AutoSize = true;
        Controls.Add(lastNameLabel);
        TextBox lastNameTextBox = new TextBox();
        lastNameTextBox.Font = new Font("Segoe UI", 11);
        lastNameTextBox.Location = new Point(220,245);
        lastNameTextBox.Size = new Size(350, 30);
        Controls.Add(lastNameTextBox);
        Label emailLabel = new Label();
        emailLabel.Text = "Email Address:";
        emailLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        emailLabel.ForeColor = Color.FromArgb(25, 40, 65);
        emailLabel.Location = new Point(50, 310);
        emailLabel.AutoSize = true;
        Controls.Add(emailLabel);
        TextBox emailTextBox = new TextBox();
        emailTextBox.Font = new Font("Segoe UI", 11);
        emailTextBox.Location = new Point(220,305);
        emailTextBox.Size = new Size(350, 30);
        Controls.Add(emailTextBox);
        Label departmentLabel = new Label();
        departmentLabel.Text = "Department:";
        departmentLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        departmentLabel.ForeColor = Color.FromArgb(25, 40, 65);
        departmentLabel.Location = new Point(50, 370);
        departmentLabel.AutoSize = true;
        Controls.Add(departmentLabel);
        ComboBox departmentComboBox = new ComboBox();
        departmentComboBox.Font = new Font("Segoe UI", 11);
        departmentComboBox.Location = new Point(220, 365);
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
        employeeComboBox.SelectedIndexChanged += (sender, e)=>{
            if(employeeComboBox.SelectedItem is Employee selectedEmployee){
                firstNameTextBox.Text = selectedEmployee.firstName;
                lastNameTextBox.Text = selectedEmployee.lastName;
                emailTextBox.Text = selectedEmployee.email;
                departmentComboBox.SelectedValue = selectedEmployee.departmentID;
            }else{
                firstNameTextBox.Clear();
                lastNameTextBox.Clear();
                emailTextBox.Clear();
                departmentComboBox.SelectedIndex = -1;

            }
        };
       
        Button saveButton = new Button();
        saveButton.Text = "Save Changes";
        saveButton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        saveButton.ForeColor = Color.White;
        saveButton.BackColor = Color.FromArgb(25,40,65);
        saveButton.FlatStyle = FlatStyle.Flat;
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.Location = new Point(220, 450);
        saveButton.Size = new Size(180, 45);
        saveButton.Cursor = Cursors.Hand;
        Controls.Add(saveButton);
        saveButton.Click += (sender, e)=>
        {
            if(employeeComboBox.SelectedItem is not Employee selectedEmployee){
                MessageBox.Show("Please select an employee.");
                return;
            }
           string firstName = firstNameTextBox.Text.Trim();
           string lastName = lastNameTextBox.Text.Trim();
           string email = emailTextBox.Text.Trim();
           if (string.IsNullOrWhiteSpace(firstName)||string.IsNullOrWhiteSpace(lastName)||string.IsNullOrWhiteSpace(email)||departmentComboBox.SelectedIndex == -1){
             MessageBox.Show(
                    "Please complete all employee fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
             return;
           }
           if (!System.Net.Mail.MailAddress.TryCreate(email, out var emailAddress)||
           emailAddress.Address !=email){
                MessageBox.Show(
                    "Please enter a vaild email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;

            }
            try{
                selectedEmployee.firstName = firstName;
                selectedEmployee.lastName = lastName;
                selectedEmployee.email = email;
                selectedEmployee.departmentID = (int)departmentComboBox.SelectedValue;
                _dbContext.SaveChanges();

                MessageBox.Show(
                    "Employee updates successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                Close();
            }
            catch (Exception ex){
                MessageBox.Show(
                    "Unable to update employee: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                );
            }
        };

    }
    }
}