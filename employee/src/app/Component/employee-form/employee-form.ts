import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService, Employee } from 'src/app/services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html'
})
export class EmployeeFormComponent implements OnInit {
  employeeForm: FormGroup;
  editMode = false;
  employeeId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private empService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.employeeForm = this.fb.group({
      name: ['', Validators.required],
      position: ['', Validators.required],
      department: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.editMode = true;
        this.employeeId = +params['id'];
        this.empService.getEmployee(this.employeeId).subscribe(emp => {
          this.employeeForm.patchValue(emp);
        });
      }
    });
  }

  onSubmit() {
    const employee = this.employeeForm.value as Employee;
    if (this.editMode && this.employeeId) {
      this.empService.updateEmployee(this.employeeId, employee).subscribe(() => this.router.navigate(['/dashboard']));
    } else {
      this.empService.createEmployee(employee).subscribe(() => this.router.navigate(['/dashboard']));
    }
  }
}
