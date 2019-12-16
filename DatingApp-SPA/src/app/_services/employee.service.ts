import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Employee } from '../_models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = 'http://localhost:5000/api/Values';
  constructor(private http: HttpClient) {}

  getAllEmployee(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + '/GetEmployees');
  }

  getAllCountries(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + '/GetCountries');
  }

  getAllCities(country: string): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + '/GetCities?country=' + country);
  }

  getEmployeeById(employeeId: string): Observable<Employee> {
    return this.http.get<Employee>(this.baseUrl + '/GetEmployee/' + employeeId);
  }

  createEmployee(employee: Employee): Observable<Employee> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post<Employee>(
      this.baseUrl + '/InsertEmployeeDetails/',
      employee,
      httpOptions
    );
  }

  updateEmployee(employee: Employee): Observable<Employee> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.put<Employee>(
      this.baseUrl + '/UpdateEmployeeDetails/',
      employee,
      httpOptions
    );
  }

  deleteEmployeeById(employeeid: string): Observable<number> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.delete<number>(
      this.baseUrl + '/DeleteEmployeeDetails/' + employeeid,
      httpOptions
    );
  }
}
