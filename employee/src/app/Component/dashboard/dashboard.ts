import { Component, OnInit } from '@angular/core';
import { EmployeeService, Employee } from 'src/app/services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  employees: Employee[] = [];
  filteredEmployees: Employee[] = [];
  searchText = '';

  constructor(private empService: EmployeeService, private router: Router) {}

  ngOnInit() {
    this.empService.getEmployees().subscribe(data => {
      this.employees = this.filteredEmployees = data;
    });
  }

  search() {
    this.filteredEmployees = this.employees.filter(e =>
      e.name.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  editEmployee(id: number) {
    this.router.navigate(['/employee/edit', id]);
  }

  addEmployee() {
    this.router.navigate(['/employee/new']);
  }
}
