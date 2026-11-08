using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using ScottishGlenApp;

public class EmployeeManagementForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public EmployeeManagementForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Text = "ScottishGlen - Employee Management";
        Size = new Size(1200, 750);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        Label title = new Label();
        title.Text = "Employee Management";
        title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(50, 40);
        title.AutoSize = true;
        Controls.Add(title);
        Panel addEmployeeCard = new Panel();
        addEmployeeCard.Location = new Point(50, 180);
        addEmployeeCard.Size = new Size(340, 180);
        addEmployeeCard.BackColor = Color.White;
        addEmployeeCard.BorderStyle = BorderStyle.FixedSingle;
        addEmployeeCard.Cursor = Cursors.Hand;
        Controls.Add(addEmployeeCard);
        Label addEmployeeTitle = new Label();
        addEmployeeTitle.Text = "+ Add Employee";
        addEmployeeTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        addEmployeeTitle.ForeColor = Color.FromArgb(25, 40, 65);
        addEmployeeTitle.Location = new Point(25, 35);
        addEmployeeTitle.AutoSize = true;
        addEmployeeCard.Controls.Add(addEmployeeTitle);
        Label addEmployeeDescription = new Label();
        addEmployeeDescription.Text = "Register a new employee";
        addEmployeeDescription.Font = new Font("Segoe UI", 11);
        addEmployeeDescription.ForeColor = Color.Gray;
        addEmployeeDescription.Location = new Point(25, 85);
        addEmployeeDescription.AutoSize = true;
        addEmployeeCard.Controls.Add(addEmployeeDescription);
        EventHandler openAddEmployee = (sender, e) =>
        {
            using (AddEmployeeForm addEmployeeForm = new AddEmployeeForm(_dbContext)){
                addEmployeeForm.ShowDialog();
            }
    
        };
        addEmployeeCard.Click +=openAddEmployee;
        addEmployeeTitle.Click +=openAddEmployee;
        addEmployeeDescription.Click += openAddEmployee;
        Panel editEmployeeCard = new Panel();
        editEmployeeCard.Location = new Point(420, 180);
        editEmployeeCard.Size = new Size(340, 180);
        editEmployeeCard.BackColor = Color.White;
        editEmployeeCard.BorderStyle = BorderStyle.FixedSingle;
        editEmployeeCard.Cursor = Cursors.Hand;
        Controls.Add(editEmployeeCard);
        Label editEmployeeTitle = new Label();
        editEmployeeTitle.Text = "Edit Employee";
        editEmployeeTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        editEmployeeTitle.ForeColor = Color.FromArgb(25, 40, 65);
        editEmployeeTitle.Location = new Point(25, 35);
        editEmployeeTitle.AutoSize = true;
        editEmployeeCard.Controls.Add(editEmployeeTitle);
        Label editEmployeeDescription = new Label();
        editEmployeeDescription.Text = "Update employee information";
        editEmployeeDescription.Font = new Font("Segoe UI", 11);
        editEmployeeDescription.ForeColor = Color.Gray;
        editEmployeeDescription.Location = new Point(25, 85);
        editEmployeeDescription.AutoSize = true;
        editEmployeeCard.Controls.Add(editEmployeeDescription);
        EventHandler openEditEmployee = (sender, e)=>
        {
            using (EditEmployeeForm editEmployeeForm = new EditEmployeeForm(_dbContext)){
                editEmployeeForm.ShowDialog();
            }
        };
        editEmployeeCard.Click +=openEditEmployee;
        editEmployeeTitle.Click += openEditEmployee;
        editEmployeeDescription.Click += openEditEmployee;
        Panel deleteEmployeeCard = new Panel();
        deleteEmployeeCard.Location = new Point(790, 180);
        deleteEmployeeCard.Size = new Size(340, 180);
        deleteEmployeeCard.BackColor = Color.White;
        deleteEmployeeCard.BorderStyle = BorderStyle.FixedSingle;
        deleteEmployeeCard.Cursor = Cursors.Hand;
        Controls.Add(deleteEmployeeCard);
        Label deleteEmployeeTitle = new Label();
        deleteEmployeeTitle.Text = "Delete Employee";
        deleteEmployeeTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        deleteEmployeeTitle.ForeColor = Color.FromArgb(25, 40, 65);
        deleteEmployeeTitle.Location = new Point(25, 35);
        deleteEmployeeTitle.AutoSize = true;
        deleteEmployeeCard.Controls.Add( deleteEmployeeTitle);
        Label deleteEmployeeDescription = new Label();
        deleteEmployeeDescription.Text = "Remove an employee";
        deleteEmployeeDescription.Font = new Font("Segoe UI", 11);
        deleteEmployeeDescription.ForeColor = Color.Gray;
        deleteEmployeeDescription.Location = new Point(25, 85);
        deleteEmployeeDescription.AutoSize = true;
        deleteEmployeeCard.Controls.Add(deleteEmployeeDescription);
        EventHandler openDeleteEmployee = (sender, e)=>
        {
            using (DeleteEmployeeForm deleteEmployeeForm = new DeleteEmployeeForm(_dbContext)){
                deleteEmployeeForm.ShowDialog();
            }
        };
        deleteEmployeeCard.Click +=openDeleteEmployee;
        deleteEmployeeTitle.Click += openDeleteEmployee;
        deleteEmployeeDescription.Click +=openDeleteEmployee;

    }
}