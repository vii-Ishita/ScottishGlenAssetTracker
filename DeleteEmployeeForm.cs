using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using ScottishGlenApp;
using System.Linq;

public class DeleteEmployeeForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public DeleteEmployeeForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Text = "ScottishGlen - Delete Employee";
        Size = new Size(900, 700);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        Label title = new Label();
        title.Text = "Delete Employee";
        title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(40, 30);
        title.AutoSize = true;
        Controls.Add(title);
        Label selectEmployeeLabel = new Label();
        selectEmployeeLabel.Text = "Select an Employee";
        selectEmployeeLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
        selectEmployeeLabel.ForeColor = Color.FromArgb(25, 40, 65);
        selectEmployeeLabel.Location = new Point(40, 110);
        selectEmployeeLabel.AutoSize = true;
        Controls.Add(selectEmployeeLabel);
        ComboBox employeeDropdown = new ComboBox();
        employeeDropdown.Location = new Point(40, 145);
        employeeDropdown.Size = new Size(500,35);
        employeeDropdown.Font = new Font("Segoe UI", 11);
        employeeDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
        Controls.Add(employeeDropdown);
        var employees = _dbContext.Employees
            .OrderBy(e=>e.employeeID)
            .Select(e=>new
            {
                EmployeeID = e.employeeID,
                DisplayName = e.employeeID + "-" + e.lastName
            })
            .ToList();
        employeeDropdown.DataSource = employees;
        employeeDropdown.DisplayMember = "DisplayName";
        employeeDropdown.ValueMember = "EmployeeID";
        employeeDropdown.SelectedIndex = -1;
        Button deleteButton = new Button();
        deleteButton.Text = "DeleteEmployee";
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
            if(employeeDropdown.SelectedValue is not int selectedEmployeeID){
                MessageBox.Show("Please select an employee to delete.");
                return;
            }
            var employee = _dbContext.Employees
                .FirstOrDefault(e=>e.employeeID == selectedEmployeeID);
            if(employee == null){
                MessageBox.Show("The selected employee could not be found");
                return;
            }
            DialogResult confirmation = MessageBox.Show(
                $"Are you sure you want to delete {employee.firstName} {employee.lastName} (ID:{employee.employeeID})?",
                "Confirm Employee Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );
            if(confirmation != DialogResult.Yes){
                return;
            }
             try{
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
                MessageBox.Show(
                    "Employee deleted successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                DialogResult =DialogResult.OK;
                Close();
            }
            catch (Exception ex){
                MessageBox.Show(
                    "Unable to delete employee: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error

                );
            }
        };
    }   
}