import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ApiService, ImageEvent } from '../api.service';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatProgressSpinnerModule, DatePipe],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  latestEvent: ImageEvent | null = null;
  eventCount = 0;
  isLoading = true;
  error: string | null = null;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.apiService.getStats().subscribe({
      next: (event) => {
        this.latestEvent = event.latestImage;
        this.eventCount = event.count;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Failed to load image data';
        this.isLoading = false;
      },
    });
  }
}
