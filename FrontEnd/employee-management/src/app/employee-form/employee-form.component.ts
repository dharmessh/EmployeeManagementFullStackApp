import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../models/employee';
import { EmployeeService } from '../employee.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent implements OnInit {

  employee: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    position: ''
  }

  errorMessage: string = "";
  isEditing: boolean = false;

  constructor(private employeeService: EmployeeService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((result) => {
      console.log(result);

      const id = result.get('id');
      if (id) {
        // Edit Employee
        console.log("Editing Mode for Employee");
        this.isEditing = true;

        this.employeeService.getEmployeesById(Number(id)).subscribe({
          next: (result) => {
            this.employee = result;
          },
          error: (err) => {
            console.error("Error Loading Employee", err);
            this.errorMessage = `Error : ${err.status} - ${err.message}`;
          }
        });
      }
      else {
        console.log("Creation Mode for Employee");
        // Create Employee
      }
    });
  }

  onSubmit(): void {
    console.log(this.employee);

    if (this.isEditing) {
      this.employeeService.editEmployee(this.employee)
        //.subscribe((result) => console.log(result));
        .subscribe({
          next: (response) => {
            this.router.navigate(['/']);

          },
          error: (err) => {
            console.log(err);
            this.errorMessage = `Error Occured During Edit: ${err.status} - ${err.message}`;

          }
        });
    }
    else {
      this.employeeService.createEmployee(this.employee)
        //.subscribe((result) => console.log(result));
        .subscribe({
          next: (response) => {
            this.router.navigate(['/']);

          },
          error: (err) => {
            console.log(err);
            this.errorMessage = `Error Occured During Create: ${err.status} - ${err.message}`;

          }
        });
    }
  }

}
