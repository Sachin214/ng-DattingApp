import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { EmployeeService } from '../_services/employee.service';
import { Employee } from '../_models/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  dataSaved = false;
  employeeForm: any;
  allEmployees: Observable<Employee[]>;
  allCountries: Observable<string[]>;
  allCities: Observable<string[]>;
  employeeIdUpdate = null;
  massage = null;

  constructor(
    private formbulider: FormBuilder,
    private employeeService: EmployeeService
  ) {}

  ngOnInit() {
    this.employeeForm = this.formbulider.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      emailId: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      city: ['', [Validators.required]],
      country: ['', [Validators.required]]
    });
    this.employeeForm.controls['gender'].setValue('0');
    this.loadAllCountries();
    this.loadAllEmployees();
  }
  loadAllEmployees() {
    this.allEmployees = this.employeeService.getAllEmployee();
  }

  loadAllCountries() {
    this.allCountries = this.employeeService.getAllCountries();
    this.employeeForm.controls['country'].setValue(null);
    this.employeeForm.controls['city'].setValue(null);
  }
  onFormSubmit() {
    this.dataSaved = false;
    const employee = this.employeeForm.value;
    this.CreateEmployee(employee);
    this.employeeForm.reset();
  }
  loadEmployeeToEdit(employeeId: string) {
    this.employeeService.getEmployeeById(employeeId).subscribe(employee => {
      this.massage = null;
      this.dataSaved = false;
      this.employeeIdUpdate = employee.id;
      this.employeeForm.controls['firstName'].setValue(employee.firstName);
      this.employeeForm.controls['lastName'].setValue(employee.lastName);
      this.employeeForm.controls['dateOfBirth'].setValue(employee.dateOfBirth.substring(0, 10));
      this.employeeForm.controls['emailId'].setValue(employee.emailId);
      this.employeeForm.controls['gender'].setValue(employee.gender);
      this.employeeForm.controls['city'].setValue(employee.city);
      this.employeeForm.controls['country'].setValue(employee.country);
      this.allCities = this.employeeService.getAllCities(employee.country);
    });
  }
  CreateEmployee(employee: Employee) {
    if (this.employeeIdUpdate == null) {
      this.employeeService.createEmployee(employee).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record saved Successfully';
        this.loadAllEmployees();
        this.employeeIdUpdate = null;
        this.employeeForm.reset();
        this.employeeForm.controls['gender'].setValue('0');
      });
    } else {
      employee.id = this.employeeIdUpdate;
      this.employeeService.updateEmployee(employee).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        this.loadAllEmployees();
        this.employeeIdUpdate = null;
        this.employeeForm.reset();
        this.employeeForm.controls['gender'].setValue('0');
      });
    }
  }
  deleteEmployee(employeeId: string) {
    if (confirm('Are you sure you want to delete this ?')) {
      this.employeeService.deleteEmployeeById(employeeId).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Deleted Succefully';
        this.loadAllEmployees();
        this.employeeIdUpdate = null;
        this.employeeForm.reset();
      });
    }
  }
  resetForm() {
    this.employeeForm.reset();
    this.massage = null;
    this.dataSaved = false;
    this.employeeForm.controls['gender'].setValue("0");
  }
  onCountryChange(e) {
    let country = e.target.value;
    this.allCities = this.employeeService.getAllCities(country);
  }
}
