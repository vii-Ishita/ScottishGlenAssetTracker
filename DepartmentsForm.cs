using System;
using System.Drawing;
using System.Windows.Forms;
using ScottishGlenApp.Data;
using System.Linq;

namespace ScottishGlenApp
{
public class DepartmentsForm : Form{
    private readonly ScottishGlenDbContext _dbContext;
    public DepartmentsForm(ScottishGlenDbContext dbContext)
    {
        _dbContext = dbContext;
        Text = "ScottishGlen - Departments";
        Size = new Size(900, 650);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(245, 247, 250);
        Label title = new Label();
        title.Text = "Company Departments";
        title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        title.ForeColor = Color.FromArgb(25, 40, 65);
        title.Location = new Point(40, 35);
        title.AutoSize = true;
        Controls.Add(title);
        DataGridView departmentsTable = new DataGridView();
        departmentsTable.Location = new Point(40, 110);
        departmentsTable.Size = new Size(800, 400);
        departmentsTable.BackgroundColor = Color.White;
        departmentsTable.BorderStyle = BorderStyle.None;
        departmentsTable.ReadOnly = true;
        departmentsTable.AllowUserToAddRows = false;
        departmentsTable.AllowUserToDeleteRows = false;
        departmentsTable.AllowUserToResizeRows = false;
        departmentsTable.RowHeadersVisible = false;
        departmentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        departmentsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        Controls.Add(departmentsTable);
        departmentsTable.DataSource = _dbContext.Departments    
            .OrderBy(d =>d.departmentID)
            .Select(d=>new{
                DepartmentID = d.departmentID,
                DepartmentName = d.departmentName
            })
            .ToList();
        departmentsTable.Columns["DepartmentID"]!.HeaderText = "Department ID";
        departmentsTable.Columns["DepartmentName"]!.HeaderText = "Department Name";

    }
}
}