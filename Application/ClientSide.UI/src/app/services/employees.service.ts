import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>('https://localhost:7131/api/employees');

  }

  addEmployee(addEmployeeRequest: Employee): Observable<Employee>
  {
    addEmployeeRequest.id = '00000000-0000-4747-A214-3B72271427C7';
    return this.http.post<Employee>('https://localhost:7131/api/employees',addEmployeeRequest);
  }

  getEmployee(id: string): Observable<Employee>{
    return this.http.get<Employee>('https://localhost:7131/api/employees/'+ id);
  }

  updateEmployee(id: string, updateEmployeeRequest: Employee): Observable<Employee>
  {
    return this.http.put<Employee>('https://localhost:7131/api/employees/'+ id, updateEmployeeRequest);
  }

  deleteEmployee(id: string): Observable<Employee>
  {
    return this.http.delete<Employee>('https://localhost:7131/api/employees/' + id);
  }

}
