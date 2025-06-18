import { Routes } from '@angular/router';

export 
const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'employee/:id', component: EmployeeFormComponent, canActivate: [AuthGuard] },
  { path: 'employee', component: EmployeeFormComponent, canActivate: [AuthGuard] },
];

