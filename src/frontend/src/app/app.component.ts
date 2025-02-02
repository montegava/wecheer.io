import { Component } from '@angular/core';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [DashboardComponent, MatToolbarModule],
  template: `
    <mat-toolbar color="primary">
      <span>Image Event Dashboard</span>
    </mat-toolbar>
    <main>
      <app-dashboard></app-dashboard>
    </main>
  `,
  styles: [
    `
      main {
        padding: 20px;
      }
      mat-toolbar {
        margin-bottom: 20px;
      }
    `,
  ],
})
export class AppComponent {}
